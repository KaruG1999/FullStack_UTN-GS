# Apunte: Programación Backend en C# - Introducción a .NET

## 1. Introducción a .NET Framework

### ¿Qué es .NET Framework?
- **Definición**: Plataforma de desarrollo de Microsoft para crear aplicaciones Windows
- **Año de lanzamiento**: 2002
- **Versión actual**: 4.8 (última versión, en mantenimiento)

### Características principales
- **Solo Windows**: Funciona únicamente en sistemas Windows
- **CLR (Common Language Runtime)**: Entorno de ejecución que gestiona la memoria y ejecuta el código
- **BCL (Base Class Library)**: Conjunto de librerías básicas para desarrollo
- **Lenguajes soportados**: C#, VB.NET, F#, C++/CLI

### Contexto actual y limitaciones
**¿Se usa todavía?**
- ✅ Sistemas legacy en empresas
- ✅ Aplicaciones Windows Forms y WPF existentes
- ❌ **NO recomendado para proyectos nuevos**

**Principales limitaciones:**
- Solo funciona en Windows
- No recibe nuevas características (solo actualizaciones de seguridad)
- Menor rendimiento comparado con .NET moderno
- Dependiente del sistema operativo

---

## 2. Introducción a .NET Core / .NET Moderno

### Evolución de .NET
```
.NET Framework (2002-2019) → .NET Core (2016-2020) → .NET 5+ (2020-presente)
```

### .NET Moderno (6, 7, 8...)
**¿Qué es?**
- Versión **multiplataforma** y **open source** de .NET
- Unifica .NET Framework, .NET Core y Xamarin
- Lanzamiento anual (noviembre)

### Principales diferencias con .NET Framework

| Aspecto | .NET Framework | .NET Moderno |
|---------|----------------|--------------|
| **Plataformas** | Solo Windows | Windows, Linux, macOS |
| **Rendimiento** | Menor | Significativamente mejor |
| **Despliegue** | Requiere .NET instalado | Self-contained posible |
| **Open Source** | No | Sí |
| **Desarrollo activo** | Mantenimiento | Desarrollo activo |
| **Tamaño** | Pesado | Ligero y modular |

### Ventajas de .NET Moderno
- **Cross-platform**: Deploy en Windows, Linux, Docker containers
- **Alto rendimiento**: Optimizaciones continuas
- **Modular**: Instala solo lo que necesitas
- **Cloud-ready**: Perfecto para microservicios y contenedores
- **Comunidad activa**: Open source con contribuciones globales

### ¿Por qué es el estándar actual?
1. **Microsoft lo prioriza**: Todas las nuevas características van aquí
2. **Industria lo adopta**: La mayoría de empresas migran o empiezan con .NET moderno
3. **Ecosistema rico**: NuGet packages, herramientas, documentación
4. **Futuro asegurado**: Roadmap claro y soporte a largo plazo

---

## 3. ¿Es necesario C# para usar bases de datos en .NET?

### Respuesta corta: **No, pero es lo más común**

### Lenguajes disponibles en .NET
- **C#** (más popular - 80%+ del ecosistema)
- **F#** (funcional)
- **VB.NET** (menos común)

### ¿Por qué C# es la opción preferida?
- **Sintaxis clara y moderna**
- **Mayor documentación y ejemplos**
- **Más desarrolladores en el mercado**
- **Mejor soporte de herramientas (IDEs, debugging)**

### Para bases de datos específicamente
```csharp
// Cualquier lenguaje .NET puede usar:
// - ADO.NET (acceso directo a BD)
// - Entity Framework (ORM)
// - Dapper (micro-ORM)
```

**Recomendación**: Aprende C# - es la puerta de entrada más sólida al ecosistema .NET.

---

## 4. Sintaxis Básica de C#

### Variables y Tipos de Datos
```csharp
// Tipos básicos
int edad = 25;
string nombre = "Juan";
bool esEstudiante = true;
double salario = 45000.50;
decimal precio = 199.99m; // Para dinero, usar decimal

// Inferencia de tipos (C# 3.0+)
var ciudad = "Buenos Aires"; // El compilador infiere string
var contador = 0; // El compilador infiere int

// Constantes
const string NOMBRE_APP = "MiApp";
```

### Condicionales
```csharp
// If-else
int nota = 8;
if (nota >= 7)
{
    Console.WriteLine("Aprobado");
}
else if (nota >= 4)
{
    Console.WriteLine("Debe recuperar");
}
else
{
    Console.WriteLine("Desaprobado");
}

// Switch (tradicional)
string dia = "lunes";
switch (dia)
{
    case "lunes":
        Console.WriteLine("Inicio de semana");
        break;
    case "viernes":
        Console.WriteLine("Fin de semana");
        break;
    default:
        Console.WriteLine("Día normal");
        break;
}

// Switch expression (C# 8.0+) - más moderno
string mensaje = dia switch
{
    "lunes" => "Inicio de semana",
    "viernes" => "Fin de semana",
    _ => "Día normal"
};
```

### Bucles
```csharp
// For
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Iteración {i}");
}

// While
int contador = 0;
while (contador < 3)
{
    Console.WriteLine($"Contador: {contador}");
    contador++;
}

// Foreach (para colecciones)
string[] nombres = {"Ana", "Pedro", "María"};
foreach (string nombre in nombres)
{
    Console.WriteLine($"Nombre: {nombre}");
}
```

### Funciones (Métodos)
```csharp
// Método básico
public static int Sumar(int a, int b)
{
    return a + b;
}

// Método con parámetros opcionales
public static string Saludar(string nombre, string titulo = "Sr/Sra")
{
    return $"Hola {titulo} {nombre}";
}

// Método void (no retorna valor)
public static void MostrarMensaje(string mensaje)
{
    Console.WriteLine(mensaje);
}

// Uso de los métodos
int resultado = Sumar(5, 3);
string saludo = Saludar("Ana");
MostrarMensaje("¡Bienvenido!");
```

### Clases y Objetos
```csharp
// Definición de clase
public class Estudiante
{
    // Propiedades (C# 3.0+)
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public string Email { get; set; }

    // Constructor
    public Estudiante(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
    }

    // Método de la clase
    public string ObtenerInfo()
    {
        return $"Estudiante: {Nombre}, Edad: {Edad}";
    }

    // Método estático
    public static bool EsMayorDeEdad(int edad)
    {
        return edad >= 18;
    }
}

// Uso de la clase
class Program
{
    static void Main(string[] args)
    {
        // Crear objeto
        var estudiante = new Estudiante("Pedro", 20);
        estudiante.Email = "pedro@email.com";

        // Usar métodos
        Console.WriteLine(estudiante.ObtenerInfo());
        
        // Método estático
        bool esMayor = Estudiante.EsMayorDeEdad(estudiante.Edad);
        Console.WriteLine($"¿Es mayor de edad? {esMayor}");
    }
}
```

---

## 5. Ejemplos Prácticos

### 5.1 Hello World - Aplicación de Consola

```csharp
using System;

namespace MiPrimeraApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("¡Hola Mundo desde C#!");
            
            // Interacción con el usuario
            Console.Write("Ingresa tu nombre: ");
            string nombre = Console.ReadLine();
            
            Console.WriteLine($"¡Hola {nombre}! Bienvenido a .NET");
            
            // Pausar antes de cerrar
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }
    }
}
```

**Para ejecutar:**
```bash
dotnet new console -n MiPrimeraApp
cd MiPrimeraApp
# (Reemplazar código en Program.cs)
dotnet run
```

### 5.2 Conexión a SQL Server con ADO.NET

```csharp
using System;
using System.Data.SqlClient;

namespace ConexionADO
{
    class Program
    {
        // String de conexión (cambiar por tus datos)
        private static string connectionString = 
            "Server=localhost;Database=MiBaseDatos;Trusted_Connection=true;";

        static void Main(string[] args)
        {
            try
            {
                // 1. Conectar y leer datos
                LeerUsuarios();
                
                // 2. Insertar un nuevo usuario
                InsertarUsuario("Ana García", "ana@email.com");
                
                Console.WriteLine("Operaciones completadas.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void LeerUsuarios()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                string query = "SELECT Id, Nombre, Email FROM Usuarios";
                using (var command = new SqlCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        Console.WriteLine("=== USUARIOS ===");
                        while (reader.Read())
                        {
                            int id = reader.GetInt32("Id");
                            string nombre = reader.GetString("Nombre");
                            string email = reader.GetString("Email");
                            
                            Console.WriteLine($"ID: {id}, Nombre: {nombre}, Email: {email}");
                        }
                    }
                }
            }
        }

        static void InsertarUsuario(string nombre, string email)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                
                string query = "INSERT INTO Usuarios (Nombre, Email) VALUES (@nombre, @email)";
                using (var command = new SqlCommand(query, connection))
                {
                    // Parámetros previenen SQL Injection
                    command.Parameters.AddWithValue("@nombre", nombre);
                    command.Parameters.AddWithValue("@email", email);
                    
                    int filasAfectadas = command.ExecuteNonQuery();
                    Console.WriteLine($"Usuario insertado. Filas afectadas: {filasAfectadas}");
                }
            }
        }
    }
}
```

**Instalación del paquete:**
```bash
dotnet add package System.Data.SqlClient
```

### 5.3 Ejemplo con Entity Framework Core

**Paso 1: Modelo de datos**
```csharp
using Microsoft.EntityFrameworkCore;

// Modelo (entidad)
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateTime FechaCreacion { get; set; }
}

// DbContext (contexto de base de datos)
public class AppDbContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=localhost;Database=MiAppEF;Trusted_Connection=true;");
    }
}
```

**Paso 2: Programa principal**
```csharp
using System;
using System.Linq;

namespace AppEntityFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {
                // Asegurarse de que la BD existe
                context.Database.EnsureCreated();

                // 1. Crear usuario
                var nuevoUsuario = new Usuario
                {
                    Nombre = "Carlos Pérez",
                    Email = "carlos@email.com",
                    FechaCreacion = DateTime.Now
                };

                context.Usuarios.Add(nuevoUsuario);
                context.SaveChanges();
                
                Console.WriteLine("Usuario creado exitosamente");

                // 2. Leer usuarios
                var usuarios = context.Usuarios.ToList();
                Console.WriteLine("\n=== USUARIOS ===");
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"ID: {usuario.Id}");
                    Console.WriteLine($"Nombre: {usuario.Nombre}");
                    Console.WriteLine($"Email: {usuario.Email}");
                    Console.WriteLine($"Creado: {usuario.FechaCreacion:dd/MM/yyyy}");
                    Console.WriteLine("---");
                }

                // 3. Buscar usuario específico
                var usuarioBuscado = context.Usuarios
                    .FirstOrDefault(u => u.Email == "carlos@email.com");
                
                if (usuarioBuscado != null)
                {
                    Console.WriteLine($"Usuario encontrado: {usuarioBuscado.Nombre}");
                }

                // 4. Actualizar usuario
                usuarioBuscado.Nombre = "Carlos Pérez Actualizado";
                context.SaveChanges();
                Console.WriteLine("Usuario actualizado");

                // 5. Eliminar usuario
                // context.Usuarios.Remove(usuarioBuscado);
                // context.SaveChanges();
            }
        }
    }
}
```

**Instalación de paquetes:**
```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
```

---

## Preparándote para Web APIs y ORMs

### ✅ Base sólida completada
- **.NET moderno**: La plataforma que usaremos para nuestras APIs
- **C# fundamentals**: El lenguaje con el que construiremos endpoints
- **Entity Framework Core**: El ORM que dominaremos para gestión de datos
- **ADO.NET**: Comprensión del nivel bajo que hay debajo de los ORMs

### 🚀 Lo que viene en el cronograma

#### **Próximo: Web APIs con ASP.NET Core**
El Entity Framework que ya viste será el **motor de datos** de tus APIs:
```csharp
// En tus controladores usarás el DbContext que ya conoces
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly AppDbContext _context;
    
    [HttpGet]
    public async Task<List<Usuario>> GetUsuarios()
    {
        return await _context.Usuarios.ToListAsync(); // ¡EF Core en acción!
    }
}
```

#### **Después: Profundización en ORMs**
Expandiremos Entity Framework Core con:
- **Relaciones entre entidades** (One-to-Many, Many-to-Many)
- **Migraciones** para evolucionar la base de datos
- **Query optimization** y performance
- **Code First vs Database First**

### 🎯 Conexión con lo que sigue

**¿Por qué empezamos con los fundamentos?**
- Las **Web APIs** son aplicaciones C# que exponen datos via HTTP
- Los **ORMs** como EF Core son la forma moderna de manejar bases de datos
- Todo lo que aprendiste hoy es la **base** sobre la cual construiremos

**Pipeline de aprendizaje:**
```
Fundamentos C# + EF Core → Web APIs → ORMs Avanzado → Arquitectura completa
     ↑ Estás aquí           ↑ Próximo    ↑ Después    ↑ Objetivo final
```

### 💡 Para la próxima clase

**Recomendaciones previas a Web APIs:**
1. **Practica los ejemplos de EF Core** - Los usaremos en controladores
2. **Familiarízate con JSON** - Formato de intercambio en APIs REST
3. **Entiende HTTP básico** - GET, POST, PUT, DELETE
4. **Instala Postman o similar** - Para probar APIs

**Conceptos clave que conectan:**
- Tu `AppDbContext` se convertirá en el **servicio de datos** de la API
- Los modelos como `Usuario` serán los **DTOs** que devuelvan tus endpoints
- Las operaciones CRUD que hiciste manualmente se convertirán en **endpoints REST**

---

*"Los fundamentos que acabas de ver son los bloques de construcción. Próximamente los conectaremos para crear APIs profesionales que consuman cualquier aplicación frontend."*