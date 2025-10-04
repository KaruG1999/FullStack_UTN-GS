using EjerciciosORM.Contexto;
using EjerciciosORM.Modelo;
using EjerciciosORM.Repository;
using EjerciciosORM.ResponseQuery;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EjerciciosORM.Repository
{
    public class NorthwindRepository : INorthwindRepository
    {
        //Inyeccion de BD
        private readonly DataContext _context;

        // Inyectar el DataContext a través del constructor (ctor tab tab)
        public NorthwindRepository(DataContext context)
        {
                this._context = context;
        }
        public async Task<List<Employee>> ObtenerTodosLosEmpleados()
        {
            return await this._context.Employees.ToListAsync();
        }

        public async Task<int> ObtenerlaCantidadDeEmpleados()
        {
            return await _context.Employees.CountAsync();
        }

        public async Task<Employee> ObtenerEmpleadoporId (int id)
        {
            return await _context.Employees.Where(e => e.EmployeeID == id).FirstOrDefaultAsync();
        }

        public async Task<Employee> ObtenerEmpleadoporNombre (string nombre)
        {
            var result = await _context.Employees.FirstOrDefaultAsync(e => e.FirstName == nombre);
            return result;
        }

        public async Task<int> ObtenerEmpleadoporTitulo (string titulo)
        {
            var result = from emp in _context.Employees
                         where emp.Title == titulo
                         select emp.EmployeeID;
            return await result.FirstAsync();
        }

        public async Task<Employee> ObtenerEmpleadoporCountry (string country)
        {
            var result = from emp in _context.Employees
                         where emp.Country == country
                         select new Employee
                         {                            
                             FirstName = emp.FirstName,
                             LastName = emp.LastName,
                             Country = emp.Country,    
                         };
            return await result.FirstOrDefaultAsync();
        }

        public async Task<List<Employee>> ObtenerEmpleadosPorTitulos (string titulo)
        {
            var result = from emp in _context.Employees
                         where emp.Title == titulo
                         orderby emp.FirstName
                         select emp;
            return await result.ToListAsync();
        }

        public async Task<Employee> ObtenerEmpleadoMasGrande ()
        {
            var result = from emp in _context.Employees
                         orderby emp.BirthDate descending
                         select emp;
            return await result.FirstOrDefaultAsync();
        }

        public async Task<List<Products>> ObtenerProductosQueContienen(string palabra)
        {
            return await _context.Products
                                 .Where(p => EF.Functions.Like(p.ProductName, $"%{palabra}%"))
                                 .ToListAsync();
        }

        public async Task<ActionResult<List<ProductWithCategoryDTO>>> ObtenerProductosConCategoria()
        {
            var result = await (from prod in _context.Products
                                join cat in _context.Categories
                                on prod.CategoryID equals cat.CategoryID
                                select new ProductWithCategoryDTO
                                {
                                    ProductID = prod.ProductID,
                                    ProductName = prod.ProductName,
                                    CategoryName = cat.CategoryName
                                }).ToListAsync();

            return result;
        }

    }
}
