using Assignment1.CommonUtility.Interface;
using Assignment1.Models;
using System;

namespace Assignment1.CommonUtility
{
    public class CSVReportGeneration : IReportGeneration
    {
        private Employee _employee;
        public CSVReportGeneration(Employee employee)
        {
            _employee = employee;
        }
        public void GenerateReport()
        {
            try
            {
                Console.WriteLine("CSV GenerateReport Method");

                //Implementation of CSV generation
            }
            catch 
            {
                throw;
            }

        }
    }
}
