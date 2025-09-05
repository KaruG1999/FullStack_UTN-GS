using System.Collections.Generic; // Necesario para usar List<T> ???

namespace MiPrimerAPI.Repositories
{
    // Clase que simula un "repositorio" en memoria
    public class InstrumentRepository
    {
        // Propiedad pública con la lista de instrumentos
        public List<string> Instruments { get; set; }

        // Constructor: inicializa la lista con algunos valores por defecto
        public InstrumentRepository()
        {
            Instruments = new List<string> { "Guitarra", "Batería", "Piano" };
        }
    }
}