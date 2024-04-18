using BookStore.Models.Repositories;
using BookStore.Models.Services;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class ProductsAPIController : ApiController
    {
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                new ProductService(new ProductEFRepository()).Delete(id);

                var resp = Request.CreateResponse(HttpStatusCode.OK);
                resp.StatusCode = HttpStatusCode.OK;
                resp.Content = new StringContent("刪除成功");
                return resp;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("無法刪除，訂單或是進貨紀錄需要此項資訊。"),
                    ReasonPhrase = "Server Error"
                };

                //throw new HttpResponseException(resp);
                return resp;
            }
        }
    }
}
