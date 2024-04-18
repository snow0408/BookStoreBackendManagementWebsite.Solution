using BookStore.Models.Dtos;
using System.Collections.Generic;

namespace BookStore.Models.Interfaces
{
    public interface IProductKeywordRepository
    {
        int Create(KeywordTagDto dto);

        void Delete(int keywordId, int productId);

        List<KeywordTagDto> GetAllByProductId(int productId);
    }
}
