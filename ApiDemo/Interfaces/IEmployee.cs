using ApiDemo.Model;
using ApiDemo.Model.Message;

namespace ApiDemo.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<T> GetEmployee<T>(EmployeeFilterModel filters = null);
        IEnumerable<TResult> GetEmployee<TFirst, TSecond, TResult>(Func<TFirst, TSecond, TResult> map, EmployeeFilterModel filters = null);
        Response AddEmployee(EmployeeModel employee);
        Response UpdateEmployee(EmployeeModel employee);
        Response DeleteEmployee(int id);
    }
}
