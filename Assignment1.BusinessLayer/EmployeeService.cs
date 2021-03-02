using Assignment1.Services.Interface;
using System;
using Assignment1.CommonUtility;
using System.Threading.Tasks;
using Assignment1.Models;
using System.Data;
using System.Collections.Generic;
using Dapper;
using System.Linq;

namespace Assignment1.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IDbConnection _Idbconnection;

        public EmployeeService(IDbConnection dbConnection)
        {
            _Idbconnection = dbConnection;
        }


        public async Task<IEnumerable<Employee>> GetEmployeeDetails(int employeeId)
        {
            //return new Employee { Name = "ramkumar", DOB = new DateTime(1988, 09, 10), Address = "Bangalore", EmployeeId = 99, PhoneNumber = "9739646857" };
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
                return null;
            }
            catch (Exception e)
            {
                throw;
            }

            //return "Child Employee";
        }

        public async Task<bool> Insert(Models.Employee employee)
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

        //thread safe by locking
        public async Task<bool> Update(Models.Employee employee)
        {
            object x = new object();           
                await Task.Run(() =>
                {
                    lock (x)
                    {
                        Console.WriteLine(" Update Employee Method");
                        // Do something
                        Task.Delay(100).Wait();
                        //implmentation
                    }
                });            
            return true;
        }
        

        //thread safe by locking
        public async Task<bool> Delete(Models.Employee employee)
        {
            object x = new object();
            await Task.Run(() =>
            {
                lock (x)
                {
                    Console.WriteLine(" delete Employee Method");
                    // Do something
                    Task.Delay(100).Wait();
                    //implmentation
                }
            });
            return true;
        }
    }
}
