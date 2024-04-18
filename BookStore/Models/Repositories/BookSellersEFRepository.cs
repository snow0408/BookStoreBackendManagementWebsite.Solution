using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.ViewModels;
using System.Xml.Linq;

namespace BookStore.Models.Repositories
{
    public class BookSellersEFRepository : IBookSellersRepository
    {
        //private readonly AppDbContext _dbContext;

        //public BookSellersEFRepository(AppDbContext dbContext)
        //{
        //    _dbContext = dbContext;
        //}

        public void Create(BookSellersDto dto)
        {
            using (var db = new AppDbContext())
            {
                var model = new Bookseller()
                {
                    Name = dto.Name,
                    ContactPerson = dto.ContactPerson,
                    Phone = dto.Phone,
                    Address = dto.Address,
                    Compiled = dto.Compiled,
                    BankAccount = dto.BankAccount
                };

                db.Booksellers.Add(model);
                db.SaveChanges();
            }
        }

        public void Delete(int ID)
        {
            var db = new AppDbContext();
            var model = db.Booksellers.Find(ID);
            db.Booksellers.Remove(model);
            db.SaveChanges();
        }

        

        public IEnumerable<BookSellersDto> GetAllBookSellers()
        {
            var db = new AppDbContext();

            var models = db.Booksellers
                .AsNoTracking()
                .Select(x => new BookSellersDto()
                {
                    ID = x.ID,
                    Name = x.Name,
                    ContactPerson = x.ContactPerson,
                    Phone = x.Phone,
                    Address = x.Address,
                    Compiled = x.Compiled,
                    BankAccount = x.BankAccount
                });

            return models.ToList();
        }


        public BookSellersDto Get(int ID)
        {
            var db = new AppDbContext();
            var bookseller = db.Booksellers.Find(ID);

            return bookseller?.ToBookSellersDto(); // 使用安全的 null 條件運算符
        }
        
        public List<BookSellersDto> Search(string name)
        {
            var db = new AppDbContext();

            var model = db.Booksellers
                            .AsNoTracking()
                            .Select(x => new BookSellersDto()
                            {
                                ID = x.ID,
                                Name = x.Name,
                                ContactPerson = x.ContactPerson

                            });

            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(p => p.Name.Contains(name));
            }

            return model.ToList();
        }

        public BookSellersDto SearchFirstName(string name)
        {
            var db = new AppDbContext();
            var bookSeller = db.Booksellers.FirstOrDefault(p => p.Name == name);

            return bookSeller.ToBookSellersDto();
        }

        public void Update(BookSellersDto dto)
        {
            var db = new AppDbContext();

            var model = db.Booksellers.Find(dto.ID);
            model.Name = dto.Name;
            model.ContactPerson = dto.ContactPerson;
            model.Phone = dto.Phone;
            model.Address = dto.Address;
            model.Compiled = dto.Compiled;
            model.BankAccount = dto.BankAccount;


            db.SaveChanges();
        }
    }
}