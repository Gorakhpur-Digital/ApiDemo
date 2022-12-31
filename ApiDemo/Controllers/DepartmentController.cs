using ApiDemo.Interfaces;
using ApiDemo.Model;
using ApiDemo.Model.Message;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ApiDemo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartment _department;

        public DepartmentController(IDepartment department)
        {
            _department = department;
        }

        // GET: api/<DepartmentController>
        [HttpGet]
        public IEnumerable<DepartmentModel> Get()
        {
            var departmentList = _department.GetDepartment<DepartmentModel>();
            return departmentList;
        }

        // GET api/<DepartmentController>/5
        [HttpGet("{id}")]
        public DepartmentModel Get(int id)
        {
            var departmentList = _department.GetDepartment<DepartmentModel>(new DepartmentFilterModel { DepartmentId = id }).FirstOrDefault();
            return departmentList;
        }

        // POST api/<DepartmentController>
        [HttpPost]
        public Response Post([FromBody] DepartmentModel department)
        {
            DepartmentModel departmentModel = new DepartmentModel()
            {
                DepartmentName = department.DepartmentName,
                IsActive = department.IsActive
            };

            Response res = _department.AddDepartment(departmentModel);
            return res;
        }

        // PUT api/<DepartmentController>/5
        [HttpPut("{id}")]
        public Response Put(int id, [FromBody] DepartmentModel department)
        {
            var oldDepartment = _department.GetDepartment<DepartmentModel>(new DepartmentFilterModel { DepartmentId = id }).FirstOrDefault();
            if (oldDepartment == null)
            {
                var response = new Response
                {
                    Status = DbStatus.fail.ToString(),
                    Message = "Invalid department id"
                };
                return response;
            }

            DepartmentModel departmentModel = new DepartmentModel()
            {
                DepartmentId = oldDepartment.DepartmentId,
                DepartmentName = department.DepartmentName,
                IsActive = department.IsActive
            };

            Response res = _department.UpdateDepartment(departmentModel);
            return res;
        }

        // DELETE api/<DepartmentController>/5
        [HttpDelete("{id}")]
        public Response Delete(int id)
        {
            var res = _department.DeleteDepartment(id);
            return res;
        }
    }
}
