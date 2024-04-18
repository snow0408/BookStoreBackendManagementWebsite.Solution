using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class ProductKeywordEFRepository : IProductKeywordRepository
    {
        public int Create(KeywordTagDto dto)
        {
            var db = new AppDbContext();

            var model = new ProductKeyword()
            {
                ProductId = dto.ProductId,
                KeywordId = dto.KeywordId,
            };
            db.ProductKeywords.Add(model);
            db.SaveChanges();

            return model.Id;
        }

        public void Delete(int keywordId, int productId)
        {
            var db = new AppDbContext();
            var model = db.ProductKeywords.Where(x => x.KeywordId == keywordId && x.ProductId == productId).FirstOrDefault();
            db.ProductKeywords.Remove(model);
            db.SaveChanges();
        }


        public List<KeywordTagDto> GetAllByProductId(int productId)
        {
            var db = new AppDbContext();
            var model = db.ProductKeywords.Include(x => x.Keyword)
                                          .Where(x => x.ProductId == productId)
                                          .Select(x => new KeywordTagDto()
                                          {
                                              Id = x.Id,
                                              ProductId = x.ProductId,
                                              KeywordId = x.KeywordId,
                                              value = x.Keyword.Name
                                          }).ToList();
            return model;
        }

    }
}