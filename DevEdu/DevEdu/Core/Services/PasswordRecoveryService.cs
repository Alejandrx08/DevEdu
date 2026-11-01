using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Data;
using System.Net;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services
{
    public sealed class PasswordRecoveryService : DatabaseConnection
    {
        private const int VigenciaMinutos = 10;
        private const int MaxIntentos = 5;

        public async Task SolicitarCodigoAsync(
            string correo,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(correo))
            {
                throw new ArgumentException(
                    "El correo es obligatorio.",
                    nameof(correo));
            }

            string correoNormalizado = correo.Trim();
            int? usuarioId = null;
            string nombre = string.Empty;

            await OpenConnAsync(cancellationToken);

            try
            {
                using (var command = new SqlCommand(
                    @"SELECT TOP (1) id, nombre
                      FROM usuarios
                      WHERE correo = @correo
                        AND activo = 1;",
                    _connection))
                {
                    command.Parameters.Add(
                        "@correo",
                        SqlDbType.VarChar,
                        100).Value = correoNormalizado;

                    using SqlDataReader reader =
                        await command.ExecuteReaderAsync(
                            cancellationToken);

                    if (await reader.ReadAsync(cancellationToken))
                    {
                        usuarioId = reader.GetInt32(0);

                        nombre = reader.IsDBNull(1)
                            ? string.Empty
                            : reader.GetString(1);
                    }
                }
            }
            finally
            {
                CloseConn();
            }

            // No revelar si existe la cuenta.
            if (!usuarioId.HasValue)
                return;

            string codigo = RandomNumberGenerator
                .GetInt32(0, 1_000_000)
                .ToString("D6");

            byte[] hashCodigo = HashCodigo(codigo);

            await OpenConnAsync(cancellationToken);

            try
            {
                using var transaction =
                    (SqlTransaction)await _connection
                        .BeginTransactionAsync(cancellationToken);

                try
                {
                    using (var invalidate = new SqlCommand(
                        @"UPDATE dbo.password_recovery_codes
                          SET used_at = SYSUTCDATETIME()
                          WHERE user_id = @userId
                            AND used_at IS NULL;",
                        _connection,
                        transaction))
                    {
                        invalidate.Parameters.Add(
                            "@userId",
                            SqlDbType.Int).Value = usuarioId.Value;

                        await invalidate.ExecuteNonQueryAsync(
                            cancellationToken);
                    }

                    using (var insert = new SqlCommand(
                        @"INSERT INTO dbo.password_recovery_codes
                          (
                              user_id,
                              code_hash,
                              expires_at,
                              attempts,
                              created_at
                          )
                          VALUES
                          (
                              @userId,
                              @codeHash,
                              DATEADD(
                                  MINUTE,
                                  @minutes,
                                  SYSUTCDATETIME()),
                              0,
                              SYSUTCDATETIME()
                          );",
                        _connection,
                        transaction))
                    {
                        insert.Parameters.Add(
                            "@userId",
                            SqlDbType.Int).Value = usuarioId.Value;

                        insert.Parameters.Add(
                            "@codeHash",
                            SqlDbType.Binary,
                            32).Value = hashCodigo;

                        insert.Parameters.Add(
                            "@minutes",
                            SqlDbType.Int).Value = VigenciaMinutos;

                        await insert.ExecuteNonQueryAsync(
                            cancellationToken);
                    }

                    await transaction.CommitAsync(cancellationToken);
                }
                catch
                {
                    await transaction.RollbackAsync(
                        CancellationToken.None);
                    throw;
                }
            }
            finally
            {
                CloseConn();
            }

            try
            {
                await EnviarCodigoAsync(
                    correoNormalizado,
                    nombre,
                    codigo,
                    cancellationToken);
            }
            catch
            {
                await InvalidarCodigosPendientesAsync(
                    usuarioId.Value,
                    cancellationToken);

                throw;
            }
        }

        public async Task<bool> RestablecerContrasenaAsync(
            string correo,
            string codigo,
            string nuevaContrasena,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(correo)
                || string.IsNullOrWhiteSpace(codigo)
                || string.IsNullOrEmpty(nuevaContrasena))
            {
                return false;
            }

            string nuevoHashPassword =
                BCrypt.Net.BCrypt.HashPassword(nuevaContrasena);

            byte[] hashCodigo = HashCodigo(codigo);

            await OpenConnAsync(cancellationToken);

            try
            {
                using var transaction =
                    (SqlTransaction)await _connection
                        .BeginTransactionAsync(
                            IsolationLevel.Serializable,
                            cancellationToken);

                try
                {
                    int? usuarioId = null;
                    long? recoveryId = null;
                    byte[] hashAlmacenado = null;
                    int intentos = 0;
                    bool vigente = false;

                    using (var select = new SqlCommand(
                        @"SELECT TOP (1)
                              r.recovery_id,
                              r.user_id,
                              r.code_hash,
                              r.attempts,
                              CASE
                                  WHEN r.expires_at > SYSUTCDATETIME()
                                   AND r.used_at IS NULL
                                  THEN 1
                                  ELSE 0
                              END AS vigente
                          FROM dbo.password_recovery_codes r
                              WITH (UPDLOCK, HOLDLOCK)
                          INNER JOIN dbo.usuarios u
                              ON u.id = r.user_id
                          WHERE u.correo = @correo
                            AND u.activo = 1
                            AND r.used_at IS NULL
                          ORDER BY
                              r.created_at DESC,
                              r.recovery_id DESC;",
                        _connection,
                        transaction))
                    {
                        select.Parameters.Add(
                            "@correo",
                            SqlDbType.VarChar,
                            100).Value = correo.Trim();

                        using SqlDataReader reader =
                            await select.ExecuteReaderAsync(
                                cancellationToken);

                        if (await reader.ReadAsync(cancellationToken))
                        {
                            recoveryId = reader.GetInt64(0);
                            usuarioId = reader.GetInt32(1);
                            hashAlmacenado = (byte[])reader["code_hash"];
                            intentos = reader.GetInt32(3);
                            vigente = reader.GetInt32(4) == 1;
                        }
                    }

                    if (!recoveryId.HasValue
                        || !usuarioId.HasValue
                        || !vigente
                        || intentos >= MaxIntentos)
                    {
                        await transaction.RollbackAsync(
                            CancellationToken.None);

                        return false;
                    }

                    bool codigoCorrecto =
                        CryptographicOperations.FixedTimeEquals(
                            hashAlmacenado,
                            hashCodigo);

                    if (!codigoCorrecto)
                    {
                        using var fail = new SqlCommand(
                            @"UPDATE dbo.password_recovery_codes
                              SET attempts = attempts + 1,
                                  used_at =
                                      CASE
                                          WHEN attempts + 1 >= @maxAttempts
                                          THEN SYSUTCDATETIME()
                                          ELSE used_at
                                      END
                              WHERE recovery_id = @id;",
                            _connection,
                            transaction);

                        fail.Parameters.Add(
                            "@maxAttempts",
                            SqlDbType.Int).Value = MaxIntentos;

                        fail.Parameters.Add(
                            "@id",
                            SqlDbType.BigInt).Value = recoveryId.Value;

                        await fail.ExecuteNonQueryAsync(
                            cancellationToken);

                        await transaction.CommitAsync(cancellationToken);

                        return false;
                    }

                    using (var update = new SqlCommand(
                        @"UPDATE dbo.usuarios
                          SET contrasena = @hash
                          WHERE id = @id
                            AND activo = 1;",
                        _connection,
                        transaction))
                    {
                        update.Parameters.Add(
                            "@hash",
                            SqlDbType.VarChar,
                            255).Value = nuevoHashPassword;

                        update.Parameters.Add(
                            "@id",
                            SqlDbType.Int).Value = usuarioId.Value;

                        if (await update.ExecuteNonQueryAsync(
                            cancellationToken) != 1)
                        {
                            await transaction.RollbackAsync(
                                CancellationToken.None);

                            return false;
                        }
                    }

                    using (var consume = new SqlCommand(
                        @"UPDATE dbo.password_recovery_codes
                          SET used_at = SYSUTCDATETIME()
                          WHERE user_id = @userId
                            AND used_at IS NULL;",
                        _connection,
                        transaction))
                    {
                        consume.Parameters.Add(
                            "@userId",
                            SqlDbType.Int).Value = usuarioId.Value;

                        await consume.ExecuteNonQueryAsync(
                            cancellationToken);
                    }

                    await transaction.CommitAsync(cancellationToken);

                    return true;
                }
                catch
                {
                    await transaction.RollbackAsync(
                        CancellationToken.None);
                    throw;
                }
            }
            finally
            {
                CloseConn();
            }
        }

        private async Task InvalidarCodigosPendientesAsync(
            int usuarioId,
            CancellationToken cancellationToken)
        {
            await OpenConnAsync(cancellationToken);

            try
            {
                using var command = new SqlCommand(
                    @"UPDATE dbo.password_recovery_codes
                      SET used_at = SYSUTCDATETIME()
                      WHERE user_id = @userId
                        AND used_at IS NULL;",
                    _connection);

                command.Parameters.Add(
                    "@userId",
                    SqlDbType.Int).Value = usuarioId;

                await command.ExecuteNonQueryAsync(
                    cancellationToken);
            }
            finally
            {
                CloseConn();
            }
        }

        private static byte[] HashCodigo(string codigo)
        {
            return SHA256.HashData(
                Encoding.UTF8.GetBytes(codigo));
        }

        private static async Task EnviarCodigoAsync(
            string correo,
            string nombre,
            string codigo,
            CancellationToken cancellationToken)
        {
            IConfiguration config = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile(
                    "appsettings.json",
                    optional: false,
                    reloadOnChange: false)
                .Build();

            string host =
                Environment.GetEnvironmentVariable(
                    "DevEdu_Smtp__Host")
                ?? config["Smtp:Host"];

            string portText =
                Environment.GetEnvironmentVariable(
                    "DevEdu_Smtp__Port")
                ?? config["Smtp:Port"];

            string user =
                Environment.GetEnvironmentVariable(
                    "DevEdu_Smtp__Username")
                ?? config["Smtp:Username"];

            string password =
                Environment.GetEnvironmentVariable(
                    "DevEdu_Smtp__Password")
                ?? config["Smtp:Password"];

            string from =
                Environment.GetEnvironmentVariable(
                    "DevEdu_Smtp__From")
                ?? config["Smtp:From"];

            string enableSslText =
                Environment.GetEnvironmentVariable(
                    "DevEdu_Smtp__EnableSsl")
                ?? config["Smtp:EnableSsl"];

            if (string.IsNullOrWhiteSpace(host)
                || !int.TryParse(portText, out int port)
                || string.IsNullOrWhiteSpace(from)
                || string.IsNullOrWhiteSpace(user)
                || string.IsNullOrWhiteSpace(password))
            {
                throw new InvalidOperationException(
                    "La configuración SMTP está incompleta.");
            }

            using var message = new MailMessage
            {
                From = new MailAddress(from),
                Subject =
                    "Código para recuperar tu contraseña de DevEdu",
                Body =
                    $"Hola {nombre},\n\n" +
                    $"Tu código de recuperación es: {codigo}\n\n" +
                    $"Vence en {VigenciaMinutos} minutos y solo " +
                    "puede utilizarse una vez. " +
                    "Si no solicitaste este cambio, ignora este mensaje.",
                IsBodyHtml = false
            };

            message.To.Add(correo);

            using var smtp = new SmtpClient(host, port)
            {
                EnableSsl =
                    bool.TryParse(enableSslText, out bool ssl) && ssl,

                Credentials = new NetworkCredential(user, password),

                DeliveryMethod = SmtpDeliveryMethod.Network
            };

            cancellationToken.ThrowIfCancellationRequested();

            await smtp.SendMailAsync(message);

            cancellationToken.ThrowIfCancellationRequested();
        }
    }
}