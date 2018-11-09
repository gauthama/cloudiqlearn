using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using ClassLibraryBusinessLayer;
using ClassLibraryDataModel;
using System.Web.Http;
using System.Net;

namespace WebApplicationCBD1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        static readonly string connectionString = Startup.ConnectionString;

        // GET api/values
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            //return new string[] { "value1", "value2" };
            return BusinessClass.GetAll(connectionString);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            //return "value";
            Employee emp;
            emp = BusinessClass.GetById(connectionString, id);
            if (emp == null)
            {
                //throw new HttpResponseException(HttpStatusCode.NotFound);
            }
            return emp;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Employee emp)
        {
            BusinessClass.Update(connectionString, id, emp);
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
