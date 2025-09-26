using Microsoft.AspNetCore.Mvc;
using MiPrimerAPI.EjemploInterfaz;

namespace MiPrimerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalController : ControllerBase
    {
        [HttpGet("perro")]
        public string GetPerro()
        {
            IAnimal perro = new Perro("Kuki");
            return $"{perro.Name} dice {perro.HacerSonido()}";
        }

        [HttpGet("gato")]
        public string GetGato()
        {
            IAnimal gato = new Gato("Grian");
            return $"{gato.Name} dice {gato.HacerSonido()}";
        }
    }
}