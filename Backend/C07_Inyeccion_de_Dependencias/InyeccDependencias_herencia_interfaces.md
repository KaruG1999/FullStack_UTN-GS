# Backend - Herencia, Interfaces e Inyección de Dependencias

## 🔗 Conexión con APIs
Cuando trabajamos con APIs, necesitamos organizar nuestro código de manera eficiente. Los conceptos que veremos hoy nos ayudan a:
- **Estructurar servicios** que consuman APIs externas
- **Reutilizar código** común entre diferentes endpoints
- **Facilitar el testing** y mantenimiento de nuestros servicios

---

## 🧬 Herencia

### ¿Qué es la Herencia?
La herencia permite que una clase (clase hija) adquiera las propiedades y métodos de otra clase (clase padre), evitando la duplicación de código.

### Ejemplo Práctico
```csharp
// Clase base
public class Animal
{
    public string Nombre { get; set; }
    public int Edad { get; set; }
    
    public virtual void Comer()
    {
        Console.WriteLine($"{Nombre} está comiendo");
    }
    
    public virtual void Dormir()
    {
        Console.WriteLine($"{Nombre} está durmiendo");
    }
}

// Clase derivada
public class Perro : Animal
{
    public string Raza { get; set; }
    
    // Sobrescribir método padre
    public override void Comer()
    {
        Console.WriteLine($"{Nombre} el perro está comiendo croquetas");
    }
    
    // Método propio
    public void Ladrar()
    {
        Console.WriteLine($"{Nombre} está ladrando: ¡Guau!");
    }
}

// Uso
Perro miPerro = new Perro 
{ 
    Nombre = "Max", 
    Edad = 3, 
    Raza = "Golden" 
};

miPerro.Comer();    // "Max el perro está comiendo croquetas"
miPerro.Dormir();   // "Max está durmiendo" (heredado)
miPerro.Ladrar();   // "Max está ladrando: ¡Guau!" (propio)
```

### Palabras Clave
- **`virtual`**: Permite que el método sea sobrescrito en clases hijas
- **`override`**: Sobrescribe un método virtual de la clase padre
- **`base`**: Referencia a la clase padre

---

## 🎯 Interfaces

### ¿Qué es una Interfaz?
Una interfaz define un "contrato" que las clases deben cumplir. Especifica **qué métodos** debe tener una clase, pero no **cómo** implementarlos.

### Ejemplo Práctico
```csharp
// Definir interfaz
public interface INotificacion
{
    void EnviarMensaje(string destinatario, string mensaje);
    bool ValidarDestinatario(string destinatario);
}

// Implementación por Email
public class EmailService : INotificacion
{
    public void EnviarMensaje(string destinatario, string mensaje)
    {
        Console.WriteLine($"Enviando email a {destinatario}: {mensaje}");
        // Lógica específica para enviar email
    }
    
    public bool ValidarDestinatario(string destinatario)
    {
        return destinatario.Contains("@");
    }
}

// Implementación por SMS
public class SmsService : INotificacion
{
    public void EnviarMensaje(string destinatario, string mensaje)
    {
        Console.WriteLine($"Enviando SMS a {destinatario}: {mensaje}");
        // Lógica específica para enviar SMS
    }
    
    public bool ValidarDestinatario(string destinatario)
    {
        return destinatario.All(char.IsDigit) && destinatario.Length >= 10;
    }
}
```

### Ventajas de las Interfaces
- **Flexibilidad**: Múltiples implementaciones de la misma interfaz
- **Testabilidad**: Facilita crear mocks para testing
- **Desacoplamiento**: El código depende de la interfaz, no de la implementación específica

---

## 💉 Inyección de Dependencias

### ¿Qué es?
La inyección de dependencias es una técnica donde los objetos reciben sus dependencias desde el exterior, en lugar de crearlas internamente.

### Sin Inyección de Dependencias ❌
```csharp
public class UsuarioService
{
    private EmailService emailService;
    
    public UsuarioService()
    {
        // Problema: Fuertemente acoplado a EmailService
        emailService = new EmailService();
    }
    
    public void NotificarUsuario(string email, string mensaje)
    {
        emailService.EnviarMensaje(email, mensaje);
    }
}
```

**Problemas:**
- Difícil de testear
- Fuertemente acoplado
- No se puede cambiar fácilmente la implementación

### Con Inyección de Dependencias ✅
```csharp
public class UsuarioService
{
    private readonly INotificacion notificacionService;
    
    // Recibe la dependencia por el constructor
    public UsuarioService(INotificacion notificacionService)
    {
        this.notificacionService = notificacionService;
    }
    
    public void NotificarUsuario(string destinatario, string mensaje)
    {
        if (notificacionService.ValidarDestinatario(destinatario))
        {
            notificacionService.EnviarMensaje(destinatario, mensaje);
        }
    }
}
```

### Configuración en .NET (Program.cs)
```csharp
// Registrar servicios en el contenedor DI
builder.Services.AddScoped<INotificacion, EmailService>();
builder.Services.AddScoped<UsuarioService>();

// El framework se encarga de inyectar automáticamente
```

### Uso en Controladores
```csharp
[ApiController]
[Route("api/[controller]")]
public class UsuariosController : ControllerBase
{
    private readonly UsuarioService usuarioService;
    
    // DI automática
    public UsuariosController(UsuarioService usuarioService)
    {
        this.usuarioService = usuarioService;
    }
    
    [HttpPost("notificar")]
    public IActionResult NotificarUsuario([FromBody] NotificacionRequest request)
    {
        usuarioService.NotificarUsuario(request.Email, request.Mensaje);
        return Ok("Notificación enviada");
    }
}
```

---

## 🔧 Ejemplo Completo Integrando Conceptos

```csharp
// 1. Interfaz base
public interface IRepositorio<T>
{
    Task<T> ObtenerPorIdAsync(int id);
    Task<List<T>> ObtenerTodosAsync();
    Task CrearAsync(T entidad);
    Task ActualizarAsync(T entidad);
}

// 2. Clase base con herencia
public abstract class RepositorioBase<T> : IRepositorio<T>
{
    protected readonly string connectionString;
    
    protected RepositorioBase(string connectionString)
    {
        this.connectionString = connectionString;
    }
    
    // Método común a todos los repositorios
    protected virtual async Task<bool> ExisteAsync(int id)
    {
        // Lógica común de validación
        return true;
    }
    
    // Métodos abstractos que deben implementar las clases hijas
    public abstract Task<T> ObtenerPorIdAsync(int id);
    public abstract Task<List<T>> ObtenerTodosAsync();
    public abstract Task CrearAsync(T entidad);
    public abstract Task ActualizarAsync(T entidad);
}

// 3. Implementación específica
public class UsuarioRepositorio : RepositorioBase<Usuario>
{
    public UsuarioRepositorio(string connectionString) : base(connectionString) { }
    
    public override async Task<Usuario> ObtenerPorIdAsync(int id)
    {
        if (!await ExisteAsync(id)) return null;
        
        // Lógica específica para obtener usuario
        return new Usuario { Id = id, Nombre = "Usuario " + id };
    }
    
    // Implementar otros métodos...
}

// 4. Servicio que usa DI
public class UsuarioService
{
    private readonly IRepositorio<Usuario> repositorio;
    private readonly INotificacion notificacion;
    
    public UsuarioService(IRepositorio<Usuario> repositorio, INotificacion notificacion)
    {
        this.repositorio = repositorio;
        this.notificacion = notificacion;
    }
    
    public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
    {
        await repositorio.CrearAsync(usuario);
        notificacion.EnviarMensaje(usuario.Email, "¡Bienvenido!");
        return usuario;
    }
}
```

---

## 🚀 Conexión con el Próximo Tema: ORM

Los conceptos que acabamos de ver son fundamentales para trabajar con **ORM (Object-Relational Mapping)**:

- **Herencia**: Los modelos de ORM heredan funcionalidad común
- **Interfaces**: Definimos contratos para repositorios de datos  
- **Inyección de Dependencias**: Los contextos de base de datos se inyectan en nuestros servicios

En la próxima clase veremos cómo Entity Framework implementa estos patrones para simplificar el acceso a bases de datos.

---

## 📝 Conceptos Clave para Recordar

- **Herencia**: Reutiliza código entre clases relacionadas (`class Hijo : Padre`)
- **Interfaces**: Define contratos que las clases deben cumplir (`interface INombre`)
- **Inyección de Dependencias**: Recibe dependencias por constructor
- **Desacoplamiento**: Las clases dependen de abstracciones, no de implementaciones concretas
- **Flexibilidad**: Facilita cambiar implementaciones sin modificar el código cliente