CREATE DATABASE TechEmpire
GO
USE TechEmpire
GO


CREATE TABLE Productos(
CodigoProducto int PRIMARY KEY,
Nombre varchar(50) NOT NULL,
Descripcion varchar(150) NOT NULL,
Marca varchar(50) NOT NULL,
Color varchar(50),
ImgUrl varchar(150),
Precio float NOT NULL,
Stock smallint NOT NULL,
StockMinimo smallint,
StockMaximo smallint,
Activo bit
)


CREATE TABLE Roles
(
CodRol INT PRIMARY KEY IDENTITY(1,1),
Nombre VARCHAR(50)
)
GO


CREATE TABLE Usuarios(
NombreUsuario varchar(50) PRIMARY KEY,
DNI INT UNIQUE NOT NULL,
Nombre varchar(50) NOT NULL,
Apellido varchar(50) NOT NULL,
Mail varchar(100) NOT NULL,
Clave varchar(100) NOT NULL,
Rol INT FOREIGN KEY REFERENCES Roles(CodRol),
Bloqueo bit,
Activo bit,
ContFallidos smallint
);



CREATE TABLE Eventos(
CodEvento BIGINT PRIMARY KEY IDENTITY(1,1),
NombreUsuario varchar(50) FOREIGN KEY REFERENCES Usuarios(NombreUsuario),
Modulo varchar(50),
Evento varchar(100),
Criticiad smallint,
Fecha varchar(11),
Hora varchar(5),
)
GO


GO
CREATE PROCEDURE ValidarUsuario
    @NombreUsuario varchar(50),
	@DNI int,
	@Email varchar(50)
AS
BEGIN
    SELECT * FROM Usuarios U 
	INNER JOIN Roles R ON U.Rol = R.CodRol
	WHERE NombreUsuario = @NombreUsuario OR DNI = @DNI OR Mail = @Email

END
GO

CREATE PROCEDURE ModificarContFallido
    @NombreUsuario varchar(50),
	@ContClaveIncorrecta smallint
AS
BEGIN
    UPDATE Usuarios SET ContFallidos = @ContClaveIncorrecta where NombreUsuario = @NombreUsuario;
END
GO

CREATE PROCEDURE ModificarBloquearUsuario
    @DNI int,
	@Bloqueo bit
AS
BEGIN

    UPDATE Usuarios SET Bloqueo= @Bloqueo WHERE DNI = @DNI;
END
GO


CREATE PROCEDURE RegistrarEvento
    @NombreUsuario varchar(50),
	@Modulo varchar(50),
	@Evento varchar(100),
	@Criticidad smallint,
	@Fecha varchar(11),
	@Hora varchar(5)
AS
BEGIN
    INSERT INTO Eventos VALUES (@NombreUsuario, @Modulo, @Evento, @Criticidad, @Fecha, @Hora)
END
GO




INSERT INTO Productos VALUES
(1, 'RTX 3090 NVIDIA MSI', 'Tama�o de la memoria: 24 GB GDDR6X', 'NVIDIA MSI', 'Negro', '', 1700000, 30, 20, 50, 1),
( 2, 'Teclado Razer', 'Switch Red','Razer', 'Negro', '', 200000, 30, 20, 50, 1);


INSERT INTO Roles VALUES('Admin')
INSERT INTO Roles VALUES('WebMaster')
INSERT INTO Roles VALUES('Cliente')
INSERT INTO Roles VALUES('Empleado')

--clave= clave123
INSERT INTO Usuarios VALUES ('Admin', 12345678, 'Admin', 'Admin', 'admin@gmail.com', '5ac0852e770506dcd80f1a36d20ba7878bf82244b836d9324593bd14bc56dcb5', 1, 0, 1,0);

INSERT INTO Usuarios VALUES ('GustavoPerez', 33445566, 'Gustavo', 'Perez', 'gustavoperez@gmail.com', '5ac0852e770506dcd80f1a36d20ba7878bf82244b836d9324593bd14bc56dcb5', 2, 0, 1,0);

INSERT INTO Usuarios VALUES ('EstebanRodriguez', 42134823, 'Esteban', 'Rodriguez', 'estebanrodriguez@gmail.com', '5ac0852e770506dcd80f1a36d20ba7878bf82244b836d9324593bd14bc56dcb5', 3, 0, 1,0);

INSERT INTO Usuarios VALUES ('FacundoDiaz', 39256827, 'Facundo', 'Diaz', 'facundodiaz@gmail.com', '5ac0852e770506dcd80f1a36d20ba7878bf82244b836d9324593bd14bc56dcb5', 4, 0, 1,0);