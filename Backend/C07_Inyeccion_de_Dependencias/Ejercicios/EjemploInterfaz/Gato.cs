namespace MiPrimerAPI.EjemploInterfaz
{
    public class Gato : IAnimal
    {
        public Gato(string nombre)
        {
            Name = nombre;
        }

        public string Name { get; }

        public string HacerSonido()
        {
            return "Miau Miau";
        }
    }
}
