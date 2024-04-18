using BookStore.Models.Repositories;
using BookStore.Models.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class BookAPIController : ApiController
    {
        // GET api/<controller>
        public Dictionary<string, int> Get()
        {
            var _service = new BooksService(new BooksEFRepository());
            var data = _service.GetBookSelectList();

            return data;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}