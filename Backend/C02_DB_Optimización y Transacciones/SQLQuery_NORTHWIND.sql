
-- PRÁCTICA SQL - BASE DE DATOS NORTHWIND
-- Giannetto, Karen :)


-- 1) Clientes ordenados alfabéticamente por compañía
-- ORDER BY: Ordena los resultados
-- ASC: Orden ascendente (A-Z) - es el valor por defecto

SELECT *
FROM Customers
ORDER BY CompanyName ASC;


-- 2) Clientes cuyo nombre empieza con "S"
-- LIKE: Operador para búsquedas con patrones
-- 'S%': El % significa "cualquier cosa después de S"
-- '%S': Termina con S | '%S%': Contiene S en cualquier posición

SELECT *
FROM Customers
WHERE CompanyName LIKE 'S%';


-- 3) Productos con precio unitario mayor a 50
SELECT *
FROM Products
WHERE UnitPrice > 50;


-- 4) Cantidad de productos descontinuados
-- COUNT(*): Cuenta el número de filas
-- Discontinued = 1: En SQL Server, 1 = verdadero, 0 = falso

SELECT COUNT(*) as ProductosDescontinuados
FROM Products
WHERE Discontinued = 1;

-- 5) Producto de mayor valor unitario
-- MAX(): Función que retorna el valor máximo

SELECT MAX(UnitPrice) as PrecioMaximo
FROM Products;


-- 6) Producto de mayor valor unitario con nombre
-- La subconsulta se ejecuta primero y su resultado se usa para filtrar
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice = (
    SELECT MAX(UnitPrice)
    FROM Products
);


-- 7) Productos con nombre de categoría (INNER JOIN)
-- INNER JOIN: Solo muestra registros que tienen coincidencias en ambas tablas
-- p y c son alias para las tablas (hace el código más legible)

SELECT p.ProductName, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID;

-- 8) Clientes con detalles de pedidos (LEFT JOIN)
-- LEFT JOIN: Muestra TODOS los clientes, aunque no tengan pedidos
-- Si un cliente no tiene pedidos, los campos de Orders aparecen como NULL

SELECT c.CustomerID, c.CompanyName, o.OrderID, o.OrderDate
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
ORDER BY c.CompanyName;


-- 9) Total de órdenes por cliente
-- GROUP BY: Agrupa los resultados por cliente
-- COUNT(o.OrderID): Cuenta las órdenes por cada cliente
-- Todos los campos en SELECT que no sean funciones deben estar en GROUP BY

SELECT c.CustomerID, c.CompanyName, COUNT(o.OrderID) as TotalOrdenes
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CompanyName
ORDER BY TotalOrdenes DESC;


-- 10) Proveedores con más de 3 productos
-- HAVING: Se usa con GROUP BY para filtrar grupos (no filas individuales)
-- WHERE filtra filas antes de agrupar, HAVING filtra después de agrupar

SELECT s.SupplierID, s.CompanyName, COUNT(p.ProductID) as TotalProductos
FROM Suppliers s
INNER JOIN Products p ON s.SupplierID = p.SupplierID
GROUP BY s.SupplierID, s.CompanyName
HAVING COUNT(p.ProductID) > 3
ORDER BY TotalProductos DESC;


-- 11) Procedimiento almacenado para clientes por país
-- @Pais: Parámetro de entrada del procedimiento
-- GO: Separa lotes de comandos SQL

GO -- sin ese GO me tira error

CREATE PROCEDURE ObtenerClientesPorPais_v2  -- _v2 porque me dice que el nombre ya esta duplicado en bd
    @Pais varchar(50)
AS
BEGIN
    SELECT CustomerID, CompanyName, City, Country
    FROM Customers
    WHERE Country = @Pais
    ORDER BY CompanyName
END
GO

-- Para ejecutar el procedimiento:
-- EXEC: Ejecuta el procedimiento almacenado
EXEC ObtenerClientesPorPais @Pais = 'Germany';



/* 
CONCEPTOS CLAVE:
- ORDER BY: Ordenamiento de resultados
- WHERE: Filtrado de filas
- LIKE: Búsquedas con patrones
- COUNT, MAX, MIN, SUM, AVG: Funciones de agregación
- INNER JOIN: Unión que muestra solo coincidencias
- LEFT JOIN: Unión que preserva todos los registros de la tabla izquierda
- GROUP BY: Agrupamiento de resultados
- HAVING: Filtrado de grupos
- Subconsultas: Consultas anidadas
- Procedimientos almacenados: Código SQL reutilizable
*/