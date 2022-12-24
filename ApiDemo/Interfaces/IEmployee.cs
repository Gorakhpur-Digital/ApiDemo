﻿using ApiDemo.Model;
using ApiDemo.Model.Message;

namespace ApiDemo.Interfaces
{
    public interface IEmployee
    {
        IEnumerable<T> GetEmployee<T>(EmployeeFilterModel filters = null);
        Response AddEmployee(EmployeeModel employee);
        Response UpdateEmployee(EmployeeModel employee);
        Response DeleteEmployee(int id);
    }
}
