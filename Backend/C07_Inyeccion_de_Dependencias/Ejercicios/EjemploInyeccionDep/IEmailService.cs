namespace MiPrimerAPI.EjemploInyeccionDep
{
    public interface IEmailService
    {
        void Enviar(string email, string mensaje);
        bool ValidarEmail(string email);
    }
}
