using Assignment1.Models;
using Assignment1.Services.Interface;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1.Services.Emp
{
    public class FulltimeEmployee : IEmployeeProject
    {

        private readonly IDbConnection _Idbconnection;

        public FulltimeEmployee(IDbConnection dbConnection)
        {
            _Idbconnection = dbConnection;
        }

        public async Task<IEnumerable<Employee>> GetProjectDetails(int employeeId=0)
        {
            IEnumerable<Employee> empList = null;
            try
            {
                using (IDbConnection con = _Idbconnection)
                {
                    con.Open();
                    var EmployeeParams = new DynamicParameters();
                    EmployeeParams.Add("@EmployeeId", employeeId, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    empList = await con.QueryAsync<Employee>("[dbo].[sp_GetEmployeeProjectDetails]", param: EmployeeParams, commandType: CommandType.StoredProcedure);

                    if (empList !=null && empList.Count()>0)
                    {
                        return empList;
                    }
                    con.Close();
                }
                return empList;
            }
            catch 
            {
                throw;
            }
        }

        public async Task<IEnumerable<Project>> GetAllProjectDetails()
        {
            IEnumerable<Project> projList = null;
            try
            {
                using (IDbConnection con = _Idbconnection)
                {
                    con.Open();
                    var EmployeeParams = new DynamicParameters();
                    EmployeeParams.Add("@EmployeeId", 0, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    projList = await con.QueryAsync<Project>("[dbo].[sp_GetEmployeeProjectDetails]", param: EmployeeParams, commandType: CommandType.StoredProcedure);

                    if (projList != null && projList.Count() > 0)
                    {
                        return projList;
                    }
                    con.Close();
                }
                return projList;
            }
            catch 
            {
                throw;
            }
        }
    }
}
