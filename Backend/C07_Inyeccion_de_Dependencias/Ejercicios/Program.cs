using MiPrimerAPI.EjemploInyeccionDep;
using MiPrimerAPI.Repositories;

var builder = WebApplication.CreateBuilder(args); // builder es un objeto para configurar la aplicación

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// INYECCIÓN DE DEPENDENCIAS:
// En la Configuración de la Aplicación, se deben inyectar las
// dependencias, normalmente en un contenedor de inyección
// de dependencias. El contenedor crea y proporciona las
// instancias necesarias en el momento en que el objeto las necesita.

// Registrar la interfaz con su implementación
builder.Services.AddScoped<IEmailService, EmailService>();

// Registrar el servicio de usuario
builder.Services.AddScoped<UsuarioService>();

// Registrar InstrumentRepository como Singleton (se mantiene en memoria)
builder.Services.AddSingleton<InstrumentRepository>();

var app = builder.Build(); // app es el objeto que representa la aplicación web

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization(); // Middleware para manejar la autorización

app.MapControllers();  // Mapea las rutas a los controladores

app.Run(); // Inicia la aplicación y comienza a escuchar solicitudes HTTP
