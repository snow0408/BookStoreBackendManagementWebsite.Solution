using BookStore.Models.Dtos;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookStore.Controllers
{
    public class ProductKeywordsAPIController : ApiController
    {
        // GET api/<controller>/5
        public string Get(int productId)
        {
            var tags = new ProductKeywordService(new ProductKeywordEFRepository()).GetAllByProductId(productId);
            var tagsJson = JsonConvert.SerializeObject(tags);

            return tagsJson;
        }

        // POST api/<controller>
        public int Post([FromBody] KeywordTagDto dto)
        {
            try
            {
                var pdKeywordId = new ProductKeywordService(new ProductKeywordEFRepository()).Create(dto);

                return pdKeywordId;

            }
            catch (Exception ex)
            {
                return -1;
            }

        }


        // DELETE api/<controller>/5
        public HttpResponseMessage Delete(int keywordId, int productId)
        {
            try
            {
                new ProductKeywordService(new ProductKeywordEFRepository()).Delete(keywordId, productId);

                var resp = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StringContent("新增成功"),
                    ReasonPhrase = "Update"
                };
                return resp;
            }
            catch (Exception ex)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent("新增失敗"),
                    ReasonPhrase = "Server Error"
                };

                return resp;
            }
        }


    }
}
