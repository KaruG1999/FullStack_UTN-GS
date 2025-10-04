using System.ComponentModel.DataAnnotations;

namespace EjerciciosORM.Modelo
{
    public class Categories
    {
        [Key]
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

    }
}
