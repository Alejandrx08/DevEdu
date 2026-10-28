-- ============================================================
--  BASE DE DATOS: devedu — Script combinado y portable
--  Incluye: estructura completa + vista +
--           funciones + stored procedures + triggers
--  Nota: Sin usuarios automáticos (semilla removidos)
-- ============================================================

-- Crear la base de datos si no existe (sin rutas fijas -> portable)
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'devedu')
BEGIN
    CREATE DATABASE devedu;
END
GO

USE devedu;
GO

-- ============================================================
--  TABLA: usuarios
-- ============================================================
IF OBJECT_ID('usuarios', 'U') IS NULL
CREATE TABLE usuarios (
    id          INT             NOT NULL IDENTITY(1,1),
    nombre      VARCHAR(50)     NOT NULL,
    apellido    VARCHAR(50)     NOT NULL,
    correo      VARCHAR(100)    NOT NULL,
    contrasena  VARCHAR(255)    NOT NULL,

    rango       VARCHAR(20)     NOT NULL DEFAULT 'Regular'
                CONSTRAINT chk_rango CHECK (rango IN ('SuperSU','Admin','Supervision','Regular')),

    tipo        VARCHAR(20)     NULL
                CONSTRAINT chk_tipo CHECK (tipo IN ('Alumno','Maestro','Admin') OR tipo IS NULL),

    activo      BIT             NOT NULL DEFAULT 1,
    created_at  DATETIME        NOT NULL DEFAULT GETDATE(),

    CONSTRAINT pk_usuarios      PRIMARY KEY (id),
    CONSTRAINT uq_correo        UNIQUE (correo)
);
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'idx_usuario_correo'
    AND object_id = OBJECT_ID('usuarios')
)
    CREATE INDEX idx_usuario_correo ON usuarios(correo);
GO

-- ============================================================
--  TABLA: cursos
-- ============================================================
IF OBJECT_ID('cursos', 'U') IS NULL
CREATE TABLE cursos (
    id          INT             NOT NULL IDENTITY(1,1),
    nombre      VARCHAR(100)    NOT NULL,
    categoria   VARCHAR(100)    NULL,

    dificultad  VARCHAR(20)     NOT NULL DEFAULT 'Basico'
                CONSTRAINT chk_dificultad CHECK (dificultad IN ('Basico','Intermedio','Avanzado')),

    CONSTRAINT pk_cursos        PRIMARY KEY (id),
    CONSTRAINT uq_curso_nombre  UNIQUE (nombre)
);
GO

-- ============================================================
--  TABLA: alumnos
-- ============================================================
IF OBJECT_ID('alumnos', 'U') IS NULL
CREATE TABLE alumnos (
    id          INT             NOT NULL IDENTITY(1,1),
    usuario_id  INT             NOT NULL,
    matricula   VARCHAR(50)     NULL,

    CONSTRAINT pk_alumnos           PRIMARY KEY (id),
    CONSTRAINT uq_alumno_usuario    UNIQUE (usuario_id),
    CONSTRAINT fk_alumno_usuario    FOREIGN KEY (usuario_id)
        REFERENCES usuarios(id)
        ON DELETE CASCADE
);
GO

IF NOT EXISTS (
    SELECT 1 FROM sys.indexes
    WHERE name = 'uq_matricula'
    AND object_id = OBJECT_ID('alumnos')
)
    CREATE UNIQUE NONCLUSTERED INDEX uq_matricula ON alumnos(matricula)
    WHERE matricula IS NOT NULL;
GO

-- ============================================================
--  TABLA: maestros
-- ============================================================
IF OBJECT_ID('maestros', 'U') IS NULL
CREATE TABLE maestros (
    id              INT             NOT NULL IDENTITY(1,1),
    usuario_id      INT             NOT NULL,
    especialidad    VARCHAR(100)    NULL,
    activo          BIT             NOT NULL DEFAULT 1,

    CONSTRAINT pk_maestros          PRIMARY KEY (id),
    CONSTRAINT uq_maestro_usuario   UNIQUE (usuario_id),
    CONSTRAINT fk_maestro_usuario   FOREIGN KEY (usuario_id)
        REFERENCES usuarios(id)
        ON DELETE CASCADE
);
GO

-- ============================================================
--  TABLA: maestro_curso
-- ============================================================
IF OBJECT_ID('maestro_curso', 'U') IS NULL
CREATE TABLE maestro_curso (
    id          INT     NOT NULL IDENTITY(1,1),
    maestro_id  INT     NOT NULL,
    curso_id    INT     NOT NULL,

    CONSTRAINT pk_maestro_curso  PRIMARY KEY (id),
    CONSTRAINT uq_maestro_curso  UNIQUE (maestro_id, curso_id),
    CONSTRAINT fk_mc_maestro     FOREIGN KEY (maestro_id)
        REFERENCES maestros(id) ON DELETE CASCADE,
    CONSTRAINT fk_mc_curso       FOREIGN KEY (curso_id)
        REFERENCES cursos(id) ON DELETE CASCADE
);
GO

-- ============================================================
--  TABLA: alumno_curso
-- ============================================================
IF OBJECT_ID('alumno_curso', 'U') IS NULL
CREATE TABLE alumno_curso (
    id          INT             NOT NULL IDENTITY(1,1),
    alumno_id   INT             NOT NULL,
    curso_id    INT             NOT NULL,
    asistencia  BIT             NOT NULL DEFAULT 0,
    progreso    INT             NOT NULL DEFAULT 0,
    nota        DECIMAL(5,2)    NOT NULL DEFAULT 0,

    CONSTRAINT pk_alumno_curso  PRIMARY KEY (id),
    CONSTRAINT uq_alumno_curso  UNIQUE (alumno_id, curso_id),
    CONSTRAINT chk_progreso     CHECK (progreso >= 0 AND progreso <= 100),
    CONSTRAINT chk_nota         CHECK (nota >= 0 AND nota <= 100),
    CONSTRAINT fk_ac_alumno     FOREIGN KEY (alumno_id)
        REFERENCES alumnos(id) ON DELETE CASCADE,
    CONSTRAINT fk_ac_curso      FOREIGN KEY (curso_id)
        REFERENCES cursos(id) ON DELETE CASCADE
);
GO

-- ============================================================
--  TABLA: clases
-- ============================================================
IF OBJECT_ID('clases', 'U') IS NULL
CREATE TABLE clases (
    id          INT                 NOT NULL IDENTITY(1,1),
    curso_id    INT                 NOT NULL,
    titulo      VARCHAR(150)        NOT NULL,
    contenido   NVARCHAR(MAX)       NULL,
    orden_clase INT                 NULL,

    CONSTRAINT pk_clases        PRIMARY KEY (id),
    CONSTRAINT fk_clase_curso   FOREIGN KEY (curso_id)
        REFERENCES cursos(id) ON DELETE CASCADE
);
GO

-- ============================================================
--  TABLA: tareas
-- ============================================================
IF OBJECT_ID('tareas', 'U') IS NULL
CREATE TABLE tareas (
    id          INT             NOT NULL IDENTITY(1,1),
    clase_id    INT             NOT NULL,
    titulo      VARCHAR(150)    NULL,
    descripcion NVARCHAR(MAX)   NULL,

    CONSTRAINT pk_tareas        PRIMARY KEY (id),
    CONSTRAINT fk_tarea_clase   FOREIGN KEY (clase_id)
        REFERENCES clases(id) ON DELETE CASCADE
);
GO

-- ============================================================
--  TABLA: progreso_clase
-- ============================================================
IF OBJECT_ID('progreso_clase', 'U') IS NULL
CREATE TABLE progreso_clase (
    id          INT         NOT NULL IDENTITY(1,1),
    alumno_id   INT         NOT NULL,
    clase_id    INT         NOT NULL,
    completada  BIT         NOT NULL DEFAULT 0,
    fecha       DATETIME    NULL,

    CONSTRAINT pk_progreso_clase  PRIMARY KEY (id),
    CONSTRAINT uq_progreso        UNIQUE (alumno_id, clase_id),
    CONSTRAINT fk_pc_alumno       FOREIGN KEY (alumno_id)
        REFERENCES alumnos(id) ON DELETE CASCADE,
    CONSTRAINT fk_pc_clase        FOREIGN KEY (clase_id)
        REFERENCES clases(id) ON DELETE CASCADE
);
GO

-- ============================================================
--  DATOS SEMILLA: Cursos y Clases por defecto (Opcional)
-- ============================================================

-- cursos
IF NOT EXISTS (SELECT 1 FROM cursos)
BEGIN
    INSERT INTO cursos (nombre, categoria, dificultad) VALUES
    ('Logica de Programacion',  'Fundamentos',   'Basico'),
    ('Algoritmos',              'Fundamentos',   'Basico'),
    ('POO',                     'Programacion',  'Basico'),
    ('C# Basico',               'Backend',       'Basico'),
    ('WinForms',                'Desktop',       'Intermedio'),
    ('MySQL',                   'Base de Datos', 'Basico'),
    ('Git y GitHub',            'Herramientas',  'Basico'),
    ('APIs REST',               'Backend',       'Intermedio');
END
GO

-- clases
IF NOT EXISTS (SELECT 1 FROM clases)
BEGIN
    INSERT INTO clases (curso_id, titulo, contenido, orden_clase) VALUES
    (4, 'Variables',            'Tipos de datos y variables',   1),
    (4, 'Condicionales',        'Uso de if y switch',           2),
    (4, 'Bucles',               'For, while y foreach',         3),
    (6, 'Introduccion MySQL',   'Conceptos basicos MySQL',      1);
END
GO

-- ============================================================
--  VISTA: vw_ClasesCursos
-- ============================================================
IF OBJECT_ID('dbo.vw_ClasesCursos', 'V') IS NOT NULL
    DROP VIEW dbo.vw_ClasesCursos;
GO

CREATE VIEW dbo.vw_ClasesCursos
AS
SELECT
    c.nombre AS Curso,
    c.categoria,
    cl.titulo,
    cl.orden_clase
FROM clases cl
INNER JOIN cursos c
    ON cl.curso_id = c.id;
GO

-- ============================================================
--  FUNCION: fn_TotalUsuarios
-- ============================================================
IF OBJECT_ID('dbo.fn_TotalUsuarios', 'FN') IS NOT NULL
    DROP FUNCTION dbo.fn_TotalUsuarios;
GO

CREATE FUNCTION dbo.fn_TotalUsuarios()
RETURNS INT
AS
BEGIN
    DECLARE @Total INT;
    SELECT @Total = COUNT(*) FROM usuarios;
    RETURN @Total;
END;
GO

-- ============================================================
--  FUNCION: fn_CursosBasicos
-- ============================================================
IF OBJECT_ID('dbo.fn_CursosBasicos', 'TF') IS NOT NULL
    DROP FUNCTION dbo.fn_CursosBasicos;
GO

CREATE FUNCTION dbo.fn_CursosBasicos()
RETURNS TABLE
AS
RETURN
(
    SELECT id, nombre, categoria, dificultad
    FROM cursos
    WHERE dificultad = 'Basico'
);
GO

-- ============================================================
--  STORED PROCEDURE: sp_BuscarUsuarioCorreo
-- ============================================================
IF OBJECT_ID('dbo.sp_BuscarUsuarioCorreo', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_BuscarUsuarioCorreo;
GO

CREATE PROCEDURE dbo.sp_BuscarUsuarioCorreo
    @Correo VARCHAR(100)
AS
BEGIN
    SELECT id, nombre, apellido, correo, rango, tipo, activo
    FROM usuarios
    WHERE correo = @Correo;
END;
GO

-- ============================================================
--  STORED PROCEDURE: sp_CursosPorDificultad
-- ============================================================
IF OBJECT_ID('dbo.sp_CursosPorDificultad', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_CursosPorDificultad;
GO

CREATE PROCEDURE dbo.sp_CursosPorDificultad
    @Dificultad VARCHAR(20)
AS
BEGIN
    SELECT *
    FROM cursos
    WHERE dificultad = @Dificultad;
END;
GO

-- ============================================================
--  STORED PROCEDURE: sp_ObtenerAlumnos
-- ============================================================
IF OBJECT_ID('dbo.sp_ObtenerAlumnos', 'P') IS NOT NULL
    DROP PROCEDURE dbo.sp_ObtenerAlumnos;
GO

CREATE PROCEDURE dbo.sp_ObtenerAlumnos
AS
BEGIN
    SELECT u.id, u.nombre, u.apellido, u.correo, a.matricula
    FROM usuarios u
    INNER JOIN alumnos a ON a.usuario_id = u.id
    WHERE u.activo = 1
    ORDER BY u.apellido, u.nombre;
END
GO


-- ============================================================
--  TABLA: bitacora
--  Registra los cambios realizados en la tabla usuarios
-- ============================================================
IF OBJECT_ID('dbo.bitacora', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.bitacora (
        id              INT IDENTITY(1,1) NOT NULL,
        tabla           VARCHAR(100) NOT NULL,
        operacion       VARCHAR(20) NOT NULL,
        usuario_id      INT NULL,
        fecha           DATETIME NOT NULL DEFAULT GETDATE(),
        descripcion     VARCHAR(500) NULL,

        CONSTRAINT pk_bitacora PRIMARY KEY (id)
    );
END
GO

-- ============================================================
--  TRIGGER: trg_bitacora_usuarios
--  Registra INSERT, UPDATE y DELETE de usuarios
-- ============================================================
CREATE OR ALTER TRIGGER dbo.trg_bitacora_usuarios
ON dbo.usuarios
AFTER INSERT, UPDATE, DELETE
AS
BEGIN
    SET NOCOUNT ON;

    -- ========================================================
    -- INSERT
    -- ========================================================
    INSERT INTO dbo.bitacora
    (
        tabla,
        operacion,
        usuario_id,
        fecha,
        descripcion
    )
    SELECT
        'usuarios',
        'INSERT',
        i.id,
        GETDATE(),
        'Se creó un nuevo usuario.'
    FROM inserted i
    LEFT JOIN deleted d
        ON d.id = i.id
    WHERE d.id IS NULL;


    -- ========================================================
    -- UPDATE
    -- ========================================================
    INSERT INTO dbo.bitacora
    (
        tabla,
        operacion,
        usuario_id,
        fecha,
        descripcion
    )
    SELECT
        'usuarios',
        'UPDATE',
        i.id,
        GETDATE(),
        'Se modificó la información del usuario.'
    FROM inserted i
    INNER JOIN deleted d
        ON d.id = i.id;


    -- ========================================================
    -- DELETE
    -- ========================================================
    INSERT INTO dbo.bitacora
    (
        tabla,
        operacion,
        usuario_id,
        fecha,
        descripcion
    )
    SELECT
        'usuarios',
        'DELETE',
        d.id,
        GETDATE(),
        'Se eliminó un usuario.'
    FROM deleted d
    LEFT JOIN inserted i
        ON i.id = d.id
    WHERE i.id IS NULL;

END;
GO


-- ============================================================
-- TABLA: operaciones_sincronizadas
-- Registra las operaciones offline completadas en SQL Server.
-- ============================================================
IF OBJECT_ID('dbo.operaciones_sincronizadas', 'U') IS NULL
BEGIN
    CREATE TABLE dbo.operaciones_sincronizadas
    (
        operation_id UNIQUEIDENTIFIER NOT NULL,
        operation_type VARCHAR(50) NOT NULL,
        completed_at_utc DATETIME2 NOT NULL
            CONSTRAINT df_operaciones_sincronizadas_completed_at
            DEFAULT SYSUTCDATETIME(),

        CONSTRAINT pk_operaciones_sincronizadas
            PRIMARY KEY (operation_id)
    );
END
GO
