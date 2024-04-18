using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class BooksEFRepository : IBooksRepository
    {
        public void Create(BooksDto dto)
        {
            var db = new AppDbContext();

            var model = new Book
            {
                Name = dto.Name,
                CategoryID = dto.CategoryId,
                Author = dto.Author,
                Language = dto.Language,
            };

            db.Books.Add(model);
            db.SaveChanges();
        }

        public List<BooksDto> Search(string name, string author)
        {
            var db = new AppDbContext();

            var model = db.Books
                          .AsNoTracking()
                          .Include(b => b.Category)
                          .Select(b => new BooksDto()
                          {
                              Id = b.Id,
                              CategoryId = b.CategoryID,
                              CategoryName = b.Category.Name,
                              Author = b.Author,
                              Language = b.Language,
                              Name = b.Name
                          })
                          .ToList();

            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(b => b.Name.Contains(name)).ToList();
            }
            if (!string.IsNullOrEmpty(author))
            {
                model = model.Where(b => b.Author.Contains(author)).ToList();
            }
            return model;
        }

        public void Update(BooksDto dto)
        {
            var db = new AppDbContext();

            var model = db.Books.Find(dto.Id);

            model.Name = dto.Name;
            model.CategoryID = dto.CategoryId;
            model.Author = dto.Author;
            model.Language = dto.Language;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var db = new AppDbContext();

            var model = db.Books.Find(id);

            db.Books.Remove(model);
            db.SaveChanges();
        }

        public BooksDto Get(int id)
        {
            var db = new AppDbContext();
            var model = db.Books.Where(b => b.Id == id)
                                .Select(b => new BooksDto()
                                {
                                    Id = b.Id,
                                    CategoryId = b.CategoryID,
                                    CategoryName = b.Category.Name,
                                    Author = b.Author,
                                    Language = b.Language,
                                    Name = b.Name
                                }).FirstOrDefault();
            return model;
        }
    }
}