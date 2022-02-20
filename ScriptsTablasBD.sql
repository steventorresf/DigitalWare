USE master
GO
IF NOT EXISTS (SELECT* FROM SYS.databases D WHERE D.name = 'ErpDigitalWareDB') BEGIN
	CREATE DATABASE ErpDigitalWareDB;
END
GO

USE ErpDigitalWareDB
GO

IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.Tables T WHERE T.TABLE_NAME = 'FacturaDetalle') BEGIN
	DROP TABLE FacturaDetalle;
END
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.Tables T WHERE T.TABLE_NAME = 'Factura') BEGIN
	DROP TABLE Factura;
END
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.Tables T WHERE T.TABLE_NAME = 'Producto') BEGIN
	DROP TABLE Producto;
END
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.Tables T WHERE T.TABLE_NAME = 'Cliente') BEGIN
	DROP TABLE Cliente;
END
IF EXISTS (SELECT* FROM INFORMATION_SCHEMA.Tables T WHERE T.TABLE_NAME = 'Secuencia') BEGIN
	DROP TABLE Secuencia;
END

GO
CREATE TABLE Secuencia (
	IdSecuencia int identity(1,1) NOT NULL,
	CodigoSecuencia nvarchar(50) NOT NULL,
	DescripcionSecuencia nvarchar(200) NOT NULL,
	NoSecuencia int NOT NULL,

	CONSTRAINT PK_Secuencia PRIMARY KEY (IdSecuencia)
)

GO
CREATE TABLE Cliente (
	IdCliente int identity(1,1) NOT NULL,
	Identificacion nvarchar(50) NOT NULL,
	Nombre nvarchar(100) NOT NULL,
	Apellido nvarchar(100) NOT NULL,
	Telefono nvarchar(100) NOT NULL,
	FechaNacimiento datetime NOT NULL,

	CONSTRAINT PK_Cliente PRIMARY KEY (IdCliente)
)

GO
CREATE TABLE Producto (
	IdProducto int identity(1,1) NOT NULL,
	Nombre nvarchar(100) NOT NULL,
	ValorUnitario numeric NOT NULL,
	Existencia numeric NOT NULL,

	CONSTRAINT PK_Producto PRIMARY KEY (IdProducto)
)

GO
CREATE TABLE Factura (
	IdFactura int identity(1,1) NOT NULL,
	NoFactura int NOT NULL,
	IdCliente int NOT NULL,
	FechaVenta datetime NOT NULL,

	CONSTRAINT PK_Factura PRIMARY KEY (IdFactura),
	CONSTRAINT UQ_Factura_001 UNIQUE (NoFactura),
	CONSTRAINT FK_Factura_001 FOREIGN KEY (IdCliente) REFERENCES Cliente(IdCliente)
)

GO
CREATE TABLE FacturaDetalle (
	IdFacturaDetalle int identity(1,1) NOT NULL,
	IdFactura int NOT NULL,
	IdProducto int NOT NULL,
	Cantidad numeric NOT NULL,
	ValorUnitario numeric NOT NULL,

	CONSTRAINT PK_FacturaDetalle PRIMARY KEY (IdFacturaDetalle),
	CONSTRAINT FK_FacturaDetalle_001 FOREIGN KEY (IdFactura) REFERENCES Factura(IdFactura),
	CONSTRAINT FK_FacturaDetalle_002 FOREIGN KEY (IdProducto) REFERENCES Producto(IdProducto)
)

GO
INSERT INTO Secuencia (CodigoSecuencia, DescripcionSecuencia, NoSecuencia)
VALUES ('NoFactura', 'Consecutivo del numero de factura', 0);