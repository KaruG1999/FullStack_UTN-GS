using EjerciciosORM.Modelo;
using EjerciciosORM.ResponseQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjerciciosORM.Repository
{
    public interface INorthwindRepository
    {
        Task<List<Employee>> ObtenerTodosLosEmpleados();
        Task<int> ObtenerlaCantidadDeEmpleados();
        Task<Employee> ObtenerEmpleadoporId(int id);
        Task<Employee> ObtenerEmpleadoporNombre(string nombre);
        Task<int> ObtenerEmpleadoporTitulo(string titulo);
        Task<Employee> ObtenerEmpleadoporCountry(string country);
        Task<List<Employee>> ObtenerEmpleadosPorTitulos(string titulo);
        Task<Employee> ObtenerEmpleadoMasGrande();
        Task<List<Products>> ObtenerProductosQueContienen(string palabra);
        Task<ActionResult<List<ProductWithCategoryDTO>>> ObtenerProductosConCategoria();
    }
}
