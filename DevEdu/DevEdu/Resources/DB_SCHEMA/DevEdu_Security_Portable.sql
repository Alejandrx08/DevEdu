
/*
    DevEdu - Configuracion portable de seguridad y auditoria
    Compatible con SQL Server 2022.

    Incluye:
      1. Roles de base de datos.
      2. Permisos de consulta y operacion.
      3. Restricciones de acceso a dbo.bitacora.
      4. Rol administrativo.
      5. Vinculacion de usuarios con logins existentes.
      6. Trigger de auditoria de dbo.usuarios.

    No incluye:
      - Creacion de logins de servidor ni contrasenas.
      - Datos de prueba.
      - Pruebas de permisos.
      - Backups ni trabajos de SQL Server Agent.
*/

USE [DevEdu];
GO

SET NOCOUNT ON;
GO

/* =========================================================
   1. Comprobar objetos requeridos
   ========================================================= */

IF OBJECT_ID(N'dbo.usuarios', N'U') IS NULL
    THROW 50001, 'No existe la tabla dbo.usuarios en DevEdu.', 1;

IF OBJECT_ID(N'dbo.bitacora', N'U') IS NULL
    THROW 50002, 'No existe la tabla dbo.bitacora en DevEdu.', 1;
GO

/* =========================================================
   2. Crear roles si no existen
   ========================================================= */

IF DATABASE_PRINCIPAL_ID(N'DevEdu_Consulta') IS NULL
    CREATE ROLE [DevEdu_Consulta] AUTHORIZATION [dbo];
GO

IF DATABASE_PRINCIPAL_ID(N'DevEdu_Operador') IS NULL
    CREATE ROLE [DevEdu_Operador] AUTHORIZATION [dbo];
GO

IF DATABASE_PRINCIPAL_ID(N'DevEdu_Administrador') IS NULL
    CREATE ROLE [DevEdu_Administrador] AUTHORIZATION [dbo];
GO

/* =========================================================
   3. Permisos del rol de consulta
   ========================================================= */

GRANT SELECT TO [DevEdu_Consulta];
GO

/* =========================================================
   4. Permisos del rol operador
   ========================================================= */

GRANT SELECT, INSERT, UPDATE, DELETE
ON SCHEMA::dbo
TO [DevEdu_Operador];
GO

DENY INSERT, UPDATE, DELETE
ON OBJECT::dbo.bitacora
TO [DevEdu_Operador];
GO

/* =========================================================
   5. Crear o reparar usuarios de base de datos
      Los logins deben existir previamente en el servidor.
   ========================================================= */

-- Usuario de consulta
IF EXISTS (
    SELECT 1
    FROM sys.server_principals
    WHERE name = N'DevEdu_TestConsulta'
)
BEGIN
    IF DATABASE_PRINCIPAL_ID(N'DevEdu_TestConsulta') IS NULL
        CREATE USER [DevEdu_TestConsulta]
        FOR LOGIN [DevEdu_TestConsulta];
    ELSE
        ALTER USER [DevEdu_TestConsulta]
        WITH LOGIN = [DevEdu_TestConsulta];

    IF NOT EXISTS (
        SELECT 1
        FROM sys.database_role_members
        WHERE role_principal_id =
              DATABASE_PRINCIPAL_ID(N'DevEdu_Consulta')
          AND member_principal_id =
              DATABASE_PRINCIPAL_ID(N'DevEdu_TestConsulta')
    )
        ALTER ROLE [DevEdu_Consulta]
        ADD MEMBER [DevEdu_TestConsulta];
END
ELSE
    PRINT 'Aviso: falta el login de servidor DevEdu_TestConsulta.';
GO

-- Usuario operador
IF EXISTS (
    SELECT 1
    FROM sys.server_principals
    WHERE name = N'DevEdu_TestOperador'
)
BEGIN
    IF DATABASE_PRINCIPAL_ID(N'DevEdu_TestOperador') IS NULL
        CREATE USER [DevEdu_TestOperador]
        FOR LOGIN [DevEdu_TestOperador];
    ELSE
        ALTER USER [DevEdu_TestOperador]
        WITH LOGIN = [DevEdu_TestOperador];

    IF NOT EXISTS (
        SELECT 1
        FROM sys.database_role_members
        WHERE role_principal_id =
              DATABASE_PRINCIPAL_ID(N'DevEdu_Operador')
          AND member_principal_id =
              DATABASE_PRINCIPAL_ID(N'DevEdu_TestOperador')
    )
        ALTER ROLE [DevEdu_Operador]
        ADD MEMBER [DevEdu_TestOperador];
END
ELSE
    PRINT 'Aviso: falta el login de servidor DevEdu_TestOperador.';
GO

-- Usuario administrador
IF EXISTS (
    SELECT 1
    FROM sys.server_principals
    WHERE name = N'DevEdu_TestAdmin'
)
BEGIN
    IF DATABASE_PRINCIPAL_ID(N'DevEdu_TestAdmin') IS NULL
        CREATE USER [DevEdu_TestAdmin]
        FOR LOGIN [DevEdu_TestAdmin];
    ELSE
        ALTER USER [DevEdu_TestAdmin]
        WITH LOGIN = [DevEdu_TestAdmin];

    IF NOT EXISTS (
        SELECT 1
        FROM sys.database_role_members
        WHERE role_principal_id =
              DATABASE_PRINCIPAL_ID(N'DevEdu_Administrador')
          AND member_principal_id =
              DATABASE_PRINCIPAL_ID(N'DevEdu_TestAdmin')
    )
        ALTER ROLE [DevEdu_Administrador]
        ADD MEMBER [DevEdu_TestAdmin];
END
ELSE
    PRINT 'Aviso: falta el login de servidor DevEdu_TestAdmin.';
GO

/* =========================================================
   6. Rol administrador con privilegios db_owner
   ========================================================= */

IF NOT EXISTS (
    SELECT 1
    FROM sys.database_role_members
    WHERE role_principal_id = DATABASE_PRINCIPAL_ID(N'db_owner')
      AND member_principal_id =
          DATABASE_PRINCIPAL_ID(N'DevEdu_Administrador')
)
    ALTER ROLE [db_owner]
    ADD MEMBER [DevEdu_Administrador];
GO

/* =========================================================
   7. Trigger de auditoria de usuarios
   Registra INSERT, UPDATE y DELETE en dbo.bitacora.
   ========================================================= */

CREATE OR ALTER TRIGGER dbo.trg_bitacora_usuarios
ON dbo.usuarios
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- INSERT
    INSERT INTO dbo.bitacora
        (tabla, operacion, usuario_id, fecha, descripcion)
    SELECT
        'usuarios',
        'INSERT',
        i.id,
        GETDATE(),
        'Se creó un nuevo usuario.'
    FROM inserted AS i
    LEFT JOIN deleted AS d
        ON d.id = i.id
    WHERE d.id IS NULL;

    -- UPDATE
    INSERT INTO dbo.bitacora
        (tabla, operacion, usuario_id, fecha, descripcion)
    SELECT
        'usuarios',
        'UPDATE',
        i.id,
        GETDATE(),
        'Se modificó la información del usuario.'
    FROM inserted AS i
    INNER JOIN deleted AS d
        ON d.id = i.id;

    -- DELETE
    INSERT INTO dbo.bitacora
        (tabla, operacion, usuario_id, fecha, descripcion)
    SELECT
        'usuarios',
        'DELETE',
        d.id,
        GETDATE(),
        'Se eliminó un usuario.'
    FROM deleted AS d
    LEFT JOIN inserted AS i
        ON i.id = d.id
    WHERE i.id IS NULL;
END;
GO

/*
    Fin de la configuracion.
    Los logins de servidor, sus contrasenas, los trabajos
    de SQL Server Agent y las rutas de backups son
    especificos de cada instancia/maquina.
*/
