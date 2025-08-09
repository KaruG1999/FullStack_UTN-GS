# Práctica SQL - Ejercicios Resueltos

## Ejercicios DDL (Data Definition Language)

### 1) Crear una base de datos
```sql
CREATE DATABASE MiBancoDB
GO

USE MiBancoDB
GO
```

### 2) Crear las tablas

#### a) Tabla "Cuentas"
```sql
CREATE TABLE Cuentas (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    Descripcion varchar(50) NOT NULL,
    Saldo decimal(18,2) NOT NULL
)
```

**Explicación:**
- `IDENTITY(1,1)`: Autoincremento que empieza en 1 y aumenta de 1 en 1
- `decimal(18,2)`: 18 dígitos totales, 2 después del punto decimal
- `PRIMARY KEY`: Define ID como clave primaria

#### b) Tabla "Transacciones"
```sql
CREATE TABLE Transacciones (
    ID int NOT NULL IDENTITY(1,1) PRIMARY KEY,
    CuentaID int NOT NULL,
    Monto decimal(18,2) NOT NULL,
    Fecha datetime NOT NULL,
    DescripcionMotivo varchar(100),
    FOREIGN KEY (CuentaID) REFERENCES Cuentas(ID)
)
```

**Explicación:**
- `FOREIGN KEY`: Establece relación con la tabla Cuentas
- `REFERENCES Cuentas(ID)`: Especifica que CuentaID debe existir en Cuentas

### 3) Agregar columna "Nombre" a Cuentas
```sql
ALTER TABLE Cuentas
ADD Nombre varchar(50)
```

### 4) Cambiar longitud del campo varchar de 50 a 70
```sql
ALTER TABLE Cuentas
ALTER COLUMN Nombre varchar(70)
```

### 5) Eliminar columna DescripcionMotivo de Transacciones
```sql
ALTER TABLE Transacciones
DROP COLUMN DescripcionMotivo
```

---

## Ejercicios DML (Data Manipulation Language)

### 1) Insertar 3 registros en tabla "Cuentas"
```sql
INSERT INTO Cuentas (Descripcion, Saldo, Nombre) VALUES
('Cuenta Corriente', 15000.50, 'Juan Pérez'),
('Cuenta Ahorro', 25000.75, 'María González'),
('Cuenta Empresarial', 50000.00, 'Empresa XYZ')
```

**Explicación:**
- Se insertan 3 registros de una vez usando VALUES múltiples
- El ID se genera automáticamente por IDENTITY

### 2) Modificar campo descripción donde ID = 1
```sql
UPDATE Cuentas
SET Descripcion = 'Cuenta Corriente Premium'
WHERE ID = 1
```

**Explicación:**
- `UPDATE`: Comando para modificar registros existentes
- `SET`: Especifica qué campo modificar y su nuevo valor
- `WHERE`: Condición para especificar qué registro modificar

### 3) Eliminar cuenta con ID = 3
```sql
DELETE FROM Cuentas
WHERE ID = 3
```

**¡Cuidado!** Si no pones WHERE, eliminarás TODOS los registros.

---

## Consultas con Base de Datos Northwind

> **Nota:** Para estos ejercicios necesitas descargar la base de datos Northwind del enlace proporcionado por tu profesor.

### 1) Clientes ordenados alfabéticamente por compañía
```sql
SELECT *
FROM Customers
ORDER BY CompanyName ASC
```

**Explicación:**
- `ORDER BY`: Ordena los resultados
- `ASC`: Orden ascendente (A-Z) - es el valor por defecto

### 2) Clientes cuyo nombre empieza con "S"
```sql
SELECT *
FROM Customers
WHERE CompanyName LIKE 'S%'
```

**Explicación:**
- `LIKE`: Operador para búsquedas con patrones
- `'S%'`: El % significa "cualquier cosa después de S"
- `'%S'`: Termina con S
- `'%S%'`: Contiene S en cualquier posición

### 3) Productos con precio unitario mayor a 50
```sql
SELECT *
FROM Products
WHERE UnitPrice > 50
```

### 4) Cantidad de productos descontinuados
```sql
SELECT COUNT(*) as ProductosDescontinuados
FROM Products
WHERE Discontinued = 1
```

**Explicación:**
- `COUNT(*)`: Cuenta el número de filas
- `Discontinued = 1`: En SQL Server, 1 = verdadero, 0 = falso

### 5) Producto de mayor valor unitario
```sql
SELECT MAX(UnitPrice) as PrecioMaximo
FROM Products
```

### 6) Producto de mayor valor unitario con nombre (Subquery)
```sql
SELECT ProductName, UnitPrice
FROM Products
WHERE UnitPrice = (
    SELECT MAX(UnitPrice)
    FROM Products
)
```

**Explicación:**
- La subconsulta `(SELECT MAX(UnitPrice) FROM Products)` se ejecuta primero
- Luego se usa ese resultado para filtrar en la consulta principal

### 7) Productos con nombre de categoría (INNER JOIN)
```sql
SELECT p.ProductName, c.CategoryName
FROM Products p
INNER JOIN Categories c ON p.CategoryID = c.CategoryID
```

**Explicación:**
- `p` y `c` son alias para las tablas (hace el código más legible)
- `INNER JOIN`: Solo muestra registros que tienen coincidencias en ambas tablas

### 8) Clientes con detalles de pedidos (LEFT JOIN)
```sql
SELECT c.CustomerID, c.CompanyName, o.OrderID, o.OrderDate
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
ORDER BY c.CompanyName
```

**Explicación:**
- `LEFT JOIN`: Muestra TODOS los clientes, aunque no tengan pedidos
- Si un cliente no tiene pedidos, los campos de Orders aparecen como NULL

### 9) Total de órdenes por cliente
```sql
SELECT c.CustomerID, c.CompanyName, COUNT(o.OrderID) as TotalOrdenes
FROM Customers c
LEFT JOIN Orders o ON c.CustomerID = o.CustomerID
GROUP BY c.CustomerID, c.CompanyName
ORDER BY TotalOrdenes DESC
```

**Explicación:**
- `GROUP BY`: Agrupa los resultados por cliente
- `COUNT(o.OrderID)`: Cuenta las órdenes por cada cliente
- Todos los campos en SELECT que no sean funciones de agregación deben estar en GROUP BY

### 10) Proveedores con más de 3 productos
```sql
SELECT s.SupplierID, s.CompanyName, COUNT(p.ProductID) as TotalProductos
FROM Suppliers s
INNER JOIN Products p ON s.SupplierID = p.SupplierID
GROUP BY s.SupplierID, s.CompanyName
HAVING COUNT(p.ProductID) > 3
ORDER BY TotalProductos DESC
```

**Explicación:**
- `HAVING`: Se usa con GROUP BY para filtrar grupos (no filas individuales)
- `WHERE` filtra filas antes de agrupar, `HAVING` filtra después de agrupar

### 11) Procedimiento almacenado para clientes por país
```sql
CREATE PROCEDURE ObtenerClientesPorPais
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
EXEC ObtenerClientesPorPais @Pais = 'Germany'
```

**Explicación:**
- `@Pais`: Parámetro de entrada del procedimiento
- `GO`: Separa lotes de comandos SQL
- `EXEC`: Ejecuta el procedimiento almacenado

---

## Comandos de Verificación Útiles

### Ver estructura de una tabla
```sql
EXEC sp_help 'Cuentas'
```

### Ver datos de una tabla
```sql
SELECT TOP 10 * FROM Cuentas
```

### Ver todas las tablas de la base de datos
```sql
SELECT TABLE_NAME
FROM INFORMATION_SCHEMA.TABLES
WHERE TABLE_TYPE = 'BASE TABLE'
```

---

## Consejos para la Práctica

1. **Siempre usa WHERE en UPDATE y DELETE** para evitar modificar toda la tabla
2. **Haz backup antes de operaciones importantes**
3. **Usa nombres descriptivos para campos y tablas**
4. **Los comentarios en SQL se hacen con --**
5. **Practica con datos de prueba antes de trabajar con datos reales**

---

**Recuerda:** Estos ejercicios son la base. SQL tiene muchísimas funcionalidades adicionales que irás aprendiendo gradualmente. ¡La práctica constante es la clave del éxito!