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

        // 1) GET - Obtener la lista de instrumentos
        [HttpGet]
        // ActionResult<IEnumerable<string>>: el método devuelve un resultado HTTP con (posible) contenido tipo lista de strings.
        public ActionResult<IEnumerable<string>> GetInstruments()
        {
            // Ok(...) crea una respuesta HTTP 200 con el contenido enviado en el cuerpo (la lista completa).
            return Ok(_repository.Instruments);  // Retorna la lista completa de instrumentos desde el repositorio
        }

        // 2) POST - Agregar un nuevo instrumento a la lista
        [HttpPost]
        public ActionResult<string> AddInstrument([FromBody] string instrument) // [FromBody] indica que el valor viene del cuerpo de la solicitud HTTP
        {
            _repository.Instruments.Add(instrument);
            return Ok($"Instrumento agregado: {instrument}"); // Respuesta HTTP 200 con mensaje de confirmación
        }

        // 4. PUT - Actualizar un instrumento existente por índice
        [HttpPut("{index}")] // {index} en la ruta indica que este valor se pasará como parte de la URL
        public ActionResult<string> UpdateInstrument(int index, [FromBody] string newInstrument)    
        {
            if (index < 0 || index >= _repository.Instruments.Count)
            {
                return NotFound($"No existe un instrumento en la posición {index}");
            }

            _repository.Instruments[index] = newInstrument; // Actualiza el instrumento en la posición dada
            return Ok($"Instrumento en posición {index} actualizado a: {newInstrument}");
        }

        // DELETE - Eliminar un instrumento por índice
        [HttpDelete("{id}")]
        public ActionResult<string> DeleteInstrument(int id)
        {
            if (id < 0 || id >= _repository.Instruments.Count)
            {
                // Si el índice es inválido, no hacemos nada (podríamos retornar un error si quisiéramos)
                return NotFound($"No existe un intrumento para borrar en la posición {id}");
            }
            _repository.Instruments.RemoveAt(id); // Elimina el instrumento en la posición dada
            return Ok($"Instrumento en posición {id} eliminado."); // Respuesta HTTP 200 con mensaje de confirmación
        }
    }
}
