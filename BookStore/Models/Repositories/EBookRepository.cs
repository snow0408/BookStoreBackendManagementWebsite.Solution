using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookStore.Models.Repositories
{
    public class EBookRepository : IEBookRepo
    {
        private AppDbContext db = new AppDbContext();

        //絕對正確
        public void Create(EBookDto dto)
        {

            var model = new EBook()
            {
                Id = dto.Id,
                BookId = dto.BookId,
                FileLink = dto.FileLink,
                Sample = dto.Sample
            };
            db.EBooks.Add(model);
            db.SaveChanges();
        
        }
        //絕對正確
        public void Delete(int id)
        {
            var model = db.EBooks.Find(id);
            db.EBooks.Remove(model);
            db.SaveChanges();
        }

        //自己寫
        public EBookDto Get(int id)
        {
            var ebook = db.EBooks.Find(id);
            var dto = new EBookDto
            {
                Id = ebook.Id,
                BookId = ebook.BookId,
                FileLink = ebook.FileLink,
                Sample = ebook.Sample,
                BookName=ebook.Book.Name
            };
            return dto;
        }

        public List<EBookDto> Search(string bookName)
        {
            var model = db.EBooks.Include(x => x.Book)
                                  .Select(x => new EBookDto
                                  {
                                      Id = x.Id,
                                      BookId = x.BookId,
                                      FileLink = x.FileLink,
                                      Sample = x.Sample,
                                      BookName = x.Book.Name
                                  })
                                  .ToList();
            if (!string.IsNullOrEmpty(bookName))
            {
                model = model.Where(x => x.BookName.Contains(bookName)).ToList();
            }
            return model;
        }
		public List<EBookDto> SearchEBook(string keyword)
		{
			var db = new AppDbContext();

			var models = db.EBooks
						   .AsNoTracking()
						   .Include(b => b.Book);
			if (!string.IsNullOrEmpty(keyword))
			{
				models = models.Where(x => x.Book.Name.Contains(keyword));
			}
			var model = models.Select(e => new EBookDto()
			{
				Id = e.Id,
				BookName = e.Book.Name
			}).ToList();

			return model;
		}
		//絕對正確
		public void Update(EBookDto dto)
        {
            var db = new AppDbContext();

          var model = db.EBooks.Find(dto.Id);
            model.BookId = dto.BookId;
            model.FileLink = dto.FileLink;
            model.Sample = dto.Sample;
            db.SaveChanges();

        }
    }
}