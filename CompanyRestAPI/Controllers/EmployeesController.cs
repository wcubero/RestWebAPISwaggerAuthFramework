using CompanyRestAPI.App_Start;
using CompanyRestAPI.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CompanyRestAPI.Controllers
{
    /// <summary>
    /// Employees Controller
    /// </summary>
    public class EmployeesController : ApiController
    {
        /// <summary>
        /// Get all employees
        /// </summary>
        /// <returns></returns>
        // GET: Employees
        [Route("api/employees/getemployees")]
        [HttpGet]
        //[BasicAuthentication]
        public HttpResponseMessage GetEmployees()
        {
            try
            {

                List<Employee> listEmployee = new List<Employee>();

                listEmployee.Add(new Employee() { Id = 1, Country = "CR", Name = "Obama" });

                return Request.CreateResponse(HttpStatusCode.OK, listEmployee);

                //return Request.CreateResponse(HttpStatusCode.OK, Company.GetEmployees());
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get employee information by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: Employee based on id
        [Route("api/employees/getemployeebyid")]
        [HttpGet]
        public HttpResponseMessage GetEmployee(int id)
        {
            try
            {
                //int id = 1;
                return Request.CreateResponse(HttpStatusCode.OK, Company.GetEmployee(id));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Get employee information by id and name
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        // GET: Employee based on id and name
        [Route("api/employees/getemployee")]
        [HttpGet]
        public HttpResponseMessage GetEmployee(int id, string name)
        {
            try
            {
                //int id = 1;
                return Request.CreateResponse(HttpStatusCode.OK, Company.GetEmployee(id, name));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Add new employee
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        // POST: Add Employee
        [Route("api/employees/addemployee")]
        [HttpPost]
        public HttpResponseMessage AddEmployee([FromBody] Employee emp)
        {
            try
            {
                if (emp == null || !ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                int empId = Company.AddEmployee(emp);
                return Request.CreateResponse(HttpStatusCode.Created, empId);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Update employee based on employee id
        /// </summary>
        /// <param name="emp"></param>
        /// <returns></returns>
        // PUT: Update Employee
        [Route("api/employees/updateemployee")]
        [HttpPut]
        public HttpResponseMessage UpdateEmployee([FromBody] Employee emp)
        {
            try
            {
                if (emp == null || !ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                if (Company.FoundEmployee(emp.Id))
                {
                    bool isSuccess = Company.UpdateEmployee(emp);
                    return Request.CreateResponse(HttpStatusCode.OK, (isSuccess == true) ? "Success" : "Failure");
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound, "Failure");
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        /// <summary>
        /// Delete employee by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: Delete Employee
        [Route("api/employees/deleteemployee")]
        [HttpDelete]
        public HttpResponseMessage DeleteEmployee(int id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                if (Company.FoundEmployee(id))
                {
                    bool isSuccess = Company.DeleteEmployee(id);
                    return Request.CreateResponse(HttpStatusCode.NoContent);
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}