using DevEdu.Core.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services.Offline
{
    public enum RegistrationSyncResult
    {
        Completed,
        AlreadyProcessed,
        DuplicateEmail,
        OperationTypeMismatch
    }

    public sealed class OfflineRegistrationRepository
        : DatabaseConnection
    {
        public async Task<RegistrationSyncResult>
            SynchronizeUserRegistrationAsync(
                string operationId,
                string nombre,
                string apellido,
                string correo,
                string contrasenaHash,
                CancellationToken cancellationToken = default)
        {
            if (!Guid.TryParse(operationId, out Guid id))
            {
                throw new ArgumentException(
                    "El identificador de operación no es válido.",
                    nameof(operationId));
            }

            cancellationToken.ThrowIfCancellationRequested();

            await OpenConnAsync(cancellationToken);

            using SqlTransaction transaction =
                (SqlTransaction)await _connection.BeginTransactionAsync(
                    IsolationLevel.Serializable,
                    cancellationToken);

            try
            {
                using (var command = new SqlCommand(
                    @"SELECT operation_type
                      FROM dbo.operaciones_sincronizadas
                           WITH (UPDLOCK, HOLDLOCK)
                      WHERE operation_id = @operationId;",
                    _connection,
                    transaction))
                {
                    command.Parameters.Add(
                        "@operationId",
                        SqlDbType.UniqueIdentifier).Value = id;

                    object resultado =
                        await command.ExecuteScalarAsync(
                            cancellationToken);

                    if (resultado != null &&
                        resultado != DBNull.Value)
                    {
                        string tipo = resultado.ToString();

                        await transaction.CommitAsync(
                            cancellationToken);

                        return tipo == "UserRegistration"
                            ? RegistrationSyncResult.AlreadyProcessed
                            : RegistrationSyncResult.OperationTypeMismatch;
                    }
                }

                using (var command = new SqlCommand(
                    @"SELECT COUNT_BIG(*)
                      FROM dbo.usuarios WITH (UPDLOCK, HOLDLOCK)
                      WHERE correo = @correo;",
                    _connection,
                    transaction))
                {
                    command.Parameters.Add(
                        "@correo",
                        SqlDbType.NVarChar,
                        320).Value = correo;

                    long cantidad = Convert.ToInt64(
                        await command.ExecuteScalarAsync(
                            cancellationToken));

                    if (cantidad > 0)
                    {
                        await transaction.RollbackAsync(
                            cancellationToken);

                        return RegistrationSyncResult.DuplicateEmail;
                    }
                }

                using (var command = new SqlCommand(
                    @"INSERT INTO dbo.usuarios
                      (nombre, apellido, correo, contrasena)
                      VALUES
                      (@nombre, @apellido, @correo, @contrasena);",
                    _connection,
                    transaction))
                {
                    command.Parameters.Add(
                        "@nombre", SqlDbType.NVarChar, 100).Value = nombre;

                    command.Parameters.Add(
                        "@apellido", SqlDbType.NVarChar, 100).Value = apellido;

                    command.Parameters.Add(
                        "@correo", SqlDbType.NVarChar, 320).Value = correo;

                    command.Parameters.Add(
                        "@contrasena", SqlDbType.NVarChar, 255)
                        .Value = contrasenaHash;

                    int filas = await command.ExecuteNonQueryAsync(
                        cancellationToken);

                    if (filas != 1)
                    {
                        throw new InvalidOperationException(
                            "No se confirmó el registro del usuario.");
                    }
                }

                using (var command = new SqlCommand(
                    @"INSERT INTO dbo.operaciones_sincronizadas
                      (operation_id, operation_type)
                      VALUES (@operationId, @operationType);",
                    _connection,
                    transaction))
                {
                    command.Parameters.Add(
                        "@operationId",
                        SqlDbType.UniqueIdentifier).Value = id;

                    command.Parameters.Add(
                        "@operationType",
                        SqlDbType.VarChar,
                        50).Value = "UserRegistration";

                    await command.ExecuteNonQueryAsync(
                        cancellationToken);
                }

                await transaction.CommitAsync(cancellationToken);

                return RegistrationSyncResult.Completed;
            }
            catch
            {
                try
                {
                    await transaction.RollbackAsync(
                        CancellationToken.None);
                }
                catch
                {
                    // Se conserva la excepción original.
                }

                throw;
            }
            finally
            {
                CloseConn();
            }
        }
    }
}
