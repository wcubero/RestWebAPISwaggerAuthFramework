using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompanyRestAPI.Models
{
    public static class Company
    {
        static CompanyEntities dbContext = new CompanyEntities();

        public static List<Employee> GetEmployees()
        {
            return dbContext.Employees.ToList();
        }

        public static bool FoundEmployee(int employeeId)
        {
            var employee = dbContext.Employees.Where(e => e.Id == employeeId).SingleOrDefault();

            if (employee != null)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

        public static List<Employee> GetEmployee(int id)
        {
            return dbContext.Employees.Where(e => e.Id == id).ToList();
        }

        public static List<Employee> GetEmployee(int id, string name)
        {
            return dbContext.Employees.Where(e => e.Id == id && e.Name == name).ToList();
        }

        public static int AddEmployee(Employee emp)
        {
            dbContext.Employees.Add(emp);
            dbContext.SaveChanges();

            return emp.Id;
        }

        public static bool UpdateEmployee(Employee emp)
        {
            var employee = dbContext.Employees.Where(e => e.Id == emp.Id).SingleOrDefault();

            if (employee != null)
            {
                employee.Name = emp.Name;
                employee.Country = emp.Country;

                dbContext.SaveChanges();
            }

            return true;
        }

        public static bool DeleteEmployee(int employeeId)
        {
            var employee = dbContext.Employees.Where(e => e.Id == employeeId).SingleOrDefault();

            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                dbContext.SaveChanges();
            }

            return true;
        }
    }
}