USE ErpDigitalWareDB
GO

GO
CREATE OR ALTER PROCEDURE Sp_ListadoPreciosProductos
AS
BEGIN
	SELECT P.IdProducto, P.Nombre, P.ValorUnitario
	FROM Producto P
END

GO
CREATE OR ALTER PROCEDURE Sp_ListadoProductosExistenciaMinima
AS
BEGIN
	SELECT P.IdProducto, P.Nombre, P.ValorUnitario
	FROM Producto P
	WHERE P.Existencia <= 5
END

GO
CREATE OR ALTER PROCEDURE Sp_ListadoClientesNoMayores
AS
BEGIN
	SELECT C.IdCliente, C.Nombre, C.Apellido
	FROM Cliente C INNER JOIN
		 Factura F ON C.IdCliente = F.IdFactura
	WHERE DATEPART(YEAR, DATEADD(YEAR, -35, GETDATE())) <= DATEPART(YEAR, C.Fechanacimiento) AND
		  F.FechaVenta BETWEEN '20000201' AND '20000525 23:59:59'
END

GO
CREATE OR ALTER PROCEDURE Sp_ListadoTotalVendidoPorProducto (@Anio int)
AS
BEGIN
	SELECT P.IdProducto, P.Nombre, SUM(FD.Cantidad * FD.ValorUnitario) TotalVendido
	FROM Producto P INNER JOIN
		 FacturaDetalle FD ON P.IdProducto = FD.IdProducto INNER JOIN
		 Factura F ON FD.IdFactura = F.IdFactura
	WHERE DATEPART(YEAR, F.FechaVenta) = @Anio
	GROUP BY P.IdProducto, P.Nombre
END

GO
CREATE OR ALTER PROCEDURE Sp_UltimaFechaCompraCliente (@IdCliente int)
AS
BEGIN
	DECLARE @Tab table (IdCliente int, PrimeraCompra datetime, UltimaCompra datetime, NoCompras int, Rango int, Frecuencia int, ProximaCompra datetime)

	INSERT @Tab (PrimeraCompra, UltimaCompra, NoCompras)
	SELECT MIN(F.FechaVenta), MAX(F.FechaVenta), COUNT(0)
	FROM Factura F
	WHERE F.IdCliente = @IdCliente

	UPDATE @Tab
	SET Rango = DATEDIFF(DAY, PrimeraCompra, UltimaCompra)

	UPDATE @Tab
	SET Frecuencia = Rango / NoCompras

	UPDATE @Tab
	SET ProximaCompra = DATEADD(DAY, Frecuencia, UltimaCompra)

	SELECT @IdCliente AS IdCliente, T.UltimaCompra, T.ProximaCompra
	FROM @Tab T
	WHERE T.ProximaCompra IS NOT NULL
END

GO
EXEC Sp_ListadoPreciosProductos
EXEC Sp_ListadoProductosExistenciaMinima
EXEC Sp_ListadoClientesNoMayores
EXEC Sp_ListadoTotalVendidoPorProducto 2000
EXEC Sp_UltimaFechaCompraCliente 1