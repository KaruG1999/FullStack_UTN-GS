using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiPrimerAPI.Controllers
{
    // Atributos de API controller
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
       
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

    }
}
