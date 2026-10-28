using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevEdu.Core.Services.Offline
{
    public sealed class OfflineOperationQueue
    {
        private readonly string _connectionString;

        private static readonly byte[] Entropy =
            Encoding.UTF8.GetBytes("DevEdu.PendingOperations.v1");

        public sealed class PendingOperation
        {
            public string OperationId { get; init; }
            public string OperationType { get; init; }
            public string PayloadJson { get; init; }
            public int Attempts { get; init; }
        }

        public OfflineOperationQueue()
        {
            string directory = Path.Combine(
                Environment.GetFolderPath(
                    Environment.SpecialFolder.LocalApplicationData),
                "DevEdu",
                "Offline");

            Directory.CreateDirectory(directory);

            string databasePath = Path.Combine(
                directory,
                "devedu-sync.db");

            _connectionString =
                new SqliteConnectionStringBuilder
                {
                    DataSource = databasePath,
                    Mode = SqliteOpenMode.ReadWriteCreate
                }.ToString();
        }

        public async Task InitializeAsync(
            CancellationToken cancellationToken = default)
        {
            await using var connection =
                new SqliteConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandText = @"
                CREATE TABLE IF NOT EXISTS pending_operations
                (
                    operation_id TEXT PRIMARY KEY,
                    operation_type TEXT NOT NULL,
                    payload BLOB NOT NULL,
                    status TEXT NOT NULL DEFAULT 'Pending',
                    attempts INTEGER NOT NULL DEFAULT 0,
                    created_at_utc TEXT NOT NULL,
                    last_attempt_utc TEXT NULL,
                    last_error TEXT NULL
                );";

            await command.ExecuteNonQueryAsync(cancellationToken);
        }

        public async Task<string> EnqueueAsync(
            string operationType,
            string payloadJson,
            CancellationToken cancellationToken = default)
        {
            if (string.IsNullOrWhiteSpace(operationType))
                throw new ArgumentException(
                    "El tipo de operación es obligatorio.",
                    nameof(operationType));

            if (string.IsNullOrWhiteSpace(payloadJson))
                throw new ArgumentException(
                    "El contenido de la operación es obligatorio.",
                    nameof(payloadJson));

            cancellationToken.ThrowIfCancellationRequested();

            byte[] plainBytes = Encoding.UTF8.GetBytes(payloadJson);

            try
            {
                byte[] encryptedPayload = ProtectedData.Protect(
                    plainBytes,
                    Entropy,
                    DataProtectionScope.CurrentUser);

                try
                {
                    string operationId = Guid.NewGuid().ToString("N");

                    await using var connection =
                        new SqliteConnection(_connectionString);

                    await connection.OpenAsync(cancellationToken);

                    using var command = connection.CreateCommand();

                    command.CommandText = @"
                        INSERT INTO pending_operations
                        (
                            operation_id,
                            operation_type,
                            payload,
                            status,
                            created_at_utc
                        )
                        VALUES
                        (
                            $operationId,
                            $operationType,
                            $payload,
                            'Pending',
                            $createdAt
                        );";

                    command.Parameters.AddWithValue(
                        "$operationId", operationId);

                    command.Parameters.AddWithValue(
                        "$operationType", operationType);

                    command.Parameters.AddWithValue(
                        "$payload", encryptedPayload);

                    command.Parameters.AddWithValue(
                        "$createdAt", DateTime.UtcNow.ToString("O"));

                    await command.ExecuteNonQueryAsync(
                        cancellationToken);

                    return operationId;
                }
                finally
                {
                    Array.Clear(
                        encryptedPayload, 0, encryptedPayload.Length);
                }
            }
            finally
            {
                Array.Clear(plainBytes, 0, plainBytes.Length);
            }
        }

        public async Task<List<PendingOperation>> GetPendingAsync(
            CancellationToken cancellationToken = default)
        {
            var operations = new List<PendingOperation>();

            await using var connection =
                new SqliteConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandText = @"
                SELECT operation_id, operation_type, payload, attempts
                FROM pending_operations
                WHERE status = 'Pending'
                ORDER BY created_at_utc;";

            await using var reader =
                await command.ExecuteReaderAsync(cancellationToken);

            while (await reader.ReadAsync(cancellationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();

                string operationId = reader.GetString(0);
                string operationType = reader.GetString(1);
                byte[] encryptedPayload = (byte[])reader[2];
                int attempts = reader.GetInt32(3);

                byte[] plainBytes = null;

                try
                {
                    plainBytes = ProtectedData.Unprotect(
                        encryptedPayload,
                        Entropy,
                        DataProtectionScope.CurrentUser);

                    string payloadJson =
                        Encoding.UTF8.GetString(plainBytes);

                    operations.Add(new PendingOperation
                    {
                        OperationId = operationId,
                        OperationType = operationType,
                        PayloadJson = payloadJson,
                        Attempts = attempts
                    });
                }
                finally
                {
                    Array.Clear(
                        encryptedPayload, 0, encryptedPayload.Length);

                    if (plainBytes != null)
                    {
                        Array.Clear(plainBytes, 0, plainBytes.Length);
                    }
                }
            }

            return operations;
        }

        public async Task RegisterFailedAttemptAsync(
            string operationId,
            string errorCode,
            CancellationToken cancellationToken = default)
        {
            await using var connection =
                new SqliteConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE pending_operations
                SET attempts = attempts + 1,
                    last_attempt_utc = $attemptedAt,
                    last_error = $errorCode
                WHERE operation_id = $operationId
                  AND status = 'Pending';";

            command.Parameters.AddWithValue(
                "$operationId", operationId);

            command.Parameters.AddWithValue(
                "$attemptedAt", DateTime.UtcNow.ToString("O"));

            command.Parameters.AddWithValue(
                "$errorCode", errorCode);

            await command.ExecuteNonQueryAsync(cancellationToken);
        }

        public async Task MarkCompletedAsync(
            string operationId,
            CancellationToken cancellationToken = default)
        {
            await using var connection =
                new SqliteConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE pending_operations
                SET status = 'Completed',
                    payload = X'',
                    last_error = NULL
                WHERE operation_id = $operationId
                  AND status = 'Pending';";

            command.Parameters.AddWithValue(
                "$operationId", operationId);

            await command.ExecuteNonQueryAsync(cancellationToken);
        }

        public async Task MarkConflictAsync(
            string operationId,
            string errorCode,
            CancellationToken cancellationToken = default)
        {
            await using var connection =
                new SqliteConnection(_connectionString);

            await connection.OpenAsync(cancellationToken);

            using var command = connection.CreateCommand();

            command.CommandText = @"
                UPDATE pending_operations
                SET status = 'Conflict',
                    last_attempt_utc = $attemptedAt,
                    last_error = $errorCode
                WHERE operation_id = $operationId
                  AND status = 'Pending';";

            command.Parameters.AddWithValue(
                "$operationId", operationId);

            command.Parameters.AddWithValue(
                "$attemptedAt", DateTime.UtcNow.ToString("O"));

            command.Parameters.AddWithValue(
                "$errorCode", errorCode);

            await command.ExecuteNonQueryAsync(cancellationToken);
        }
    }
}
