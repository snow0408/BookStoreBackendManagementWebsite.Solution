using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class ExcelApiController : ApiController
    {
        // GET: api/ExcelApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/ExcelApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/ExcelApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ExcelApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ExcelApi/5
        public void Delete(int id)
        {
        }
    }
}
