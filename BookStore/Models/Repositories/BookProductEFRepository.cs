using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class BookProductEFRepository : IBookProductRepository
    {
        public void Create(BookProductDto dto)
        {
            var db = new AppDbContext();

            var model = new BookProduct()
            {
                BookId = dto.BookId,
                ProductId = dto.ProductId,
                PublisherId = dto.PublisherId,
                PublishDate = (DateTime)dto.PublishDate,
                ISBN = dto.ISBN,
            };

            db.BookProducts.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new AppDbContext();
            var model = db.BookProducts.Find(id);
            db.BookProducts.Remove(model);
            db.SaveChanges();
        }

        public List<BookProductDto> Search(string name)
        {
            var db = new AppDbContext();

            var model = db.BookProducts
                            .AsNoTracking()
                            .Include(x => x.Book)
                            .Select(x => new BookProductDto()
                            {
                                Id = x.Id,
                                BookId = x.BookId,
                                BookName = x.Book.Name,
                                ProductId = x.ProductId,
                                PublisherId = x.PublisherId,
                                PublishDate = x.PublishDate,
                                ISBN = x.ISBN
                            });

            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(p => p.BookName.Contains(name));
            }

            return model.ToList();
        }

        public void Update(BookProductDto dto)
        {
            var db = new AppDbContext();

            var model = db.BookProducts.Find(dto.Id);
            model.BookId = dto.BookId;
            model.ProductId = dto.ProductId;
            model.PublisherId = dto.PublisherId;
            model.PublishDate = (DateTime)dto.PublishDate;
            model.ISBN = dto.ISBN;

            db.SaveChanges();
        }


        //查詢名稱     
        public BookProductDto Get(int id)
        {
            var db = new AppDbContext();
            var BookProduct = db.BookProducts.Find(id);

            return BookProduct.ToBookProductDto();
        }

        public BookProductDto GetByProductId(int ProductId)
        {
            var db = new AppDbContext();
            var BookProduct = db.BookProducts.Where(x => x.ProductId == ProductId)
                                             .AsNoTracking()
                                             .Select(x => new BookProductDto()
                                             {
                                                 Id = x.Id,
                                                 BookId = x.BookId,
                                                 ProductId = x.ProductId,
                                                 PublisherId = x.PublisherId,
                                                 PublishDate = x.PublishDate,
                                                 ISBN = x.ISBN,
                                                 BookName = x.Book.Name,
                                                 PublisherName = x.Bookseller.Name,
                                             })
                                             .FirstOrDefault();
            return BookProduct;
        }
    }
}