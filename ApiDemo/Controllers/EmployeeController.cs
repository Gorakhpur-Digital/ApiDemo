using ApiDemo.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/Employee
        [HttpGet]
        public IEnumerable<EmployeeModel> GetAllEmployee()
        {
            List<EmployeeModel> emp = new List<EmployeeModel>()
            {
                new EmployeeModel {Id = 1, Nmae = "Arvind", Mobile = "1234", Email="arvind@gmail.com"},
                new EmployeeModel {Id = 2, Nmae = "Akash", Mobile = "9876", Email="akash@gmail.com"},
                new EmployeeModel {Id = 3, Nmae = "Viskah", Mobile = "7654", Email="viska@gmail.com"},
                new EmployeeModel {Id = 4, Nmae = "Abahy", Mobile = "98765", Email="abhay@gmail.com"},
            };
            return emp;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public EmployeeModel GetAllEmployee(int id)
        {
            List<EmployeeModel> emp = new List<EmployeeModel>()
            {
                new EmployeeModel {Id = 1, Nmae = "Arvind", Mobile = "1234", Email="arvind@gmail.com"},
                new EmployeeModel {Id = 2, Nmae = "Akash", Mobile = "9876", Email="arvind@gmail.com"},
                new EmployeeModel {Id = 3, Nmae = "Viskah", Mobile = "7654", Email="arvind@gmail.com"},
                new EmployeeModel {Id = 4, Nmae = "Abahy", Mobile = "98765", Email="arvind@gmail.com"},
            };

            return emp.FirstOrDefault(x => x.Id.Equals(id));
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
