using Microsoft.AspNetCore.Mvc; // funcionalidades necesarias para trabajar con Controllers y Web API
using MiPrimerAPI.Repositories; // !!! Extra: Importamos la clase InstrumentRepository 

namespace MiPrimerAPI.Controllers
{
    [Route("api/[controller]")] // Define la ruta base para este controlador

    [ApiController] // Indica que este controlador es una API
    public class EjerciciosController : ControllerBase // Hereda de ControllerBase para funcionalidades de API
    {
        // Instancia del repositorio (simula acceso a datos) 
        private readonly InstrumentRepository _repository = new();

        // Reemplaza todas las referencias a _repository.Instruments por InstrumentRepository.Instruments
        [HttpGet]
        public ActionResult<IEnumerable<string>> GetInstruments()
        {
            return Ok(InstrumentRepository.Instruments);  // Retorna la lista completa de instrumentos desde el repositorio
        }

        // 2) POST - Agregar un nuevo instrumento a la lista
        [HttpPost]
        public ActionResult<string> AddInstrument([FromBody] string instrument)
        {
            InstrumentRepository.Instruments.Add(instrument); // A la clase 
            return Ok($"Instrumento agregado: {instrument}");
        }

        // 4. PUT - Actualizar un instrumento existente por índice
        [HttpPut("{index}")] // {index} en la ruta indica que este valor se pasará como parte de la URL
        public ActionResult<string> UpdateInstrument(int index, [FromBody] string newInstrument)
        {
            if (index < 0 || index >= InstrumentRepository.Instruments.Count)
            {
                return NotFound($"No existe un instrumento en la posición {index}");
            }

            InstrumentRepository.Instruments[index] = newInstrument;
            return Ok($"Instrumento en posición {index} actualizado a: {newInstrument}");
        }

        // DELETE - Eliminar un instrumento por índice
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteInstrument(int id)
        {
            if (id < 0 || id >= InstrumentRepository.Instruments.Count)
            {
                return NotFound($"No existe un intrumento para borrar en la posición {id}");
            }
            InstrumentRepository.Instruments.RemoveAt(id);
            return Ok($"Instrumento en posición {id} eliminado.");
        }
    }
}
