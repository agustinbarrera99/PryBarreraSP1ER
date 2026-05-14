-- ============================================================
--  Script de creación de base de datos
--  Proyecto: PryBarreraSP1ER - Gestión de Médicos y Especialidades
--  Motor:    SQL Server / LocalDB
-- ============================================================

-- 1. Crear la base de datos (ejecutá este bloque primero,
--    separado del resto, o usá el botón "Execute" dos veces)
CREATE DATABASE GestionMedicos;
GO

-- 2. Usar la base de datos recién creada
USE GestionMedicos;
GO

-- 3. Tabla Especialidades
CREATE TABLE Especialidades (
    IdEspecialidad  INT          NOT NULL,
    Nombre          VARCHAR(255) NOT NULL,
    CONSTRAINT PK_Especialidades PRIMARY KEY (IdEspecialidad)
);
GO

-- 4. Tabla Medicos
CREATE TABLE Medicos (
    Matricula       INT          NOT NULL,
    Nombre          VARCHAR(255) NOT NULL,
    IdEspecialidad  INT          NOT NULL,
    CONSTRAINT PK_Medicos      PRIMARY KEY (Matricula),
    CONSTRAINT FK_Medicos_Esp  FOREIGN KEY (IdEspecialidad)
        REFERENCES Especialidades (IdEspecialidad)
);
GO

-- ============================================================
--  Datos de prueba opcionales (podés borrar este bloque)
-- ============================================================
INSERT INTO Especialidades (IdEspecialidad, Nombre) VALUES
    (1, 'Cardiología'),
    (2, 'Pediatría'),
    (3, 'Neurología');

INSERT INTO Medicos (Matricula, Nombre, IdEspecialidad) VALUES
    (1001, 'Dr. Juan Pérez',    1),
    (1002, 'Dra. María López',  2),
    (1003, 'Dr. Carlos Gómez',  1);
GO