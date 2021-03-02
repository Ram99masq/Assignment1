using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Services.Interface
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> GetEmployeeDetails(int employeeId=0);

        Task<bool> Insert(Employee employee);

        Task<bool> Update(Employee employee);

        Task<bool> Delete(Employee employee);

    }
}
