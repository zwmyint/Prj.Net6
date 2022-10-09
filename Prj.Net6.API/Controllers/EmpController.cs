using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Prj.Net6.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpController : ControllerBase
    {
        public List<Employee> employees = new();
        public EmpController()
        {
            employees = new List<Employee>()
            {
                new Employee { Id = 1, Name = "JKR", Age = 26 },
                new Employee { Id = 2, Name = "Tom", Age = 36 },
                new Employee { Id = 3, Name = "Micheal", Age = 46 },
                new Employee { Id = 4, Name = "Henrik", Age = 28 },
                new Employee { Id = 5, Name = "Stefan", Age = 56 },
            };
        }
        // GET: api/<EmployeeController>
        [HttpGet(nameof(GetEmployeeList))]
        public List<Employee> GetEmployeeList()
        {
            return employees;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public Employee GetEmployee(int id)
        {
            return employees.FirstOrDefault(c => c.Id.Equals(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public List<Employee> Post([FromBody] Employee employee)
        {
            employees.Add(new Employee
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age
            });
            return employees;
        }

    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

}
