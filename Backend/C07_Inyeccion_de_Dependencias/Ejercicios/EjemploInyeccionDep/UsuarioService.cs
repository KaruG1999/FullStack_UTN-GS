namespace MiPrimerAPI.EjemploInyeccionDep
{
    public class UsuarioService
    {

        private readonly IEmailService emailService; // Dependencia

        // Dependencia inyectada a través del constructor
        public UsuarioService(IEmailService emailService)
        {
            this.emailService = emailService;
        }

        public void NotificarUsuario(string email)
        {

            emailService.Enviar(email, "Notificación");

        }

        public string CrearUsuario(string nombre, string email)
        {
            try
            {
                // Validar email antes de crear usuario
                if (!emailService.ValidarEmail(email))
                {
                    return "Email inválido";
                }

                // Simular creación de usuario
                Console.WriteLine($"Creando usuario: {nombre} con email: {email}");

                // Enviar notificación de bienvenida
                emailService.Enviar(email, $"¡Bienvenido {nombre}! Tu cuenta ha sido creada.");

                return $"Usuario {nombre} creado exitosamente";
            }
            catch (Exception ex)
            {
                return $"Error al crear usuario: {ex.Message}"; // ex.Message contiene el mensaje de la excepción
            }
        }

        public string EnviarMensajePersonalizado(string email, string mensaje)
        {
            try
            {
                if (emailService.ValidarEmail(email))
                {
                    emailService.Enviar(email, mensaje);
                    return "Mensaje enviado exitosamente";
                }
                return "Email inválido";
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }



        }
    }
}
