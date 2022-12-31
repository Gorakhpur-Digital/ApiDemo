using ApiDemo.DataAccess;
using ApiDemo.Interfaces;
using ApiDemo.Model;
using ApiDemo.Model.Message;

namespace ApiDemo.Repositorys
{
    public class DepartmentRepository : IDepartment
    {
        private readonly IDapperORM _dapper;

        public DepartmentRepository(IDapperORM dapper)
        {
            _dapper = dapper;
        }
        public Response AddDepartment(DepartmentModel department)
        {
            var param = new
            {
                department.DepartmentName,
                department.IsActive,
                department.CreateDate,
                department.CreateBy
            };
            return _dapper.ReturnList<Response , dynamic>("Department_Add",param).FirstOrDefault() ?? new Response();
        }

        public Response DeleteDepartment(int id)
        {
            var param = new
            {
                DepartmentId = id,
            };
            return _dapper.ReturnList<Response, dynamic>("Department_Delete", param).FirstOrDefault() ?? new Response();
        }

        public IEnumerable<T> GetDepartment<T>(DepartmentFilterModel filters = null)
        {
            return _dapper.ReturnList<T, dynamic>("Department_List", filters);
        }

        public Response UpdateDepartment(DepartmentModel department)
        {
            var param = new
            {
                department.DepartmentId,
                department.DepartmentName,
                department.IsActive
            };
            return _dapper.ReturnList<Response, dynamic>("Department_Update", param).FirstOrDefault() ?? new Response();
        }
    }
}
