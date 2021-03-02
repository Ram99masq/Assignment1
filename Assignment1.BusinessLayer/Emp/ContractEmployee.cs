using Assignment1.Services.Interface;
using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using System.Linq;

namespace Assignment1.Services.Emp
{
    public class ContractEmployee : IEmployeeService
    {
        private readonly IDbConnection _Idbconnection;

        public ContractEmployee(IDbConnection dbConnection)
        {
            _Idbconnection = dbConnection;
        }

        public async Task<IEnumerable<Employee>> GetEmployeeDetails(int employeeId)
        {
            IEnumerable<Employee> empList = null;
            try
            {
                using (IDbConnection con = _Idbconnection)
                {
                    con.Open();
                    var EmployeeParams = new DynamicParameters();
                    EmployeeParams.Add("@EmployeeId", employeeId, dbType: DbType.Int64, direction: ParameterDirection.Input);
                    empList = await con.QueryAsync<Employee>("[dbo].[sp_GetEmployeeDetails]", param: EmployeeParams, commandType: CommandType.StoredProcedure);

                    if (empList.Count() > 0)
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

        public async Task<bool> Insert(Models.Employee employee)
        {
            await Task.Run(() =>
            {
                Console.WriteLine(" Insert Employee Method");
                // Do something
                Task.Delay(100).Wait();
                //implmentation
            });
            return true;
        }

        public async Task<bool> Update(Models.Employee employee)
        {
            await Task.Run(() =>
            {
                Console.WriteLine(" Update Employee Method");
                // Do something
                Task.Delay(100).Wait();
                //implmentation
            });
            return true;
        }

        public async Task<bool> Delete(Models.Employee employee)
        {
            await Task.Run(() =>
            {
                Console.WriteLine(" Update Employee Method");
                // Do something
                Task.Delay(100).Wait();
                //implmentation
            });
            return true;
        }
    }
}
