using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BookStore.Models.Repositories
{
    public class CategoryEFRepository : ICategoryRepository
    {
        public void Create(CategoryDto dto)
        {
            var db = new AppDbContext();

            var model = new Category()
            {                
                Name = dto.Name,
                DisplayOrder = dto.DisplayOrder,
            };

            db.Categories.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new AppDbContext();
            var model = db.Categories.Find(id);
            db.Categories.Remove(model);
            db.SaveChanges();
        }

        public List<CategoryDto> Search(string name)
        {
            var db = new AppDbContext();

            var model = db.Categories
                            .AsNoTracking()
                            .Select(x => new CategoryDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                DisplayOrder = x.DisplayOrder,
                            });

            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(p => p.Name.Contains(name));
            }

            return model.ToList();
        }

        public void Update(CategoryDto dto)
        {
            var db = new AppDbContext();
            
            var model = db.Categories.Find(dto.Id);
            model.Name = dto.Name;
            model.DisplayOrder = dto.DisplayOrder;

            db.SaveChanges();
        }
       

        //查詢名稱
        public CategoryDto SearchFirstName(string name)
        {
            var db = new AppDbContext();
            var category = db.Categories.FirstOrDefault(p => p.Name == name);
            
            return category.ToCategoryDto();
        }

        public CategoryDto Get(int id)
        {
            var db = new AppDbContext();
            var category = db.Categories.Find(id);

            return category.ToCategoryDto();
        }

        

    }
}