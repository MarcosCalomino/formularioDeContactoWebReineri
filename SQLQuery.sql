CREATE DATABASE bddForumularioPedidos

USE bddForumularioPedidos

CREATE TABLE tipoDisposicion(
IdTipoDisposicion INT PRIMARY KEY IDENTITY(1,1),
descripcion VARCHAR(50)
)

INSERT INTO tipoDisposicion(descripcion)
VALUES ('Un eje'),
	   ('Dos ejes adelante'),
	   ('Dos ejes, uno adelante uno atras'),
	   ('Un eje cuatro ruedas'),
	   ('Tres ejes'),
	   ('Tres ejes, uno adelante dos atras')

CREATE TABLE tipoLlanta(
IdTipoLlanta INT PRIMARY KEY IDENTITY(1,1),
descripcion VARCHAR(50)
)

INSERT INTO tipoLlanta(descripcion)
VALUES ('Simple'),
	   ('Dual')

CREATE TABLE pedido (
    IdPedido INT PRIMARY KEY IDENTITY(1,1),
    nombreCliente VARCHAR(50),
    localidad VARCHAR(100),
    email VARCHAR(50),
    telefono VARCHAR(50),
    capacidadDeCarga DECIMAL(10, 2),
    trochaDelEje DECIMAL(10, 2),
    datosAdicionales VARCHAR(MAX),
    IdTipoDisposicion INT,
    IdTipoLlanta INT,
    FOREIGN KEY (IdTipoDisposicion) REFERENCES tipoDisposicion(IdTipoDisposicion),
    FOREIGN KEY (IdTipoLlanta) REFERENCES tipoLlanta(IdTipoLlanta)
);




CREATE PROCEDURE sp_GetOneTD(
@ID INT
)
AS
BEGIN
	SELECT * FROM tipoDisposicion
	WHERE IdTipoDisposicion = @ID 
END


CREATE PROCEDURE sp_GetOneTL(
@ID INT
)
AS
BEGIN
	SELECT * FROM tipoLlanta
	WHERE IdTipoLlanta = @ID
END


CREATE PROCEDURE sp_createPedido(
@nombreCliente VARCHAR(50),
@localidad VARCHAR(100),
@email VARCHAR(50),
@telefono VARCHAR(50),
@capacidadDeCarga DECIMAL(10,2),
@trochaDelEje DECIMAL(10,2),
@datosAdicionales VARCHAR(MAX),
@idTipoDisposicion INT,
@idTipoLlanta INT
)
AS
BEGIN
	INSERT INTO pedido(nombreCliente, localidad, email, telefono, capacidadDeCarga, trochaDelEje, datosAdicionales, IdTipoDisposicion, IdTipoLlanta)
	VALUES (@nombreCliente, @localidad, @email, @telefono, @capacidadDeCarga, @trochaDelEje, @datosAdicionales, @idTipoDisposicion, @idTipoLlanta)
END

SELECT * FROM pedido


