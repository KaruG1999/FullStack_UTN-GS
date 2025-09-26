using System.Collections.Generic; // Necesario para usar List<T> ???

namespace MiPrimerAPI.Repositories
{
    // Clase que simula un "repositorio" en memoria
    public class InstrumentRepository
    {
        // Propiedad pública con la lista de instrumentos
        public List<string> Instruments { get; set; }

        // Constructor: inicializa la lista con algunos valores por defecto
        // Importante que sea estatico lista y elemento para que no se pierdan los datos
        public InstrumentRepository()
        {
            Instruments = new List<string> { "Guitarra", "Batería", "Piano" };
        }



    }
}