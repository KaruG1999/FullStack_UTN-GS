namespace EjerciciosORM.Modelo
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime HireDate { get; set; }
    }
}
