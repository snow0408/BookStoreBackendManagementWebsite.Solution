using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class ArticleEFRepository : IArticleRepository
    {
        public void Create(ArticleDto dto)
        {
            var db = new AppDbContext();

            var model = new Article()
            {
                Title = dto.Title,
                //PublishTime = dto.PublishTime,
                Content = dto.Content,
                Category = dto.Category
            };

            db.Articles.Add(model);
            db.SaveChanges();

        }

        public void Delete(int id)
        {
            var db = new AppDbContext();
            var model = db.Articles.Find(id);
            db.Articles.Remove(model);
            db.SaveChanges();
        }

        public ArticleDto Get(int id)
        {
            var db = new AppDbContext();
            var article = db.Articles.Find(id);
            return article?.ToArticleDto();
        }

        public IEnumerable<ArticleDto> GetAll()
        {
            var db = new AppDbContext();
            var models = db.Articles
                .AsNoTracking()
                .Select(x => new ArticleDto()
                {
                    ArticleID = x.ArticleID,
                    EmployeeID = (int)x.EmployeeID,
                    Title = x.Title,
                    PublishTime = (DateTime)x.PublishTime,
                    Content = x.Content,
                    Category = x.Category
                });
            return models.ToList();
        }

        public List<ArticleDto> Search(string keyword)
        {
            var db = new AppDbContext();
            var model = db.Articles
                .AsNoTracking()
                .Where(x => x.Title.Contains(keyword) || x.Content.Contains(keyword))
                .Select(x => new ArticleDto()
                {
                    ArticleID = x.ArticleID,
                    EmployeeID = (int)x.EmployeeID,
                    Title = x.Title,
                    PublishTime = (DateTime)x.PublishTime,
                    Content = x.Content,
                    Category = x.Category
                });
            if (!string.IsNullOrEmpty(keyword))
            {
                model = model.Where(x => x.Title.Contains(keyword) || x.Content.Contains(keyword));
            }
            return model.ToList();
        }

        public ArticleDto SearchKeyword(string keyword)
        {
            var db = new AppDbContext();
            var model = db.Articles
                .FirstOrDefault(x => x.Title.Contains(keyword) || x.Content.Contains(keyword));
            return model?.ToArticleDto();
        }

        public void Update(ArticleDto dto)
        {
            var db = new AppDbContext();
            var model = db.Articles.Find(dto.ArticleID);
            model.Title = dto.Title;
            model.PublishTime = dto.PublishTime;
            model.Content = dto.Content;
            model.Category = dto.Category;
            db.SaveChanges();
        }
    }
}