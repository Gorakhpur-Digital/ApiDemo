using ApiDemo.Model;
using ApiDemo.Model.Message;

namespace ApiDemo.Interfaces
{
    public interface IDepartment
    {
        IEnumerable<T> GetDepartment<T>(DepartmentFilterModel filters = null);
        Response AddDepartment(DepartmentModel department);
        Response UpdateDepartment(DepartmentModel department);
        Response DeleteDepartment(int id);
    }
}
