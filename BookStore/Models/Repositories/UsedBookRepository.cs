using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class UsedBookRepository : IUsedBookRepository
    {
        public List<UsedBookDto> Search(string email, string ISBN, string bookName)
        {
            var db = new AppDbContext();

            var model = db.UsedBooks
                            .AsNoTracking()
                            .Include(x => x.Member)
                            .Select(x => new UsedBookDto()
                            {
                                Id = x.Id,
                                MemberId = x.MemberId,
                                MemberEmail = x.Member.Email,
                                BookName = x.Name,
                                CategoryId = x.CategoryId,
                                CategoryName = x.Category.Name,
                                ProductStatus = x.ProductStatus,
                                Price = x.Price,
                                Description = x.Description,
                                ISBN = x.ISBN,
                                Pictrue = x.Pictrue,
                                BookStatus = x.BookStatus
                            });

            model = ConditionalFiltering(model, email, ISBN, bookName)
                        .OrderByDescending(x => x.Price)
                        .ThenBy(x => x.CategoryId);

            return model.ToList();
        }
        public UsedBookDto Get(int id)
        {
            var db = new AppDbContext();
            var model = db.UsedBooks.AsNoTracking()
                                    .Include(x => x.Member)
                                    .FirstOrDefault(x => x.Id == id);

            var dto = new UsedBookDto();
            if (model != null)
            {
                dto.Id = model.Id;
                dto.MemberId = model.MemberId;
                dto.MemberEmail = model.Member.Email;
                dto.CategoryId = model.CategoryId;
                dto.CategoryName = model.Category.Name;
                dto.ProductStatus = model.ProductStatus;
                dto.Price = model.Price;
                dto.Description = model.Description;
                dto.ISBN = model.ISBN;
                dto.BookStatus = model.BookStatus;
            }
            return dto;
        }

        //更新上架狀態
        public void UpdateProductStatus(int id, bool status)
        {
            var db = new AppDbContext();
            var model = db.UsedBooks.Find(id);
            model.ProductStatus = status;
            db.SaveChanges();
        }

        public void Edit(UsedBookDto dto)
        {
            var db = new AppDbContext();

            var model = db.UsedBooks.Find(dto.Id);

            model.ProductStatus = dto.ProductStatus;

            db.SaveChanges();

        }

        //--------function
        //條件篩選
        public IQueryable<UsedBookDto> ConditionalFiltering(IQueryable<UsedBookDto> model, string email, string ISBN, string bookName)
        {
            if (!string.IsNullOrEmpty(email))
            {
                model = model.Where(p => p.MemberEmail.Contains(email));
            }

            if (!string.IsNullOrEmpty(ISBN))
            {
                model = model.Where(p => p.ISBN.Contains(ISBN));
            }
            if (!string.IsNullOrEmpty(bookName))
            {
                model = model.Where(p => p.BookName.Contains(bookName));
            }
            return model;
        }
    }
}