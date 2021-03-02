using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Assignment1.CommonUtility.Interface;

namespace Assignment1.CommonUtility
{
    public class PDFReportGeneration : IReportGeneration
    {
        private Employee _employee;
        public PDFReportGeneration(Employee employee)
        {
            _employee = employee;
        }
        public void GenerateReport()
        {
            try
            {
                Console.WriteLine("PDF GenerateReport Method");

                // call the _employee object to Generate report
                //Implementation of PDF generation
            }
            catch
            {
                throw;
            }          
        }
    }
}
