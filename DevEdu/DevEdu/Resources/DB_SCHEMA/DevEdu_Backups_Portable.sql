/*
 DevEdu - Respaldos automáticos portables
 Configura:
   FULL: diario a las 22:00
   Diferencial: cada 6 horas
   Log de transacciones: cada 15 minutos

 EJECUTAR en SSMS con permisos sysadmin.
 Antes de ejecutar:
   - Cambie @BackupDirectory si necesita otra ruta LOCAL DEL SERVIDOR.
   - La carpeta debe existir en el servidor SQL Server.
   - La cuenta del servicio SQL Server Database Engine necesita permiso de escritura.
   - SQL Server Agent debe estar instalado y en ejecución.
   - La base [devedu] debe existir y estar en recuperación FULL.

 Este script configura trabajos; no copia/restaura la base ni sus objetos.
*/

USE master;
GO
SET NOCOUNT ON;

IF IS_SRVROLEMEMBER(N'sysadmin') <> 1
    THROW 51000, 'Ejecute el script con una cuenta sysadmin.', 1;

IF DB_ID(N'devedu') IS NULL
    THROW 51001, 'No existe la base [devedu] en esta instancia.', 1;

IF (SELECT recovery_model_desc FROM sys.databases WHERE name = N'devedu') <> N'FULL'
    THROW 51002, 'La base [devedu] debe estar en recuperación FULL.', 1;
GO

USE msdb;
GO
SET NOCOUNT ON;

DECLARE @Jobs table
(
    JobName sysname NOT NULL,
    ScheduleName sysname NOT NULL,
    JobDescription nvarchar(512) NOT NULL,
    StepName sysname NOT NULL,
    CommandText nvarchar(max) NOT NULL,
    FreqType int NOT NULL,
    FreqInterval int NOT NULL,
    FreqSubdayType int NOT NULL,
    FreqSubdayInterval int NOT NULL,
    StartTime int NOT NULL,
    EndTime int NOT NULL
);

-- Las variables declaradas antes de GO no sobreviven a GO. Por eso se genera
-- la configuración en un único bloque reejecutable a continuación.
DECLARE @BackupDirectory nvarchar(4000) = N'C:\SQLBackups\DevEdu';
DECLARE @EscapedDirectory nvarchar(4000);
DECLARE @FullCommand nvarchar(max), @DiffCommand nvarchar(max), @LogCommand nvarchar(max);

IF RIGHT(@BackupDirectory, 1) IN (N'\', N'/')
    SET @BackupDirectory = LEFT(@BackupDirectory, LEN(@BackupDirectory) - 1);
SET @EscapedDirectory = REPLACE(@BackupDirectory, N'''', N'''''');
SET @FullCommand = N'
DECLARE @f nvarchar(4000);
SET @f = N''' + @EscapedDirectory + N'\DevEdu_FULL_''
 + CONVERT(char(8), GETDATE(), 112) + N''_''
 + REPLACE(CONVERT(char(8), GETDATE(), 108), '':'', '''') + N''.bak'';
BACKUP DATABASE [devedu] TO DISK = @f WITH INIT, CHECKSUM, COMPRESSION, STATS = 10;';
SET @DiffCommand = N'
DECLARE @f nvarchar(4000);
SET @f = N''' + @EscapedDirectory + N'\DevEdu_DIFF_''
 + CONVERT(char(8), GETDATE(), 112) + N''_''
 + REPLACE(CONVERT(char(8), GETDATE(), 108), '':'', '''') + N''.bak'';
BACKUP DATABASE [devedu] TO DISK = @f WITH DIFFERENTIAL, INIT, CHECKSUM, COMPRESSION, STATS = 10;';
SET @LogCommand = N'
IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name=N''devedu'' AND recovery_model_desc=N''FULL'')
 THROW 51010, ''La base [devedu] no existe o no está en recuperación FULL.'', 1;
DECLARE @f nvarchar(4000);
SET @f = N''' + @EscapedDirectory + N'\DevEdu_LOG_''
 + CONVERT(char(8), GETDATE(), 112) + N''_''
 + REPLACE(CONVERT(char(8), GETDATE(), 108), '':'', '''') + N''.trn'';
BACKUP LOG [devedu] TO DISK = @f WITH INIT, CHECKSUM, COMPRESSION, STATS = 10;';

INSERT INTO @Jobs VALUES
(N'DevEdu - Backup FULL', N'DevEdu - Schedule FULL diario 2200',
 N'Copia FULL diaria de DevEdu.', N'Backup FULL de DevEdu', @FullCommand,
 4, 1, 1, 1, 220000, 235959),
(N'DevEdu - Backup Differential', N'DevEdu - Schedule Differential cada 6 horas',
 N'Copia diferencial de DevEdu cada 6 horas.', N'Backup diferencial de DevEdu', @DiffCommand,
 4, 1, 8, 6, 000000, 235959),
(N'DevEdu - Backup LOG', N'DevEdu - Schedule LOG cada 15 minutos',
 N'Copia del log de transacciones de DevEdu cada 15 minutos.', N'Backup LOG de DevEdu', @LogCommand,
 4, 1, 4, 15, 000000, 235959);

DECLARE
    @JobName sysname, @ScheduleName sysname, @JobDescription nvarchar(512),
    @StepName sysname, @CommandText nvarchar(max),
    @FreqType int, @FreqInterval int, @FreqSubdayType int, @FreqSubdayInterval int,
    @StartTime int, @EndTime int, @JobId uniqueidentifier, @ScheduleId int;

DECLARE job_cursor CURSOR LOCAL FAST_FORWARD FOR
SELECT JobName, ScheduleName, JobDescription, StepName, CommandText,
       FreqType, FreqInterval, FreqSubdayType, FreqSubdayInterval, StartTime, EndTime
FROM @Jobs;

OPEN job_cursor;
FETCH NEXT FROM job_cursor INTO @JobName, @ScheduleName, @JobDescription, @StepName, @CommandText,
    @FreqType, @FreqInterval, @FreqSubdayType, @FreqSubdayInterval, @StartTime, @EndTime;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @JobId = NULL;
    SELECT @JobId = job_id FROM msdb.dbo.sysjobs WHERE name = @JobName;

    IF @JobId IS NULL
        EXEC msdb.dbo.sp_add_job @job_name = @JobName, @enabled = 1,
            @description = @JobDescription, @owner_login_name = N'sa', @job_id = @JobId OUTPUT;
    ELSE
        EXEC msdb.dbo.sp_update_job @job_id = @JobId, @enabled = 1,
            @description = @JobDescription, @owner_login_name = N'sa';

    IF EXISTS (SELECT 1 FROM msdb.dbo.sysjobsteps WHERE job_id = @JobId AND step_id = 1)
        EXEC msdb.dbo.sp_update_jobstep @job_id = @JobId, @step_id = 1,
            @step_name = @StepName, @subsystem = N'TSQL', @database_name = N'master',
            @command = @CommandText, @on_success_action = 1, @on_fail_action = 2;
    ELSE
        EXEC msdb.dbo.sp_add_jobstep @job_id = @JobId,
            @step_name = @StepName, @subsystem = N'TSQL', @database_name = N'master',
            @command = @CommandText, @on_success_action = 1, @on_fail_action = 2;

    SET @ScheduleId = NULL;
    SELECT @ScheduleId = schedule_id FROM msdb.dbo.sysschedules WHERE name = @ScheduleName;

    IF @ScheduleId IS NULL
        EXEC msdb.dbo.sp_add_schedule @schedule_name = @ScheduleName, @enabled = 1,
            @freq_type = @FreqType, @freq_interval = @FreqInterval,
            @freq_subday_type = @FreqSubdayType, @freq_subday_interval = @FreqSubdayInterval,
            @active_start_time = @StartTime, @active_end_time = @EndTime,
            @schedule_id = @ScheduleId OUTPUT;
    ELSE
        EXEC msdb.dbo.sp_update_schedule @schedule_id = @ScheduleId, @enabled = 1,
            @freq_type = @FreqType, @freq_interval = @FreqInterval,
            @freq_subday_type = @FreqSubdayType, @freq_subday_interval = @FreqSubdayInterval,
            @active_start_time = @StartTime, @active_end_time = @EndTime;

    IF NOT EXISTS (SELECT 1 FROM msdb.dbo.sysjobschedules WHERE job_id = @JobId AND schedule_id = @ScheduleId)
        EXEC msdb.dbo.sp_attach_schedule @job_id = @JobId, @schedule_id = @ScheduleId;

    IF NOT EXISTS (SELECT 1 FROM msdb.dbo.sysjobservers WHERE job_id = @JobId)
        EXEC msdb.dbo.sp_add_jobserver @job_id = @JobId, @server_name = N'(LOCAL)';

    FETCH NEXT FROM job_cursor INTO @JobName, @ScheduleName, @JobDescription, @StepName, @CommandText,
        @FreqType, @FreqInterval, @FreqSubdayType, @FreqSubdayInterval, @StartTime, @EndTime;
END;

CLOSE job_cursor;
DEALLOCATE job_cursor;

PRINT 'Configuración de respaldos de DevEdu aplicada.';

SELECT
    j.name AS Trabajo,
    j.enabled AS TrabajoHabilitado,
    s.name AS Programacion,
    s.enabled AS ProgramacionHabilitada,
    CASE
      WHEN j.name = N'DevEdu - Backup FULL' THEN N'Diario a las 22:00'
      WHEN j.name = N'DevEdu - Backup Differential' THEN N'Cada 6 horas'
      WHEN j.name = N'DevEdu - Backup LOG' THEN N'Cada 15 minutos'
    END AS Frecuencia
FROM msdb.dbo.sysjobs AS j
JOIN msdb.dbo.sysjobschedules AS js ON js.job_id = j.job_id
JOIN msdb.dbo.sysschedules AS s ON s.schedule_id = js.schedule_id
WHERE j.name IN (N'DevEdu - Backup FULL', N'DevEdu - Backup Differential', N'DevEdu - Backup LOG')
ORDER BY j.name;
GO
