using EjerciciosORM.Modelo;
using Microsoft.EntityFrameworkCore;

// Representa la sesión con la base de datos y permite realizar operaciones CRUD

namespace EjerciciosORM.Contexto
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Products> Products { get; set; }

        //public DbSet<Orders> Orders { get; set; }
        //public DbSet<OrderDetails> OrderDetails { get; set; }
        //public DbSet<Region> Region { get; set; }


    }
}
