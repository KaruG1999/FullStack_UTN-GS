# Bases de Datos - Clase 2: Optimización y Transacciones

## Repaso: Beneficios de HAVING después de GROUP BY

**HAVING** nos permite filtrar **grupos** después de que se han formado, no registros individuales como WHERE.

**Ejemplo práctico:**  
Queremos enviar un 15% de descuento a clientes que tienen más de 3 órdenes:

```sql
SELECT CustomerID, COUNT(*) as TotalOrdenes
FROM Orders
GROUP BY CustomerID
HAVING COUNT(*) > 3
```

### ¿Por qué es mejor filtrar en la base de datos?
- Es más eficiente: la BD procesa millones de registros más rápido
- Menos transferencia de datos por la red
- El código de la aplicación queda más limpio

---

## Queries NO Optimizadas (No Performantes)

### ¿Qué significa que una query sea NO performante?

Una query **no performante** es aquella que:
- Tarda mucho tiempo en ejecutarse
- Consume demasiados recursos del servidor
- Puede bloquear otras operaciones
- No aprovecha las estructuras de la base de datos (como índices)

### Ejemplo de Query NO Performante

```sql
SELECT *
FROM Customers C
WHERE C.CustomerID IN (
    SELECT O.CustomerID
    FROM Orders O
    WHERE O.CustomerID IN (
        SELECT CustomerID
        FROM Orders
        GROUP BY CustomerID
        HAVING COUNT(*) > 5
    )
);
```

**Problemas identificados:**
1. **Subconsultas anidadas:** Una consulta dentro de otra consulta, lo que multiplica el trabajo
2. **Subconsulta redundante:** Se está consultando la misma información dos veces
3. **SELECT \*:** Trae todas las columnas aunque no las necesitemos

### Versión Optimizada

```sql
SELECT C.ContactName, C.CompanyName
FROM Customers C
JOIN (
    SELECT CustomerID
    FROM Orders
    GROUP BY CustomerID
    HAVING COUNT(*) > 5
) O ON C.CustomerID = O.CustomerID;
```

**Mejoras aplicadas:**
- Usamos **JOIN** en lugar de subconsultas anidadas
- Seleccionamos solo las columnas necesarias
- Eliminamos la redundancia

---

## Transacciones: Commit y Rollback

### ¿Qué es una Transacción?

Una **transacción** es un conjunto de operaciones que se ejecutan como una sola unidad. Es como un "todo o nada": o se ejecutan todas las operaciones exitosamente, o ninguna se ejecuta.

**Analogía:** Es como comprar online con tarjeta de crédito. El sistema debe:
1. Verificar que tengas saldo
2. Descontar el dinero de tu cuenta
3. Registrar la compra
4. Actualizar el stock

Si falla cualquier paso, **todo** debe cancelarse.

### ¿Cuándo usar transacciones?

**✅ SÍ usar cuando:**
- Necesitas hacer varios cambios relacionados
- Si falla uno, los otros no deben ejecutarse
- Transferencias de dinero, actualizaciones de inventario

**❌ NO usar cuando:**
- Operaciones simples e independientes
- Consultas de solo lectura (SELECT)

### Ejemplo Sin Control de Errores

```sql
BEGIN TRANSACTION;
UPDATE Products 
SET UnitsInStock = UnitsInStock - 2 
WHERE ProductID = 1;

UPDATE Products 
SET UnitsInStock = UnitsInStock / 0  -- ¡Error! División por cero
WHERE ProductID = 1;

COMMIT;  -- Esto nunca se ejecutará por el error
```

**Problema:** La primera actualización se ejecuta, pero la segunda falla. Los datos quedan inconsistentes.

### Ejemplo Con Control de Errores (TRY-CATCH)

```sql
BEGIN TRANSACTION;
BEGIN TRY
    UPDATE Products 
    SET UnitsInStock = UnitsInStock - 2 
    WHERE ProductID = 1;
    
    UPDATE Products 
    SET UnitsInStock = UnitsInStock / 0 
    WHERE ProductID = 1;
    
    COMMIT;  -- Solo se ejecuta si todo sale bien
END TRY
BEGIN CATCH
    ROLLBACK;  -- Cancela TODOS los cambios si hay error
    SELECT ERROR_MESSAGE() AS ErrorMessage;
END CATCH;
```

### Comandos Clave

- **COMMIT:** Confirma y guarda todos los cambios de la transacción
- **ROLLBACK:** Cancela todos los cambios y vuelve al estado anterior
- **BEGIN TRANSACTION:** Inicia una nueva transacción

---

## Deadlock (Bloqueo Mutuo)

### ¿Qué es un Deadlock?

Un **deadlock** ocurre cuando dos procesos se bloquean mutuamente porque cada uno espera un recurso que el otro tiene.

**Analogía:** Es como dos autos que llegan al mismo tiempo a una intersección de una sola vía. El auto A espera que pase el auto B, pero el auto B espera que pase el auto A. Ninguno puede avanzar.

### Cómo se Produce un Deadlock

**Proceso A:**
```sql
BEGIN TRANSACTION;
-- 1. Bloquea la tabla Orders
UPDATE Orders SET Freight = Freight + 10 
WHERE OrderID = 10248;

-- 3. Intenta bloquear Customers (pero B ya la tiene)
UPDATE Customers SET ContactName = 'Updated Name'
WHERE CustomerID = (SELECT CustomerID FROM Orders WHERE OrderID = 10248);
-- Queda esperando...
```

**Proceso B:**
```sql
BEGIN TRANSACTION;
-- 2. Bloquea la tabla Customers  
UPDATE Customers SET ContactName = 'Another Update'
WHERE CustomerID = 'ALFKI';

-- 4. Intenta bloquear Orders (pero A ya la tiene)
UPDATE Orders SET Freight = Freight + 20
WHERE OrderID = (SELECT OrderID FROM Orders WHERE CustomerID = 'ALFKI');
-- Queda esperando...
```

**Resultado:** Ninguno puede continuar porque cada uno espera lo que el otro tiene.

### Cómo Evitar Deadlocks

#### 1. Orden de adquisición de bloqueos
- Todos los procesos deben acceder a las tablas en el mismo orden
- **Ejemplo:** Siempre actualizar primero Customers, después Orders

#### 2. Minimizar tiempo de bloqueo
- Hacer las transacciones lo más cortas posible
- Hacer COMMIT o ROLLBACK rápidamente
- No dejar transacciones abiertas esperando

#### 3. Usar índices apropiados
- Los bloqueos serán más específicos y rápidos

---

## Conceptos Adicionales

### Restricciones NOT NULL

**No se puede insertar una columna con valores NOT NULL** en una tabla que ya tiene datos, a menos que:
- Le des un valor por defecto
- Permitas valores NULL temporalmente

**Ejemplo:**
```sql
-- ❌ Esto falla si la tabla tiene datos
ALTER TABLE Customers 
ADD Email varchar(100) NOT NULL;

-- ✅ Esto funciona
ALTER TABLE Customers 
ADD Email varchar(100) NOT NULL DEFAULT 'sin-email@ejemplo.com';
```

---

## 📝 Puntos Clave para Recordar

- **Optimiza** tus queries evitando subconsultas innecesarias
- **Usa transacciones** para operaciones críticas que requieren consistencia
- **El deadlock se evita** con buena planificación del orden de acceso a recursos
- **Siempre maneja errores** con TRY-CATCH en transacciones
- **Filtra en la BD** siempre que sea posible, no en el código de la aplicación