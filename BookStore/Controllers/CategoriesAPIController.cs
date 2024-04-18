using BookStore.Models.Repositories;
using BookStore.Models.Services;
using System.Collections.Generic;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class CategoriesAPIController : ApiController
    {
        // GET api/<controller>
        public Dictionary<string, int> Get()
        {
            var _service = new CategoryService(new CategoryEFRepository());
            var data = _service.GetCategorySelectList();

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
            new CategoryService(new CategoryEFRepository()).Delete(id);
        }
    }
}