CREATE DATABASE CRUD

USE CRUD

CREATE TABLE Telefonos(
	Id_Telefono INT,
	LugarTelefono VARCHAR(20),
	PRIMARY KEY (Id_Telefono)
);

INSERT INTO Telefonos (Id_Telefono, LugarTelefono) 
VALUES (1, 'Casa'), (2, 'Trabajo'), (3, 'ContactoEmergencia');

CREATE TABLE Estudiantes(
	Id_Estudiante INT IDENTITY(1,1),
	Nombre VARCHAR(50),
	Promedio FLOAT,
	Telefono INT,
	Id_Telefono INT,
	PRIMARY KEY (Id_Estudiante),
	FOREIGN KEY (Id_Telefono) REFERENCES Telefonos(Id_Telefono)
);

CREATE PROCEDURE sp_load
AS BEGIN
SELECT * FROM Estudiantes
END

CREATE PROCEDURE sp_create
@Nombre VARCHAR(50),
@Promedio FLOAT,
@Telefono INT,
@Id_Telefono INT
AS BEGIN
INSERT INTO Estudiantes VALUES (@Nombre, @Promedio, @Telefono, @Id_Telefono)
END

CREATE PROCEDURE sp_read
@Id INT
AS BEGIN
SELECT * FROM Estudiantes WHERE Id_Estudiante=@Id
END

CREATE PROCEDURE sp_update
@Id int,
@Nombre VARCHAR(50),
@Promedio FLOAT,
@Telefono INT,
@Id_Telefono INT
AS BEGIN
UPDATE Estudiantes SET Nombre=@Nombre, Promedio=@Promedio, Telefono=@Telefono, Id_Telefono=@Id_Telefono
WHERE Id_Estudiante=@Id
END

CREATE PROCEDURE sp_delete
@Id INT
AS BEGIN
DELETE FROM Estudiantes WHERE Id_Estudiante=@Id
END

SELECT * FROM Estudiantes

SELECT * FROM Telefonos