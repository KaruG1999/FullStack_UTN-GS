# Bases de Datos - Teoría y Conceptos Fundamentales

## ¿Qué es una Base de Datos?

Una **base de datos** es un conjunto organizado de datos que se almacenan de forma estructurada para permitir su fácil acceso, gestión y actualización. Es como un archivo digital que puede contener información relacionada entre sí.

### ¿Para qué se usa?
- Almacenar grandes cantidades de información de forma organizada
- Permitir búsquedas rápidas y eficientes
- Mantener la integridad de los datos
- Permitir que múltiples usuarios accedan simultáneamente
- Realizar respaldos y recuperación de información

**Ejemplo:** Una tienda online usa una base de datos para almacenar información de productos, clientes, pedidos, etc.

## SQL Server Management Studio

**SQL Server Management Studio (SSMS)** es una herramienta gráfica que nos permite administrar bases de datos de SQL Server de forma visual, sin necesidad de escribir código todo el tiempo.

## Conceptos Fundamentales

### Tablas
Una **tabla** es la estructura básica donde se almacenan los datos. Es como una hoja de cálculo con filas y columnas.
- **Filas (registros):** Cada fila representa un elemento individual
- **Columnas (campos):** Cada columna representa una característica o atributo

**Ejemplo:**
```
Tabla: Estudiantes
| ID | Nombre    | Edad | Carrera        |
|----|-----------|------|----------------|
| 1  | Juan      | 20   | Ingeniería     |
| 2  | María     | 22   | Medicina       |
| 3  | Pedro     | 19   | Derecho        |
```

### Primary Key (Clave Primaria)

Es un campo o conjunto de campos que identifican de forma única cada registro en una tabla.

#### Primary Key Simple
Un solo campo actúa como clave primaria.
```sql
ID int PRIMARY KEY
```

#### Primary Key Compuesta
Varios campos juntos forman la clave primaria.
```sql
PRIMARY KEY (ClienteID, ProductoID)
```

**Características:**
- No puede ser NULL
- Debe ser único
- No puede repetirse

### Foreign Key (Clave Foránea)

Es un campo que establece una relación entre dos tablas, haciendo referencia a la clave primaria de otra tabla.

**Ejemplo:**
```sql
-- En la tabla Pedidos
ClienteID int FOREIGN KEY REFERENCES Clientes(ID)
```

### Índices

Los **índices** son estructuras que mejoran la velocidad de búsqueda en las tablas, como el índice de un libro que te ayuda a encontrar información rápidamente.

**Tipos:**
- **Clustered:** Organiza físicamente los datos
- **Non-clustered:** Crea una estructura separada para búsquedas

### Instancia

Una **instancia** es una instalación individual de SQL Server que puede contener múltiples bases de datos. Es como tener varios archiveros (bases de datos) dentro de una oficina (instancia).

## Tipos de Datos en SQL Server

### Tipos Numéricos
- **int:** Números enteros (-2,147,483,648 a 2,147,483,647)
- **decimal(p,s):** Números con decimales exactos
- **float:** Números con decimales aproximados

### Tipos de Texto
- **varchar(n):** Texto variable hasta n caracteres
- **char(n):** Texto fijo de n caracteres
- **text:** Texto largo

### Tipos de Fecha/Hora
- **datetime:** Fecha y hora completa
- **date:** Solo fecha
- **time:** Solo hora

### Otros Tipos
- **bit:** Valores verdadero/falso (1/0)
- **uniqueidentifier:** Identificador único global

## Lenguajes de Base de Datos

### DDL (Data Definition Language)
Lenguaje para **definir la estructura** de la base de datos.

**Comandos principales:**
- **CREATE:** Crear tablas, bases de datos, índices
- **ALTER:** Modificar estructura existente
- **DROP:** Eliminar elementos

### DML (Data Manipulation Language)
Lenguaje para **manipular los datos** dentro de las tablas.

**Comandos principales:**
- **INSERT:** Agregar nuevos registros
- **UPDATE:** Modificar registros existentes
- **DELETE:** Eliminar registros
- **SELECT:** Consultar datos

## Operaciones Básicas

### Por Interfaz Gráfica (SSMS)
- Usar menús contextuales (clic derecho)
- Arrastrar y soltar
- Usar asistentes visuales
- Diseñador de tablas

### Por Código SQL

#### Agregar Columna (ADD)
```sql
ALTER TABLE Estudiantes
ADD Email varchar(100)
```

#### Modificar Columna (ALTER COLUMN)
```sql
ALTER TABLE Estudiantes
ALTER COLUMN Nombre varchar(100)
```

#### Eliminar Columna (DROP COLUMN)
```sql
ALTER TABLE Estudiantes
DROP COLUMN Email
```

## Instrucciones SQL Básicas

### INSERT - Insertar datos
```sql
INSERT INTO Estudiantes (Nombre, Edad, Carrera)
VALUES ('Ana', 21, 'Psicología')
```

### SELECT - Consultar datos
```sql
-- Seleccionar todo
SELECT * FROM Estudiantes

-- Seleccionar columnas específicas
SELECT Nombre, Edad FROM Estudiantes

-- Con condiciones
SELECT * FROM Estudiantes WHERE Edad > 20
```

### UPDATE - Actualizar datos
```sql
UPDATE Estudiantes
SET Edad = 22
WHERE ID = 1
```

### DELETE - Eliminar datos
```sql
DELETE FROM Estudiantes
WHERE ID = 3
```

### GROUP BY - Agrupar datos
```sql
SELECT Carrera, COUNT(*) as CantidadEstudiantes
FROM Estudiantes
GROUP BY Carrera
```

## Tipos de JOIN

### INNER JOIN
Devuelve solo los registros que tienen coincidencias en ambas tablas.
```sql
SELECT e.Nombre, c.NombreCarrera
FROM Estudiantes e
INNER JOIN Carreras c ON e.CarreraID = c.ID
```

### LEFT JOIN
Devuelve todos los registros de la tabla izquierda, incluso si no hay coincidencias.
```sql
SELECT e.Nombre, c.NombreCarrera
FROM Estudiantes e
LEFT JOIN Carreras c ON e.CarreraID = c.ID
```

### RIGHT JOIN
Devuelve todos los registros de la tabla derecha.

### FULL JOIN
Devuelve todos los registros de ambas tablas.

## Conceptos Adicionales

### Subconsultas (Subqueries)
Consultas dentro de otras consultas.
```sql
SELECT Nombre
FROM Estudiantes
WHERE Edad > (SELECT AVG(Edad) FROM Estudiantes)
```

### Procedimientos Almacenados
Bloques de código SQL que se pueden reutilizar.
```sql
CREATE PROCEDURE ObtenerEstudiantesPorCarrera
    @NombreCarrera varchar(50)
AS
BEGIN
    SELECT * FROM Estudiantes
    WHERE Carrera = @NombreCarrera
END
```

### HAVING
Se usa con GROUP BY para filtrar grupos.
```sql
SELECT Carrera, COUNT(*) as Cantidad
FROM Estudiantes
GROUP BY Carrera
HAVING COUNT(*) > 5
```

---

**Recuerda:** La práctica es clave para dominar SQL. Cada comando tiene muchas variaciones y opciones que irás aprendiendo con el tiempo.