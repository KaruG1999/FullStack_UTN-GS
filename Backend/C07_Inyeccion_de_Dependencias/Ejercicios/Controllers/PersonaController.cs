using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static MiPrimerAPI.EjemploDeHerencia.Persona;

namespace MiPrimerAPI.Controllers
{
    public class PersonaController : Controller
    {
        [HttpGet]
        public Cliente Get(string nombre, string apellido, int dni, int idCliente, string email, int telefono)
        {
            Cliente cliente = new Cliente(nombre, apellido, dni, idCliente, email, telefono);
            
            return cliente;
        }
    }
}
