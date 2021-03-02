using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }

        [BindProperty, DataType(DataType.Date)]
        public DateTime DOB { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string Projects { get; set; }     

    }
}
