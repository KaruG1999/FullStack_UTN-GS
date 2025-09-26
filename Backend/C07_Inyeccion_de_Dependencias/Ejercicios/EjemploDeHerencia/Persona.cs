namespace MiPrimerAPI.EjemploDeHerencia
{
    public class Persona
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int DNI { get; set; }

        public Persona(string nombre, string apellido, int dni)
        {
            Nombre = nombre;
            Apellido = apellido;
            DNI = dni;
        }

        public virtual void MostrarInformacion()
        {
            Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}, DNI: {DNI}");
        }

        public class Cliente: Persona
        {
            public int idCliente { get; set; }
            public string Email { get; set; }
            public int Telefono { get; set; }

            public Cliente(string nombre, string apellido, int dni, int idCliente, string email, int telefono)
                : base(nombre, apellido, dni)
            {
                this.idCliente = idCliente;
                Email = email;
                Telefono = telefono;
            }

            public override void MostrarInformacion()
            {
                Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}, DNI: {DNI}, ID Cliente: {idCliente}, Email: {Email}, Teléfono: {Telefono}");
            }
        }

        public class Proveedor: Persona {            
            public int idProveedor { get; set; }
           
            public Proveedor(string nombre, string apellido, int dni, int idProveedor)
                : base(nombre, apellido, dni)
            {
                this.idProveedor = idProveedor;
            }
            public override void MostrarInformacion()
            {
                Console.WriteLine($"Nombre: {Nombre}, Apellido: {Apellido}, DNI: {DNI}, ID Proveedor: {idProveedor}");
            }
        }

    }
}
