namespace MiPrimerAPI.EjemploInterfaz
{
    public class Perro : IAnimal
    {
        public Perro(string nombre)
        {
            Name = nombre;
        }

        public string Name { get; }

        public string HacerSonido()
        {
            return "Guau Guau";
        }
    }
}