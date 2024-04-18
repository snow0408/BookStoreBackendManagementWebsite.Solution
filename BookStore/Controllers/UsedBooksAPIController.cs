using BookStore.Models.Repositories;
using BookStore.Models.Services;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class UsedBooksAPIController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
        public HttpResponseMessage Put(int id, [FromBody] bool status)
        {
            try
            {
                new UsedBookService(new UsedBookRepository()).UpdateProductStatus(id, status);

                var resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("更新成功"),
                    ReasonPhrase = "Update"
                };
                return resp;
            }
            catch
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("更新失敗。"),
                    ReasonPhrase = "Server Error"
                };
                return resp;
            }

        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}