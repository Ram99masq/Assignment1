using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Services.Interface
{
    public interface IEmployeeProject
    {
        Task<IEnumerable<Employee>> GetProjectDetails(int employeeId=0);
        Task<IEnumerable<Project>> GetAllProjectDetails();
    }
}
