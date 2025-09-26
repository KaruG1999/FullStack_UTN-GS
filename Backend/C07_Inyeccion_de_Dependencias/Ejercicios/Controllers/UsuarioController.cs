using Microsoft.AspNetCore.Mvc;
using MiPrimerAPI.EjemploInyeccionDep;


namespace MiPrimerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {

        // el controller puede usar métodos de UsuarioService sin necesidad de instanciarlo con new

        // Servicio inyectado
        private readonly UsuarioService usuarioService;

        //El UsuarioService se inyecta automáticamente
        public UsuarioController(UsuarioService usuarioService)
        {
            this.usuarioService = usuarioService;
        }

        //ENDPOINTS
        // Crear un usuario con nombre y email.
        [HttpPost("crear")]
        public ActionResult<object> CrearUsuario([FromBody] CrearUsuarioRequest request)
        {
            var resultado = usuarioService.CrearUsuario(request.Nombre, request.Email);

            return Ok(new
            {
                Success = resultado.StartsWith("✅"),
                Message = resultado,
                Usuario = new { request.Nombre, request.Email }
            });
        }

        // Notificar a un usuario por email.
        [HttpPost("notificar")]
        public ActionResult<object> NotificarUsuario([FromBody] NotificarRequest request)
        {
            // Usa el método original de la clase
            usuarioService.NotificarUsuario(request.Email);

            return Ok(new
            {
                Success = true,
                Message = $"Notificación enviada a {request.Email}"
            });
        }

        //Enviar un mensaje personalizado a un usuario.
        [HttpPost("mensaje-personalizado")]
        public ActionResult<object> EnviarMensaje([FromBody] MensajeRequest request)
        {
            var resultado = usuarioService.EnviarMensajePersonalizado(request.Email, request.Mensaje);

            return Ok(new
            {
                Success = resultado.StartsWith("✅"),
                Message = resultado
            });
        }
    }

    // DTO (Data Transfer Objects) para recibir datos del body de la request
    public class CrearUsuarioRequest
    {
        public string Nombre { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }

    public class NotificarRequest
    {
        public string Email { get; set; } = string.Empty;
    }

    public class MensajeRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Mensaje { get; set; } = string.Empty;
    }
}