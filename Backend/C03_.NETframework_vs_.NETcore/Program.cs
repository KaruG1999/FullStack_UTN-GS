// En Visual studio, puedo ejecutar este programa presionando F5 o haciendo clic en "Iniciar".
// En VS Code, abre una terminal y navego a la carpeta del proyecto, luego ejecuta: dotnet run


using System; // Importa la librería básica de .NET para consola, datos, etc.

namespace MiPrimeraApp // Agrupa el código en un "espacio de nombres"
{
    class Program // Clase principal de tu programa
    {
        static void Main(string[] args) // Método de entrada, donde empieza a ejecutarse el programa
        {
            Console.WriteLine("¡Hola a todos desde C# <3 !"); // Imprime texto en la consola

            // Interacción con el usuario
            Console.Write("Ingresa tu nombre: "); // Pide que escribas algo en la consola
            string nombre = Console.ReadLine(); // Guarda lo que escribiste en la variable 'nombre'

            Console.WriteLine($"¡Hola {nombre}! Bienvenido a .NET"); // Muestra un mensaje usando la variable

            // Pausar antes de cerrar
            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey(); // Espera que presiones una tecla antes de cerrar la ventana
        }
    }
}

// En Visual studio, puedo ejecutar este programa presionando F5 o haciendo clic en "Iniciar".
// En VS Code, abre una terminal y navego a la carpeta del proyecto, luego ejecuta: dotnet run
