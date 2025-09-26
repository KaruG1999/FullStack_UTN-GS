using Microsoft.AspNetCore.Mvc;

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
