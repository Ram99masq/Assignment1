using Assignment1.Services.Interface;
using Assignment1.Services.Emp;
using Assignment1.Services.Observer;
using Assignment1.CommonUtility;
using Assignment1.CommonUtility.Interface;
using Assignment1.Models;
using System;
using System.Collections.Generic;

namespace Assignment1.ConsoleApp
{
    class Program
    {
        static async System.Threading.Tasks.Task Main(string[] args)
        {

            try
            { 

            ProductSubject subject = new ProductSubject();
            IObserver observer1 = new Observer("observer1");
            subject.Register(observer1);
            IObserver observer2 = new Observer("observer2");
            subject.Register(observer2);
            subject.ProductCount++;
            //Product is added to the inventory and it will notified to all subscribers
            IObserver observer3 = new Observer("observer3");
            subject.Register(observer3);
            subject.Unregister(observer1);
            subject.ProductCount++;


            //Employee details
            List<IEmployeeService> employeeList = new List<IEmployeeService>();
            employeeList.Add(new ContractEmployee(null));
            foreach (IEmployeeService e in employeeList)
            {
                await e.GetEmployeeDetails(99);
            }

            List<IEmployeeProject> projectList = new List<IEmployeeProject>();
            projectList.Add(new FulltimeEmployee(null));
            foreach (IEmployeeProject e in projectList)
            {
                await e.GetProjectDetails(99);
            }

            //Single reponsibility and Dependency injection - constructor
            var employee = new Employee { Name = "ramkumar", DOB = new DateTime(1988, 09, 10), Address = "Bangalore", EmployeeId = 99, PhoneNumber = "9739646857" };
            IReportGeneration reportGeneration = new PDFReportGeneration(employee);
            reportGeneration.GenerateReport();

            reportGeneration = new CSVReportGeneration(employee);
            reportGeneration.GenerateReport();

            // Common Utitlies - email and slack
            IMessenger messenger = new Email();
            await messenger.SendMessage();

            messenger = new SlackClient();
            await messenger.SendMessage();

            //Notification by Email and slack
            Notification notification = new Notification(new Email());
            await messenger.SendMessage();

            Console.WriteLine("Hello World!");

            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
