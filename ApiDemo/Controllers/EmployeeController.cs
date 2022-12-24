using ApiDemo.Interfaces;
using ApiDemo.Model;
using ApiDemo.Model.Message;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployee _employee;

        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }

        // GET: api/<EmployeeController>
        [HttpGet]
        public IEnumerable<EmployeeModel> Get()
        {
            var employeeList = _employee.GetEmployee<EmployeeModel>();
            return employeeList;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public EmployeeModel Get(int id)
        {
            var employeeList = _employee.GetEmployee<EmployeeModel>(new EmployeeFilterModel { Id = id }).FirstOrDefault();
            return employeeList;
        }


        // POST api/Employee
        [HttpPost]
        public Response Post([FromBody] EmployeeModel employee)
        {
            EmployeeModel model = new EmployeeModel()
            {
                Name= employee.Name,
                Mobile= employee.Mobile,
                Email= employee.Email,  
                LoginId= employee.LoginId,
                Password= employee.Password,
                DepartmentId= employee.DepartmentId,
            };

            Response res = _employee.AddEmployee(model);
            return res;
            
        }

        // PUT api/Employee/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody] EmployeeModel employee)
        {
            var oldEmployee = _employee.GetEmployee<EmployeeModel>(new EmployeeFilterModel { Id = id }).FirstOrDefault();
            if (oldEmployee == null)
            {
                var response = new Response
                {
                    Status = DbStatus.fail.ToString(),
                    Message = "Invalid employee id"
                };
                return response;
            }

            var model = new EmployeeModel()
            {
                Id = oldEmployee.Id,
                Name= employee.Name,
                Mobile= employee.Mobile,
                Email= employee.Email,
                LoginId= employee.LoginId,
                Password= employee.Password,
                DepartmentId= employee.DepartmentId
            };

            Response res = _employee.UpdateEmployee(model);

            return res;
        }

        // DELETE api/Employee/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var res = _employee.DeleteEmployee(id);
            return res;
        }
    }
}
