
/*
    DevEdu - Creacion de logins de SQL Server
    Ejecutar en la base de datos master.
    Requiere permisos para crear y modificar logins.
*/

USE [master];
GO

/* =====================================================
   1. Login de consulta
   ===================================================== */

IF SUSER_ID(N'DevEdu_TestConsulta') IS NULL
BEGIN
    CREATE LOGIN [DevEdu_TestConsulta]
    WITH PASSWORD = N'<CONTRASENA_CONSULTA>',
         CHECK_POLICY = ON,
         CHECK_EXPIRATION = OFF,
         DEFAULT_DATABASE = [DevEdu];
END
ELSE
BEGIN
    ALTER LOGIN [DevEdu_TestConsulta] ENABLE;
    ALTER LOGIN [DevEdu_TestConsulta]
        WITH DEFAULT_DATABASE = [DevEdu];
END;
GO

/* =====================================================
   2. Login operador
   ===================================================== */

IF SUSER_ID(N'DevEdu_TestOperador') IS NULL
BEGIN
    CREATE LOGIN [DevEdu_TestOperador]
    WITH PASSWORD = N'<CONTRASENA_OPERADOR>',
         CHECK_POLICY = ON,
         CHECK_EXPIRATION = OFF,
         DEFAULT_DATABASE = [DevEdu];
END
ELSE
BEGIN
    ALTER LOGIN [DevEdu_TestOperador] ENABLE;
    ALTER LOGIN [DevEdu_TestOperador]
        WITH DEFAULT_DATABASE = [DevEdu];
END;
GO

/* =====================================================
   3. Login administrador
   ===================================================== */

IF SUSER_ID(N'DevEdu_TestAdmin') IS NULL
BEGIN
    CREATE LOGIN [DevEdu_TestAdmin]
    WITH PASSWORD = N'<CONTRASENA_ADMINISTRADOR>',
         CHECK_POLICY = ON,
         CHECK_EXPIRATION = OFF,
         DEFAULT_DATABASE = [DevEdu];
END
ELSE
BEGIN
    ALTER LOGIN [DevEdu_TestAdmin] ENABLE;
    ALTER LOGIN [DevEdu_TestAdmin]
        WITH DEFAULT_DATABASE = [DevEdu];
END;
GO
