using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace HelloMVC.Models
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; } 

       [Required(ErrorMessage="Enter First Name")]
        public string FirstName { get; set; }
        [StringLength(3,ErrorMessage="Last Name length should not be greater than 5")]
        public string LastName { get; set; } 
        public int Salary { get; set; }
    }
}