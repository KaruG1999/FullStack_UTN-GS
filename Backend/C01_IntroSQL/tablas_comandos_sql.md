# Tablas de Referencia Rápida - Comandos SQL Esenciales

## 🏗️ Comandos DDL (Data Definition Language)

### Comandos Principales

| Comando | Propósito | Sintaxis Básica | Ejemplo |
|---------|-----------|----------------|---------|
| **CREATE DATABASE** | Crear base de datos | `CREATE DATABASE nombre` | `CREATE DATABASE Empresa` |
| **CREATE TABLE** | Crear tabla | `CREATE TABLE nombre (columnas)` | `CREATE TABLE Empleados (ID int, Nombre varchar(50))` |
| **ALTER TABLE ADD** | Agregar columna | `ALTER TABLE tabla ADD columna tipo` | `ALTER TABLE Empleados ADD Email varchar(100)` |
| **ALTER TABLE ALTER** | Modificar columna | `ALTER TABLE tabla ALTER COLUMN columna nuevo_tipo` | `ALTER TABLE Empleados ALTER COLUMN Email varchar(150)` |
| **ALTER TABLE DROP** | Eliminar columna | `ALTER TABLE tabla DROP COLUMN columna` | `ALTER TABLE Empleados DROP COLUMN Email` |
| **DROP TABLE** | Eliminar tabla | `DROP TABLE nombre` | `DROP TABLE Empleados` |
| **DROP DATABASE** | Eliminar base de datos | `DROP DATABASE nombre` | `DROP DATABASE Empresa` |

### Restricciones y Claves

| Restricción | Propósito | Sintaxis | Ejemplo |
|-------------|-----------|----------|---------|
| **PRIMARY KEY** | Clave primaria | `columna tipo PRIMARY KEY` | `ID int PRIMARY KEY` |
| **FOREIGN KEY** | Clave foránea | `FOREIGN KEY (col) REFERENCES tabla(col)` | `FOREIGN KEY (EmpleadoID) REFERENCES Empleados(ID)` |
| **NOT NULL** | No permite valores nulos | `columna tipo NOT NULL` | `Nombre varchar(50) NOT NULL` |
| **UNIQUE** | Valores únicos | `columna tipo UNIQUE` | `Email varchar(100) UNIQUE` |
| **CHECK** | Validar condición | `CHECK (condición)` | `CHECK (Edad >= 18)` |
| **DEFAULT** | Valor por defecto | `columna tipo DEFAULT valor` | `Fecha datetime DEFAULT GETDATE()` |
| **IDENTITY** | Auto-incremento | `columna int IDENTITY(inicio, incremento)` | `ID int IDENTITY(1,1)` |

### Índices

| Comando | Propósito | Sintaxis | Ejemplo |
|---------|-----------|----------|---------|
| **CREATE INDEX** | Crear índice | `CREATE INDEX nombre ON tabla(columna)` | `CREATE INDEX IX_Empleados_Nombre ON Empleados(Nombre)` |
| **CREATE UNIQUE INDEX** | Índice único | `CREATE UNIQUE INDEX nombre ON tabla(columna)` | `CREATE UNIQUE INDEX IX_Empleados_Email ON Empleados(Email)` |
| **DROP INDEX** | Eliminar índice | `DROP INDEX tabla.nombre` | `DROP INDEX Empleados.IX_Empleados_Nombre` |

---

## 📊 Comandos DML (Data Manipulation Language)

### Operaciones Básicas

| Comando | Propósito | Sintaxis Básica | Ejemplo |
|---------|-----------|----------------|---------|
| **INSERT** | Insertar registros | `INSERT INTO tabla (cols) VALUES (vals)` | `INSERT INTO Empleados (Nombre, Edad) VALUES ('Juan', 25)` |
| **SELECT** | Consultar datos | `SELECT cols FROM tabla WHERE condicion` | `SELECT * FROM Empleados WHERE Edad > 30` |
| **UPDATE** | Actualizar registros | `UPDATE tabla SET col=val WHERE condicion` | `UPDATE Empleados SET Edad=26 WHERE ID=1` |
| **DELETE** | Eliminar registros | `DELETE FROM tabla WHERE condicion` | `DELETE FROM Empleados WHERE ID=1` |

### Variaciones de INSERT

| Tipo | Sintaxis | Ejemplo |
|------|----------|---------|
| **Inserción múltiple** | `INSERT INTO tabla VALUES (val1), (val2)` | `INSERT INTO Empleados VALUES ('Ana', 28), ('Luis', 32)` |
| **Inserción desde consulta** | `INSERT INTO tabla SELECT cols FROM otra_tabla` | `INSERT INTO EmpleadosActivos SELECT * FROM Empleados WHERE Activo=1` |

### Variaciones de SELECT

| Elemento | Propósito | Sintaxis | Ejemplo |
|----------|-----------|----------|---------|
| **DISTINCT** | Eliminar duplicados | `SELECT DISTINCT col FROM tabla` | `SELECT DISTINCT Ciudad FROM Empleados` |
| **TOP** | Limitar resultados | `SELECT TOP n FROM tabla` | `SELECT TOP 10 * FROM Empleados` |
| **WHERE** | Filtrar filas | `SELECT * FROM tabla WHERE condicion` | `SELECT * FROM Empleados WHERE Edad BETWEEN 25 AND 35` |
| **ORDER BY** | Ordenar resultados | `SELECT * FROM tabla ORDER BY col ASC/DESC` | `SELECT * FROM Empleados ORDER BY Nombre ASC` |
| **GROUP BY** | Agrupar datos | `SELECT col, func FROM tabla GROUP BY col` | `SELECT Departamento, COUNT(*) FROM Empleados GROUP BY Departamento` |
| **HAVING** | Filtrar grupos | `SELECT col FROM tabla GROUP BY col HAVING condicion` | `SELECT Depto, COUNT(*) FROM Empleados GROUP BY Depto HAVING COUNT(*) > 5` |

---

## 🔗 Comandos de JOIN

| Tipo de JOIN | Propósito | Sintaxis | Cuándo usar |
|-------------|-----------|----------|-------------|
| **INNER JOIN** | Solo coincidencias | `FROM A INNER JOIN B ON A.id = B.id` | Cuando necesitas solo registros que existen en ambas tablas |
| **LEFT JOIN** | Todos de la izquierda | `FROM A LEFT JOIN B ON A.id = B.id` | Cuando necesitas todos los registros de A, con o sin coincidencias en B |
| **RIGHT JOIN** | Todos de la derecha | `FROM A RIGHT JOIN B ON A.id = B.id` | Cuando necesitas todos los registros de B, con o sin coincidencias en A |
| **FULL JOIN** | Todos de ambas | `FROM A FULL JOIN B ON A.id = B.id` | Cuando necesitas todos los registros de ambas tablas |
| **CROSS JOIN** | Producto cartesiano | `FROM A CROSS JOIN B` | Raramente usado, combina cada fila de A con cada fila de B |

### Ejemplo Práctico de JOINs
```sql
-- INNER JOIN: Empleados con departamentos
SELECT e.Nombre, d.NombreDepartamento 
FROM Empleados e 
INNER JOIN Departamentos d ON e.DepartamentoID = d.ID

-- LEFT JOIN: Todos los empleados, con o sin departamento
SELECT e.Nombre, d.NombreDepartamento 
FROM Empleados e 
LEFT JOIN Departamentos d ON e.DepartamentoID = d.ID
```

---

## 📋 Operadores de Comparación y Lógicos

### Operadores de Comparación

| Operador | Descripción | Ejemplo |
|----------|-------------|---------|
| **=** | Igual | `WHERE Edad = 25` |
| **<>** o **!=** | Diferente | `WHERE Edad <> 25` |
| **<** | Menor que | `WHERE Edad < 30` |
| **>** | Mayor que | `WHERE Edad > 20` |
| **<=** | Menor o igual | `WHERE Edad <= 30` |
| **>=** | Mayor o igual | `WHERE Edad >= 18` |
| **BETWEEN** | Entre valores | `WHERE Edad BETWEEN 20 AND 30` |
| **IN** | Dentro de lista | `WHERE Ciudad IN ('Madrid', 'Barcelona')` |
| **LIKE** | Patrón de texto | `WHERE Nombre LIKE 'A%'` |
| **IS NULL** | Es nulo | `WHERE Email IS NULL` |
| **IS NOT NULL** | No es nulo | `WHERE Email IS NOT NULL` |

### Operadores Lógicos

| Operador | Descripción | Ejemplo |
|----------|-------------|---------|
| **AND** | Ambas condiciones verdaderas | `WHERE Edad > 20 AND Ciudad = 'Madrid'` |
| **OR** | Al menos una condición verdadera | `WHERE Edad < 20 OR Edad > 65` |
| **NOT** | Negación | `WHERE NOT Ciudad = 'Madrid'` |

### Patrones con LIKE

| Patrón | Descripción | Ejemplo |
|--------|-------------|---------|
| **%** | Cualquier secuencia de caracteres | `'A%'` (empieza con A) |
| **_** | Un solo carácter | `'A_'` (A seguido de un carácter) |
| **[]** | Cualquier carácter dentro de los corchetes | `'[ABC]%'` (empieza con A, B o C) |
| **[^]** | Cualquier carácter NO dentro de los corchetes | `'[^ABC]%'` (no empieza con A, B o C) |

---

## 🔢 Funciones de Agregación

| Función | Propósito | Ejemplo | Resultado |
|---------|-----------|---------|-----------|
| **COUNT()** | Contar registros | `SELECT COUNT(*) FROM Empleados` | Número total de empleados |
| **SUM()** | Sumar valores | `SELECT SUM(Salario) FROM Empleados` | Suma total de salarios |
| **AVG()** | Promedio | `SELECT AVG(Edad) FROM Empleados` | Edad promedio |
| **MAX()** | Valor máximo | `SELECT MAX(Salario) FROM Empleados` | Salario más alto |
| **MIN()** | Valor mínimo | `SELECT MIN(Edad) FROM Empleados` | Edad más baja |

---

## 📅 Funciones de Fecha y Texto Comunes

### Funciones de Fecha

| Función | Propósito | Ejemplo |
|---------|-----------|---------|
| **GETDATE()** | Fecha/hora actual | `SELECT GETDATE()` |
| **DATEPART()** | Extraer parte de fecha | `DATEPART(YEAR, FechaNacimiento)` |
| **DATEDIFF()** | Diferencia entre fechas | `DATEDIFF(YEAR, FechaNacimiento, GETDATE())` |
| **DATEADD()** | Agregar tiempo a fecha | `DATEADD(DAY, 30, GETDATE())` |

### Funciones de Texto

| Función | Propósito | Ejemplo |
|---------|-----------|---------|
| **LEN()** | Longitud de texto | `SELECT LEN(Nombre) FROM Empleados` |
| **UPPER()** | Convertir a mayúsculas | `SELECT UPPER(Nombre) FROM Empleados` |
| **LOWER()** | Convertir a minúsculas | `SELECT LOWER(Email) FROM Empleados` |
| **SUBSTRING()** | Extraer parte del texto | `SUBSTRING(Nombre, 1, 3)` |
| **CONCAT()** | Concatenar textos | `CONCAT(Nombre, ' ', Apellido)` |
| **REPLACE()** | Reemplazar texto | `REPLACE(Telefono, '-', '')` |
| **TRIM()** | Eliminar espacios | `TRIM(Nombre)` |

---

## 🔧 Comandos de Control y Utilidad

### Comandos de Transacciones

| Comando | Propósito | Uso |
|---------|-----------|-----|
| **BEGIN TRANSACTION** | Iniciar transacción | Para agrupar operaciones |
| **COMMIT** | Confirmar cambios | Hacer permanentes los cambios |
| **ROLLBACK** | Deshacer cambios | Cancelar operaciones de la transacción |

### Comandos de Información

| Comando | Propósito | Ejemplo |
|---------|-----------|---------|
| **USE** | Cambiar base de datos | `USE NombreBaseDatos` |
| **GO** | Separar lotes de comandos | Después de crear procedimientos |
| **EXEC** | Ejecutar procedimiento | `EXEC NombreProcedimiento @param = 'valor'` |
| **sp_help** | Información de tabla | `EXEC sp_help 'NombreTabla'` |

---

## 💡 Consejos de Uso Rápido

### ⚠️ Comandos Peligrosos (¡Usar con precaución!)

| Comando | Peligro | Precaución |
|---------|---------|------------|
| `DELETE FROM tabla` | Elimina TODOS los registros | **SIEMPRE usar WHERE** |
| `UPDATE tabla SET campo=valor` | Modifica TODOS los registros | **SIEMPRE usar WHERE** |
| `DROP TABLE tabla` | Elimina toda la tabla | **Hacer backup primero** |
| `DROP DATABASE bd` | Elimina toda la BD | **Hacer backup primero** |

### ✅ Buenas Prácticas Rápidas

- **Siempre hacer backup antes de operaciones importantes**
- **Usar WHERE en UPDATE y DELETE**
- **Probar SELECT antes de hacer UPDATE**
- **Usar nombres descriptivos para tablas y columnas**
- **Comentar código complejo con --**
- **Usar UPPER/lower case consistentemente**

---

Esta tabla de referencia te permitirá consultar rápidamente los comandos más importantes que necesitarás en tu día a día con SQL Server. ¡Guárdala como referencia rápida!