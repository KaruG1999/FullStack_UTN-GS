# Apuntes Completos: APIs en .NET - Conceptos y Práctica

## 📚 Definiciones Fundamentales

### HTTP (HyperText Transfer Protocol)
**¿Qué es?** El protocolo de comunicación que permite la transferencia de información en la web entre clientes y servidores.

**Características clave:**
- Es **stateless** (sin estado): cada petición es independiente
- Funciona con un modelo **request-response** (petición-respuesta)
- Usa diferentes métodos para diferentes tipos de operaciones

**Ejemplo práctico:**
```
Cliente (navegador/app) → HTTP Request → Servidor (API)
                      ← HTTP Response ← 
```

### Endpoint
**¿Qué es?** Una URL específica donde tu API puede ser accedida por un cliente. Es como la "dirección" de un servicio específico.

**Ejemplo:**
```
GET https://miapi.com/api/instruments        ← Endpoint para obtener todos los instrumentos
POST https://miapi.com/api/instruments       ← Endpoint para crear un nuevo instrumento
PUT https://miapi.com/api/instruments/0      ← Endpoint para actualizar instrumento en posición 0
DELETE https://miapi.com/api/instruments/1   ← Endpoint para eliminar instrumento en posición 1
```

### Swagger UI vs Postman

| Aspecto | Swagger UI | Postman |
|---------|------------|---------|
| **¿Qué es?** | Interfaz web automática que documenta tu API | Herramienta externa para probar APIs |
| **Ventajas** | ✅ Se genera automáticamente<br>✅ Siempre está actualizada<br>✅ Permite probar desde el navegador | ✅ Más potente para pruebas complejas<br>✅ Permite guardar colecciones<br>✅ Funciona con cualquier API |
| **Desventajas** | ❌ Limitada para pruebas avanzadas<br>❌ Solo para desarrollo | ❌ Herramienta separada<br>❌ Hay que configurarla manualmente |

## 🔢 Status Codes (Códigos de Estado HTTP)

### Códigos más comunes:
- **200 OK**: Todo salió bien
- **201 Created**: Recurso creado exitosamente (típico en POST)
- **400 Bad Request**: El cliente envió datos incorrectos
- **404 Not Found**: El recurso no existe
- **500 Internal Server Error**: Error en el servidor

### Error 500 y APIs
**¿Cuándo ocurre?** Cuando hay un error no controlado en tu código del servidor.

**Ejemplo que causaría un 500:**
```csharp
[HttpGet]
public IActionResult GetInstrument(int index)
{
    // Si index es mayor que la lista, esto causará un error 500
    return Ok(instruments[index]); // ¡Sin validación!
}
```

**Versión corregida:**
```csharp
[HttpGet]
public IActionResult GetInstrument(int index)
{
    if (index < 0 || index >= instruments.Count)
        return NotFound("Instrumento no encontrado"); // Error 404

    return Ok(instruments[index]); // Error 200
}
```

## 🌐 Métodos HTTP - CRUD Operations

### GET - Leer/Consultar
- **Propósito**: Obtener información
- **¿Modifica datos?** NO
- **Ejemplo**: `GET /api/instruments` → Devuelve lista de instrumentos

### POST - Crear
- **Propósito**: Crear nuevos recursos
- **¿Modifica datos?** SÍ
- **Los datos van en**: El body de la petición
- **Ejemplo**: `POST /api/instruments` con body `"Violín"`

### PUT - Actualizar/Reemplazar
- **Propósito**: Actualizar un recurso completo
- **¿Modifica datos?** SÍ
- **Típicamente requiere**: ID del recurso en la URL
- **Ejemplo**: `PUT /api/instruments/0` con body `"Guitarra Eléctrica"`

### DELETE - Eliminar
- **Propósito**: Eliminar recursos
- **¿Modifica datos?** SÍ
- **Ejemplo**: `DELETE /api/instruments/1`

## 📍 Origen de los Parámetros

### [FromBody]
Los datos vienen en el **cuerpo** de la petición HTTP.
```csharp
[HttpPost]
public IActionResult AddInstrument([FromBody] string instrument)
{
    // El string "Violín" viene en el body de la petición
}
```

### [FromQuery]
Los datos vienen como **parámetros de consulta** en la URL.
```csharp
[HttpGet]
public IActionResult Search([FromQuery] string name)
{
    // URL: /api/instruments?name=Guitar
    // name = "Guitar"
}
```

### [FromRoute]
Los datos vienen de la **ruta/URL** misma.
```csharp
[HttpPut("{index}")]
public IActionResult UpdateInstrument([FromRoute] int index, [FromBody] string newName)
{
    // URL: /api/instruments/0
    // index = 0
    // newName viene del body
}
```

## 📄 Formatos de Datos

### JSON (JavaScript Object Notation)
**¿Qué es?** El formato más popular para APIs modernas. Es ligero y fácil de leer.

**Ejemplo:**
```json
{
    "id": 1,
    "nombre": "Guitarra",
    "tipo": "Cuerda",
    "precio": 500.00
}
```

### XML (eXtensible Markup Language)
**¿Qué es?** Formato más verboso, menos usado actualmente en APIs REST.

**Ejemplo:**
```xml
<instrumento>
    <id>1</id>
    <nombre>Guitarra</nombre>
    <tipo>Cuerda</tipo>
    <precio>500.00</precio>
</instrumento>
```

### SOAP vs REST

| SOAP | REST |
|------|------|
| Protocolo más antiguo y complejo | Estilo arquitectónico moderno |
| Solo XML | JSON, XML, HTML, texto |
| Más lento | Más rápido y liviano |
| Muy estructurado | Más flexible |

## 🎯 IActionResult vs Tipos Primitivos

### Retorno con Tipo Primitivo
```csharp
[HttpGet]
public List<string> GetInstruments()
{
    return instruments; // Siempre retorna 200 OK
}
```
**Limitaciones:**
- ❌ No puedes cambiar el status code
- ❌ No puedes manejar errores elegantemente

### Retorno con IActionResult
```csharp
[HttpGet]
public IActionResult GetInstruments()
{
    if (instruments.Count == 0)
        return NotFound("No hay instrumentos"); // 404

    return Ok(instruments); // 200 con los datos
}
```
**Ventajas:**
- ✅ Control total sobre status codes
- ✅ Mejor manejo de errores
- ✅ Más profesional y flexible

---

# 🛠️ Análisis del Ejercicio Práctico

## Contexto del Ejercicio
El ejercicio simula una **API REST** para gestionar instrumentos musicales. Implementa las 4 operaciones básicas del **CRUD** (Create, Read, Update, Delete) usando una lista en memoria.

## Parte 1: Lista en Memoria
```csharp
private static List<string> instruments = new() { "Guitarra", "Batería", "Piano" };
```

**¿Por qué `static`?** 
- Para que **todos los controladores compartan la misma lista**
- Sin `static`, cada petición HTTP crearía una nueva instancia con datos perdidos

**¿Por qué en memoria?**
- Es **temporal**: al reiniciar el servidor, se pierden los cambios
- Perfecto para **aprendizaje y testing**
- En producción usarías una **base de datos**

## Parte 2: Implementación de Endpoints

### GET - Obtener todos los instrumentos
```csharp
[HttpGet]
public IActionResult GetInstruments()
{
    return Ok(instruments);
}
```

**¿Qué hace?**
1. **No recibe parámetros** - queremos TODOS los instrumentos
2. **Retorna status 200** con la lista completa
3. **No modifica nada** - es una operación de solo lectura

### POST - Agregar nuevo instrumento
```csharp
[HttpPost]
public IActionResult AddInstrument([FromBody] string instrument)
{
    if (string.IsNullOrWhiteSpace(instrument))
        return BadRequest("El nombre del instrumento no puede estar vacío");
    
    instruments.Add(instrument);
    return Ok($"Instrumento agregado: {instrument}");
}
```

**¿Qué hace?**
1. **Recibe datos del body** - el nombre del nuevo instrumento
2. **Valida** que no esté vacío (buena práctica)
3. **Modifica la lista** agregando el nuevo elemento
4. **Retorna confirmación** con status 200

### PUT - Actualizar instrumento existente
```csharp
[HttpPut("{index}")]
public IActionResult UpdateInstrument([FromRoute] int index, [FromBody] string newName)
{
    if (index < 0 || index >= instruments.Count)
        return NotFound($"No existe instrumento en posición {index}");
    
    if (string.IsNullOrWhiteSpace(newName))
        return BadRequest("El nuevo nombre no puede estar vacío");
    
    string oldName = instruments[index];
    instruments[index] = newName;
    
    return Ok($"Instrumento en posición {index} actualizado de '{oldName}' a '{newName}'");
}
```

**¿Qué hace?**
1. **Recibe el índice de la URL** (`{index}` en la ruta)
2. **Recibe el nuevo nombre del body**
3. **Valida** que el índice exista y el nombre no esté vacío
4. **Actualiza** el elemento en esa posición
5. **Retorna confirmación** detallada

### DELETE - Eliminar instrumento
```csharp
[HttpDelete("{index}")]
public IActionResult DeleteInstrument([FromRoute] int index)
{
    if (index < 0 || index >= instruments.Count)
        return NotFound($"No existe instrumento en posición {index}");
    
    string deletedInstrument = instruments[index];
    instruments.RemoveAt(index);
    
    return Ok($"Instrumento eliminado: {deletedInstrument}");
}
```

**¿Qué hace?**
1. **Solo recibe el índice** de la URL
2. **Valida** que el índice exista
3. **Guarda referencia** del elemento antes de borrarlo
4. **Elimina** el elemento de la lista
5. **Retorna confirmación** con el nombre del elemento eliminado

## Parte 3: Refactoring con Repository Pattern

### ¿Por qué separar en una clase?
- **Separación de responsabilidades**: El controlador maneja HTTP, el repository maneja datos
- **Reutilizable**: Múltiples controladores pueden usar el mismo repository
- **Testeable**: Es más fácil hacer pruebas unitarias
- **Escalable**: Facilita cambiar de memoria a base de datos después

### InstrumentRepository
```csharp
public class InstrumentRepository
{
    public List<string> Instruments { get; private set; }
    
    public InstrumentRepository()
    {
        Instruments = new List<string> { "Guitarra", "Batería", "Piano" };
    }
}
```

### Controlador Modificado
```csharp
[ApiController]
[Route("api/[controller]")]
public class InstrumentsController : ControllerBase
{
    private static InstrumentRepository repository = new();
    
    [HttpGet]
    public IActionResult GetInstruments()
    {
        return Ok(repository.Instruments);
    }
    
    [HttpPost]
    public IActionResult AddInstrument([FromBody] string instrument)
    {
        if (string.IsNullOrWhiteSpace(instrument))
            return BadRequest("El nombre del instrumento no puede estar vacío");
        
        repository.Instruments.Add(instrument);
        return Ok($"Instrumento agregado: {instrument}");
    }
    
    // ... resto de métodos usando repository.Instruments
}
```

## 🎯 Conceptos Clave que Refuerza el Ejercicio

1. **CRUD Completo**: Create (POST), Read (GET), Update (PUT), Delete (DELETE)
2. **Parámetros de diferentes fuentes**: FromRoute, FromBody
3. **Validaciones**: Verificar índices válidos y datos no vacíos
4. **Status Codes apropiados**: 200 OK, 400 Bad Request, 404 Not Found
5. **IActionResult**: Control total sobre la respuesta HTTP
6. **Separación de concerns**: Controlador vs Repository

## 🔍 Para Consolidar tu Aprendizaje

**Preguntas para hacerte:**
1. ¿Qué pasaría si uso `int` en lugar de `IActionResult`?
2. ¿Por qué PUT necesita el índice en la URL pero POST no?
3. ¿Qué diferencia hay entre `FromBody` y `FromQuery`?
4. ¿Por qué es importante validar antes de acceder al array?
5. ¿Cómo cambiarías esto para usar una base de datos real?

Este ejercicio es **perfecto para principiantes** porque te permite ver todos los conceptos funcionando juntos en un ejemplo simple pero completo. ¡Es la base para APIs más complejas!