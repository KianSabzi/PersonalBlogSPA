using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace PersonalBlog.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        // GET: api/student
        [HttpGet("values")]
        public IEnumerable<string> GetValues()
        {
            return new string[] { "value1", "value2" };
        }
        [HttpGet("value/{id}")]
        [AllowAnonymous]
        // GET: api/student/5
        public string GetValue(int id)
        {
            return "value" + id;
        }

        // POST: api/student
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/student/5
        public void Delete(int id)
        {
        }
    }
}
