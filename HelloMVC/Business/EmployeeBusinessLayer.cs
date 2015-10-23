﻿using HelloMVC.DataAccessLayer;
using HelloMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HelloMVC.Business
{
    public class EmployeeBusinessLayer
    {
        public List<Employee> GetEmployees() {
            SalesERPDAL salesDal = new SalesERPDAL();
            return salesDal.Employees.ToList();
        }

        public Employee SaveEmployee(Employee e)
        {
            SalesERPDAL salesDal = new SalesERPDAL();
            salesDal.Employees.Add(e);
            salesDal.SaveChanges();
            return e;
        }
    }
}