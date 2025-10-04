using System.ComponentModel.DataAnnotations;

namespace EjerciciosORM.Modelo
{
    public class Region
    {
        [Key]
        public int RegionID { get; set; }
        public string RegionDescription { get; set; }
    }
}
