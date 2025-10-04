using EjerciciosORM.Modelo;
using EjerciciosORM.Repository;
using EjerciciosORM.ResponseQuery;
using Microsoft.AspNetCore.Mvc;


namespace EjerciciosORM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NorthwindController : ControllerBase
    {
        // Inyectar dependencias del repositorio
        private readonly INorthwindRepository _repository;

        public NorthwindController(INorthwindRepository repository)
        {
            this._repository = repository;
        }

        [HttpGet]
        [Route("api/TodosLosEmpleados")]
        public async Task<List<Employee>> GetAll()
        {
            return await _repository.ObtenerTodosLosEmpleados();
        }

        [HttpGet]
        [Route("api/CantidadDeEmpleados")]
        public async Task<int> ObtenerlaCantidadDeEmpleados()
        {
            return await _repository.ObtenerlaCantidadDeEmpleados();
        }

        [HttpGet]
        [Route("api/EmpleadoPorId/{id}")]
        public async Task<Employee> ObtenerEmpleadoporId(int id)
        {
            return await _repository.ObtenerEmpleadoporId(id);
        }

        [HttpGet]
        [Route("api/EmpleadoPorNombre/{nombre}")]
        public async Task<Employee> ObtenerEmpleadoporNombre(string nombre)
        {
            return await _repository.ObtenerEmpleadoporNombre(nombre);
        }

        [HttpGet]
        [Route("api/EmpleadoPorTitulo/{titulo}")]
        public async Task<int> ObtenerEmpleadoporTitulo(string titulo)
        {
            return await _repository.ObtenerEmpleadoporTitulo(titulo);
        }

        [HttpGet]
        [Route("api/EmpleadoPorCountry/{country}")]
        public async Task<Employee> ObtenerEmpleadoporCountry(string country)
        {
            return await _repository.ObtenerEmpleadoporCountry(country);
        }

        [HttpGet]
        [Route("api/EmpleadosPorTitulos/{titulo}")]
        public async Task<List<Employee>> ObtenerEmpleadosPorTitulos(string titulo)
        {
            return await _repository.ObtenerEmpleadosPorTitulos(titulo);
        }


        [HttpGet]
        [Route("api/EmpleadoMasGrande")]
        public async Task<Employee> ObtenerEmpleadoMasGrande()
        {
            return await _repository.ObtenerEmpleadoMasGrande();
        }


        [HttpGet]
        [Route("api/ProductosQueContienen/{palabra}")]
        public async Task<List<Products>> ObtenerProductosQueContienen(string palabra)
        {
            return await _repository.ObtenerProductosQueContienen(palabra);
        }

        [HttpGet]
        [Route("api/ProductosConCategoria")]
        public async Task<ActionResult<List<ProductWithCategoryDTO>>> ObtenerProductosConCategoria()
        {
            return await _repository.ObtenerProductosConCategoria();
        }


    }
}
