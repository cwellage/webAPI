using System;
using System.Collections.Generic;
using System.Linq;
using DataLayer;
using Microsoft.AspNetCore.Mvc;
using NServiceBus;
using Serilog;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace donetcoreAPI.Controllers
{
    [Route("api/[controller]")]
    public class DepartmentController : Controller
    {
        MyDB database = new MyDB();
        IEndpointInstance endpoint;

        public DepartmentController(IEndpointInstance endpoint)
        {
            this.endpoint = endpoint; //nservice bus initializer
        }
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<Department> Get()
        {
            Log.Information("IEnumerable<Department> Get()");
            return database.Departments.Cast<Department>();
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
            throw new NotImplementedException();
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
