using BookStore.Models.Dtos;
using BookStore.Models.Interfaces;
using System.Collections.Generic;

namespace BookStore.Models.Services
{
    public class ProductKeywordService
    {
        private readonly IProductKeywordRepository _repos;
        public ProductKeywordService(IProductKeywordRepository repos)
        {
            _repos = repos;
        }

        public int Create(KeywordTagDto dto)
        {
            return _repos.Create(dto);
        }
        public void Delete(int keywordId, int productId)
        {
            _repos.Delete(keywordId, productId);
        }
        public List<KeywordTagDto> GetAllByProductId(int productId)
        {
            return _repos.GetAllByProductId(productId);
        }

    }
}