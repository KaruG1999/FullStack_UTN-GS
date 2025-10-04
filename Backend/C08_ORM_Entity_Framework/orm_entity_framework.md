# ORM y Entity Framework

## 🔗 Conexión con Temas Anteriores

**Desde APIs**: Vimos cómo las APIs manejan datos en formato JSON/XML. ORM nos ayuda a convertir esos datos en objetos de C# y almacenarlos en base de datos.

**Desde Inyección de Dependencias**: Los contextos de Entity Framework se inyectan en nuestros servicios, aplicando los patrones que aprendimos.

---

## 🗃️ ¿Qué es un ORM?

**ORM** significa **Object-Relational Mapping** (Mapeo Objeto-Relacional).

Es una técnica que permite trabajar con bases de datos usando objetos de nuestro lenguaje de programación, sin necesidad de escribir SQL directamente.

### Antes vs Después del ORM

#### Sin ORM ❌
```csharp
// Escribir SQL manualmente
string sql = "SELECT Id, Nombre, Email FROM Usuarios WHERE Id = @id";
using (var connection = new SqlConnection(connectionString))
{
    var command = new SqlCommand(sql, connection);
    command.Parameters.AddWithValue("@id", usuarioId);
    connection.Open();
    
    using (var reader = command.ExecuteReader())
    {
        if (reader.Read())
        {
            var usuario = new Usuario
            {
                Id = (int)reader["Id"],
                Nombre = reader["Nombre"].ToString(),
                Email = reader["Email"].ToString()
            };
        }
    }
}
```

#### Con ORM ✅
```csharp
// Entity Framework hace todo automáticamente
var usuario = await context.Usuarios.FirstOrDefaultAsync(u => u.Id == usuarioId);
```

---

## 🏗️ Entity Framework

**Entity Framework** es el ORM oficial de Microsoft para .NET. Permite trabajar con bases de datos usando objetos C#.

### Componentes Principales

#### 1. DbContext
Es la clase principal que representa una sesión con la base de datos.

```csharp
public class MiDbContext : DbContext
{
    public MiDbContext(DbContextOptions<MiDbContext> options) : base(options) { }
    
    // Cada DbSet representa una tabla
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Producto> Productos { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuraciones adicionales
        modelBuilder.Entity<Usuario>()
            .HasKey(u => u.Id);
            
        modelBuilder.Entity<Usuario>()
            .Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(100);
    }
}
```

#### 2. Entidades (Models)
Son las clases que representan las tablas de la base de datos.

```csharp
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateTime FechaRegistro { get; set; }
    
    // Navegación a otras entidades
    public List<Pedido> Pedidos { get; set; } = new List<Pedido>();
}

public class Pedido
{
    public int Id { get; set; }
    public int UsuarioId { get; set; }  // Clave foránea
    public DateTime Fecha { get; set; }
    public decimal Total { get; set; }
    
    // Navegación de regreso
    public Usuario Usuario { get; set; }
}
```

---

## 🎯 Características Principales del ORM

### 1. Abstracción de la Base de Datos
No necesitas escribir SQL directamente. Usas **LINQ** (Language Integrated Query).

```csharp
// En lugar de: SELECT * FROM Usuarios WHERE Nombre LIKE 'Juan%'
var usuarios = await context.Usuarios
    .Where(u => u.Nombre.StartsWith("Juan"))
    .ToListAsync();

// En lugar de: SELECT COUNT(*) FROM Pedidos WHERE Total > 100
var cantidadPedidos = await context.Pedidos
    .CountAsync(p => p.Total > 100);
```

### 2. LINQ (Language Integrated Query)
Permite hacer consultas usando sintaxis de C#.

```csharp
// Consultas básicas
var usuariosActivos = await context.Usuarios
    .Where(u => u.FechaRegistro > DateTime.Now.AddDays(-30))
    .OrderBy(u => u.Nombre)
    .Take(10)
    .ToListAsync();

// Consultas con JOIN
var usuariosConPedidos = await context.Usuarios
    .Include(u => u.Pedidos)  // JOIN automático
    .Where(u => u.Pedidos.Any())
    .ToListAsync();

// Agrupaciones
var pedidosPorMes = await context.Pedidos
    .GroupBy(p => p.Fecha.Month)
    .Select(g => new { Mes = g.Key, Cantidad = g.Count() })
    .ToListAsync();
```

### 3. Change Tracking (Seguimiento de Cambios)
Entity Framework rastrea automáticamente los cambios en los objetos.

```csharp
// Obtener usuario
var usuario = await context.Usuarios.FirstAsync(u => u.Id == 1);

// Modificar (EF detecta el cambio automáticamente)
usuario.Email = "nuevo@email.com";

// Guardar todos los cambios pendientes
await context.SaveChangesAsync();  // Ejecuta UPDATE automáticamente
```

### 4. Manejo de Transacciones
Garantiza la integridad de los datos en operaciones múltiples.

```csharp
using (var transaction = await context.Database.BeginTransactionAsync())
{
    try
    {
        // Múltiples operaciones
        var usuario = new Usuario { Nombre = "Juan", Email = "juan@test.com" };
        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();
        
        var pedido = new Pedido { UsuarioId = usuario.Id, Total = 100 };
        context.Pedidos.Add(pedido);
        await context.SaveChangesAsync();
        
        // Si todo sale bien, confirma los cambios
        await transaction.CommitAsync();
    }
    catch
    {
        // Si algo falla, revierte todo
        await transaction.RollbackAsync();
        throw;
    }
}
```

### 5. Migraciones de Esquema
Mantiene sincronizada la estructura de la base de datos con tu código.

```bash
# Crear migración
dotnet ef migrations add AgregarTablaProductos

# Aplicar migración a la BD
dotnet ef database update
```

```csharp
// Migración generada automáticamente
public partial class AgregarTablaProductos : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            name: "Productos",
            columns: table => new
            {
                Id = table.Column<int>(nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Nombre = table.Column<string>(maxLength: 100, nullable: false),
                Precio = table.Column<decimal>(nullable: false)
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Productos", x => x.Id);
            });
    }
}
```

---

## ⚙️ Connection Strings

El **Connection String** es la cadena que le dice a Entity Framework cómo conectarse a la base de datos.

### Configuración en appsettings.json
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MiApp;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

### Configuración en Program.cs
```csharp
// Registrar DbContext en DI
builder.Services.AddDbContext<MiDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
```

---

## 💻 Ejemplo Práctico Completo

### 1. Modelos
```csharp
public class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Email { get; set; }
    public DateTime FechaCreacion { get; set; } = DateTime.Now;
}
```

### 2. DbContext
```csharp
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<Usuario> Usuarios { get; set; }
}
```

### 3. Servicio con DI
```csharp
public class UsuarioService
{
    private readonly AppDbContext context;
    
    public UsuarioService(AppDbContext context)
    {
        this.context = context;
    }
    
    public async Task<List<Usuario>> ObtenerTodosAsync()
    {
        return await context.Usuarios.ToListAsync();
    }
    
    public async Task<Usuario> CrearAsync(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
        await context.SaveChangesAsync();
        return usuario;
    }
    
    public async Task<Usuario> ActualizarAsync(Usuario usuario)
    {
        context.Usuarios.Update(usuario);
        await context.SaveChangesAsync();
        return usuario;
    }
    
    public async Task EliminarAsync(int id)
    {
        var usuario = await context.Usuarios.FindAsync(id);
        if (usuario != null)
        {
            context.Usuarios.Remove(usuario);
            await context.SaveChangesAsync();
        }
    }
}
```

### 4. Controlador API
```csharp
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService usuarioService;
    
    public UsuariosController(UsuarioService usuarioService)
    {
        this.usuarioService = usuarioService;
    }
    
    [HttpGet]
    public async Task<ActionResult<List<Usuario>>> Get()
    {
        var usuarios = await usuarioService.ObtenerTodosAsync();
        return Ok(usuarios);
    }
    
    [HttpPost]
    public async Task<ActionResult<Usuario>> Post([FromBody] Usuario usuario)
    {
        var nuevoUsuario = await usuarioService.CrearAsync(usuario);
        return CreatedAtAction(nameof(Get), new { id = nuevoUsuario.Id }, nuevoUsuario);
    }
}
```

---

## ✨ Ventajas del ORM

### ✅ Clean Code (Código Limpio)
- Reduce la cantidad de código SQL repetitivo
- Menos propenso a errores de sintaxis SQL
- Código más legible y mantenible

### ✅ Cambio de Base de Datos
```csharp
// Cambiar de SQL Server a PostgreSQL es solo cambiar el provider
// De esto:
options.UseSqlServer(connectionString);

// A esto:
options.UseNpgsql(connectionString);
```

### ✅ Mejora el Mantenimiento
- IntelliSense completo en las consultas
- Refactoring automático
- Detección de errores en tiempo de compilación

---

## 🔧 Configuración Básica Paso a Paso

### 1. Instalar Paquetes NuGet
```bash
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
```

### 2. Configurar en Program.cs
```csharp
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<UsuarioService>();
```

### 3. Crear y Aplicar Migración
```bash
dotnet ef migrations add InicialCreate
dotnet ef database update
```

---

## 📝 Conceptos Clave para Recordar

- **ORM**: Mapea objetos C# a tablas de base de datos
- **Entity Framework**: ORM oficial de Microsoft para .NET
- **DbContext**: Clase que representa la sesión con la BD
- **LINQ**: Sintaxis para hacer consultas usando C#
- **Change Tracking**: EF rastrea cambios automáticamente
- **SaveChanges()**: Persiste todos los cambios pendientes
- **Migraciones**: Mantienen sincronizada la estructura de la BD
- **Connection String**: Define cómo conectarse a la base de datos

El ORM simplifica enormemente el trabajo con bases de datos, permitiendo que nos enfoquemos en la lógica de negocio en lugar de escribir SQL manualmente.