using HelloMVC.Business;
using HelloMVC.Models;
using HelloMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HelloMVC.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            EmployeeListViewModel employeeListViewModel = new EmployeeListViewModel();
            EmployeeBusinessLayer bl = new EmployeeBusinessLayer();
            List<Employee> employees = bl.GetEmployees();
            List<EmployeeViewModel> empViewModels = new List<EmployeeViewModel>();

            foreach (Employee emp in employees)
            {
                EmployeeViewModel empViewModel = new EmployeeViewModel();
                empViewModel.EmployeeName = emp.FirstName + " " + emp.LastName;
                empViewModel.Salary = emp.Salary.ToString("C");
                if (emp.Salary > 15000) { 
                    empViewModel.SalaryColor = "yellow"; }
                else { 
                    empViewModel.SalaryColor = "green"; 
                } 
                empViewModels.Add(empViewModel);
            }
            employeeListViewModel.Employees = empViewModels; 
          //  employeeListViewModel.UserName = "Admin"; 
            return View("Index", employeeListViewModel);  
        }


        public ActionResult AddNew()
        {
            return View("CreateEmployee");
        }

        public ActionResult SaveEmployee(Employee e, string BtnSubmit)
        {
            switch (BtnSubmit) { 
                case "Save Employee":
                    if (ModelState.IsValid)
                    {
                        EmployeeBusinessLayer empBal = new EmployeeBusinessLayer();
                        empBal.SaveEmployee(e);
                        return RedirectToAction("Index");
                    }
                    else
                    {
                         return View("CreateEmployee");
                    }
                case "Cancel": return RedirectToAction("Index"); 
            }
            return new EmptyResult();
        }
       
    
    }
}
