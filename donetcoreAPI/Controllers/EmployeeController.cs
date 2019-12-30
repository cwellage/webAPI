using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using CommandLayer;
using DataLayer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using NServiceBus;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace donetcoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        MyDB database = new MyDB();
        IEndpointInstance endpoint;
        public EmployeeController(IEndpointInstance endpoint)
        {
            this.endpoint = endpoint; //nservice bus initializer
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            Log.Information("IEnumerable<Employee> Get()");
            ValidateRequest();
            return database.Employees.Cast<Employee>();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            Log.Information("Get Employee Id {id}",id);
            return database.Employees.FirstOrDefault(a => a.Id == id);
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("[action]/{name}")]
        public IEnumerable<Employee> GetByName(string name)
        {
            Log.Information("Get Employee {name}", name);
            var employees = database.Employees.Where(a => a.EmployeeName.Contains(name));
            return employees;
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Employee emp)
        {
            Log.Information("Request to add a new Employee {name} Department {dept}", emp.EmployeeName,emp.DepartmentId);
            EmployeePostCommand postcommand = new EmployeePostCommand { DepartmentId = emp.DepartmentId, EmployeeName = emp.EmployeeName };
            var task = endpoint.SendLocal(postcommand);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Employee emp)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        private void ValidateRequest()
        {
            StringValues authHeader = new StringValues();
            Request.Headers.TryGetValue("Authorization", out authHeader);
            if (authHeader[0].ToLower() != "sample")
            {
                throw new System.Web.Http.HttpResponseException(HttpStatusCode.Unauthorized);
            }
        }
    }
}
