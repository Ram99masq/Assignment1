using Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1.CommonUtility
{
    public class ReportGeneration
    {
        private string _reportType = "";
        public ReportGeneration(string reportType)
        {
            _reportType = reportType;
        }
        public void GenerateReport()
        {          
            switch (_reportType)
            {
                case "PDF": new PDFReportGeneration().GenerateReport();
                    break;
                case "CSV":
                    new CSVReportGeneration().GenerateReport();
                    break;

            }
        }
    }
}
