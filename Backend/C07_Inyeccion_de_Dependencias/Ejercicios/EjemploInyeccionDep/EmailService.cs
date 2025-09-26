namespace MiPrimerAPI.EjemploInyeccionDep
{
    public class EmailService : IEmailService
    {
        public void Enviar(string email, string mensaje)
        {
            //Simulo enviar un email
            Console.WriteLine($"Enviando email a {email} con el mensaje: {mensaje}");
        }

        public bool ValidarEmail(string email)
        {
            //Simulo validar un email
            return email.Contains("@");
        }
    }
}
