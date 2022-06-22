CREATE DATABASE BD_PELICULAS2


CREATE TABLE PELICULAS(
ID INT PRIMARY KEY IDENTITY(1,1),
Titulo VARCHAR(75) NOT NULL,
Director VARCHAR(50) NOT NULL, 
Categoria VARCHAR(50) NOT NULL,
Calificacion INT NOT NULL CHECK (Calificacion>0 AND Calificacion<=10),
FechaEstreno DATE NOT NULL CHECK (FechaEstreno < GETDATE())
)


CREATE PROCEDURE ListarPeliculas
AS 
BEGIN 
SELECT * FROM PELICULAS
END


CREATE PROCEDURE ListarCategorias
AS
BEGIN
SELECT * FROM CATEGORIAS
END


CREATE PROCEDURE AgregarPelicula(
@Titulo varchar(75),
@Director varchar(50),
@Categoria varchar(50),
@Calificacion int,
@FechaEstreno date
)
AS
BEGIN
	INSERT INTO PELICULAS(Titulo, Director, Categoria, Calificacion, FechaEstreno) VALUES (@Titulo, @Director, @Categoria, @Calificacion, @FechaEstreno)
END




CREATE PROCEDURE Editar(
@Id int, 
@Titulo varchar(75),
@Director varchar(50),
@Categoria varchar(50),
@Calificacion int,
@FechaEstreno date
)
AS 
BEGIN 
	UPDATE PELICULAS SET Titulo = @Titulo, Director = @Director, Categoria = @Categoria, Calificacion = @Calificacion, FechaEstreno = @FechaEstreno WHERE ID = @Id
END

CREATE PROCEDURE Obtener(
@Id int
)
AS 
BEGIN 
SELECT * FROM PELICULAS WHERE ID = @Id
END


CREATE PROCEDURE Eliminar(
@Id int
)
AS BEGIN
DELETE FROM PELICULAS WHERE ID = @Id
END


CREATE PROCEDURE FiltrarPorTitulo(
@Cadena varchar(75)
)
AS
BEGIN
SELECT * FROM PELICULAS WHERE Titulo LIKE '%'+ @Cadena +'%'
END



