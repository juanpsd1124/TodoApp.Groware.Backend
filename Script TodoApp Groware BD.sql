CREATE DATABASE TodoGrowareBD

CREATE TABLE Estados(
	idEstado TINYINT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	descripcionEstado VARCHAR(20) NOT NULL)

INSERT INTO Estados VALUES ('Por Iniciar')
INSERT INTO Estados VALUES ('Iniciada')
INSERT INTO Estados VALUES ('En Proceso')
INSERT INTO Estados VALUES ('Terminada')

CREATE TABLE Tareas (
	idTarea SMALLINT IDENTITY (1,1) NOT NULL PRIMARY KEY,
	tituloTarea VARCHAR(100) NOT NULL,
	responsableTarea VARCHAR(100) NOT NULL,
	descripcionTarea VARCHAR(500) NOT NULL,
	estadoTarea TINYINT NOT NULL,
	duracionNum SMALLINT NULL,
	duracionTipo VARCHAR(15) NULL,
	fechaInicio DATETIME2 NULL,
	fechaFinal DATETIME2 NULL,
	
	FOREIGN KEY (estadoTarea) REFERENCES Estados(idEstado)
)

INSERT INTO Tareas VALUES ('Tarea de Prueba BD', 'Juan Posada'   ,'Descripcion 1', 1 , 1, 'Hora', GETDATE(), '2023-05-04 09:50:00'  )
INSERT INTO Tareas VALUES ('Tarea de Prueba 2 BD', 'Juan Posada' ,'Descripcion 2', 2 , 30, 'Minutos', GETDATE(), '2023-05-04 10:00:00' )
INSERT INTO Tareas VALUES ('Tarea de Prueba 3 BD', 'Juan Posada' ,'Descripcion 3', 3 , 5, 'Dias', GETDATE(), '2023-05-10 09:50:00')

CREATE PROCEDURE AgregarTarea (
	@titulo VARCHAR(100),
	@descripcion VARCHAR(500),
	@responsable VARCHAR(100),
	@estado TINYINT,
	@duracionNum SMALLINT,
	@duracionTipo VARCHAR(15),
	@fechaInicio DATETIME2,
	@fechaFinal DATETIME2

)
AS

	INSERT INTO Tareas VALUES (@titulo, @descripcion, @responsable, @estado, @duracionNum, @duracionTipo, @fechaInicio, @fechaFinal ) 
	SELECT Tareas.idTarea, 
		   Tareas.tituloTarea AS Titulo, 
		   Tareas.descripcionTarea AS Descripcion, 
		   Tareas.responsableTarea AS Responsable, 
		   Estados.descripcionEstado AS Estado, 
		   Tareas.duracionNum,
		   Tareas.duracionTipo,
		   --CONCAT(Tareas.duracionNum, ' ' , Tareas.duracionTipo) AS Duracion,
		   Tareas.fechaInicio AS FechaInicio,
		   Tareas.fechaFinal AS FechaFinal
	FROM Tareas
	INNER JOIN Estados ON Tareas.estadoTarea = Estados.idEstado WHERE idTarea = SCOPE_IDENTITY() 
GO

-- EXEC AgregarTarea 'Tarea de Prueba 4 BD' , 'Juan Posada' ,'Descripcion 1', 0 , 1, 'Hora', '2023-05-04 12:00:00', '2023-05-04 14:00:00'  


CREATE PROCEDURE ModificarTarea (
	@idTarea SMALLINT,
	@titulo VARCHAR(100),
	@descripcion VARCHAR(500),
	@responsable VARCHAR(100),
	@estado TINYINT,
	@duracionNum SMALLINT,
	@duracionTipo VARCHAR(15),
	@fechaInicio DATETIME2,
	@fechaFinal DATETIME2

)
AS

	UPDATE Tareas SET 
		   tituloTarea = @titulo, 
		   descripcionTarea = @descripcion,
		   responsableTarea = @responsable,
		   estadoTarea =	  @estado,
		   duracionNum = @duracionNum,
		   duracionTipo = @duracionTipo,
		   fechaInicio = @fechaInicio,
		   fechaFinal = @fechaFinal  WHERE @idTarea = idTarea

	SELECT Tareas.idTarea, 
		   Tareas.tituloTarea AS Titulo, 
		   Tareas.descripcionTarea AS Descripcion, 
		   Tareas.responsableTarea AS Responsable, 
		   Estados.descripcionEstado AS Estado, 
		   Tareas.duracionNum,
		   Tareas.duracionTipo,
		   --CONCAT(Tareas.duracionNum, ' ' , Tareas.duracionTipo) AS Duracion,
		   Tareas.fechaInicio AS FechaInicio,
		   Tareas.fechaFinal AS FechaFinal
	FROM Tareas
	INNER JOIN Estados ON Tareas.estadoTarea = Estados.idEstado WHERE Tareas.idTarea = @idTarea
GO

-- EXEC ModificarTarea 1,'Titulo Modificado', 'Descripcion Modificada', 'Juan', 2, 32, 'Horas', '2023-05-04 12:00:00' , '2023-05-04 18:00:00' 

CREATE PROCEDURE EliminarTarea ( @idTarea SMALLINT )
AS
	DELETE FROM Tareas WHERE @idTarea = idTarea
GO

-- EXEC EliminarTarea 3

CREATE PROCEDURE ObtenerTareas
AS
	SELECT Tareas.idTarea, 
		   Tareas.tituloTarea AS Titulo, 
		   Tareas.descripcionTarea AS Descripcion, 
		   Tareas.responsableTarea AS Responsable, 
		   Estados.descripcionEstado AS Estado, 
		   Tareas.duracionNum,
		   Tareas.duracionTipo,
		   --CONCAT(Tareas.duracionNum, ' ' , Tareas.duracionTipo) AS Duracion,
		   Tareas.fechaInicio AS FechaInicio,
		   Tareas.fechaFinal AS FechaFinal
	FROM Tareas
	INNER JOIN Estados ON Tareas.estadoTarea = Estados.idEstado
	FOR JSON PATH
	
GO
-- EXEC ObtenerTareas
