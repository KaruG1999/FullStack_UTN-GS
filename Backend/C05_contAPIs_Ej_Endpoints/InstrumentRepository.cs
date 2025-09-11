using System.Collections.Generic; // Necesario para usar List<T> ???

namespace MiPrimerAPI.Repositories
{
    // Clase que simula un "repositorio" en memoria
    public class InstrumentRepository
    {
        // Propiedad pública y ESTATICA con la lista de instrumentos
        public static List<string> Instruments { get; set; }

        // Constructor: inicializa la lista con algunos valores por defecto
        // Importante que sea estatico lista y elemento para que no se pierdan los datos
        static InstrumentRepository()
        {
            Instruments = new List<string> { "Guitarra", "Batería", "Piano" };
        }



    }
}