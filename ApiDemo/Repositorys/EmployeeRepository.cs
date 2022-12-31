using ApiDemo.DataAccess;
using ApiDemo.Interfaces;
using ApiDemo.Model;
using ApiDemo.Model.Message;

namespace ApiDemo.Repositorys
{
    public class EmployeeRepository : IEmployee
    {
        private readonly IDapperORM _dapper;

        public EmployeeRepository(IDapperORM dapper)
        {
            _dapper = dapper;
        }

        public Response AddEmployee(EmployeeModel employee)
        {
            var param = new
            {
                employee.Name,
                employee.Mobile,
                employee.Email,
                employee.LoginId,
                employee.Password,
                employee.CreateDate,
                employee.DepartmentId,
                employee.CreateBy
            };

            return _dapper.ReturnList<Response, dynamic>("Employee_Add", param).FirstOrDefault() ?? new Response();
        }

        public IEnumerable<T> GetEmployee<T>(EmployeeFilterModel filters = null)
        {
            return _dapper.ReturnList<T, dynamic>("Employee_List", filters);
        }

        public Response UpdateEmployee(EmployeeModel employee)
        {

            var param = new
            {
                employee.Id,
                employee.Name,
                employee.Mobile,
                employee.Email,
                employee.LoginId,
                employee.Password,
                employee.DepartmentId,
            };

            return _dapper.ReturnList<Response, dynamic>("Employee_Update",param).FirstOrDefault() ?? new Response();
        }

        public Response DeleteEmployee(int id)
        {
            var param  = new
            {
                Id = id,
            };

            return _dapper.ReturnList<Response, dynamic>("Employee_Delete", param).FirstOrDefault() ?? new Response();
        }

        public IEnumerable<TResult> GetEmployee<TFirst, TSecond, TResult>(Func<TFirst, TSecond, TResult> map, EmployeeFilterModel filters = null)
        {
            if (filters == null)
                filters = new EmployeeFilterModel();

            return _dapper.ReturnList<TFirst, TSecond, TResult, dynamic>("Employee_List_Mapping", map, filters);
        }
    }
}
