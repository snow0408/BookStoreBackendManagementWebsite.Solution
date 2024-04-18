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
    public class EBooksPermissionEFRepository : IEBooksPermissionRepostory
    {
        public void Delete(int id)
        {
            var db = new AppDbContext();
            var model = db.EBooksPermissions.Find(id);
            db.EBooksPermissions.Remove(model);
            db.SaveChanges();
        }


        public void Create(EBooksPermissionDto dto)
        {
            var db = new AppDbContext();

            var model = new EBooksPermission
            {
                BookID = dto.BookID,
                MemberID = dto.MemberID,
                PermissionType = dto.PermissionType,
                CreateDate = DateTime.Now
            };

            db.EBooksPermissions.Add(model);
            db.SaveChanges();
        }

        public List<EBooksPermissionDto> Search(string bookName, string member)
        {
            var db = new AppDbContext();

            var models = db.EBooksPermissions
                          .AsNoTracking()
                          .Include(b => b.EBook.Book)
                          .Include(m => m.Member);
            if (!string.IsNullOrEmpty(bookName))
            {
                models = models.Where(x => x.EBook.Book.Name.Contains(bookName));
            }
            if (!string.IsNullOrEmpty(member))
            {
                models = models.Where(x => x.Member.Name.Contains(member));
            }

            var model = models.Select(e => new EBooksPermissionDto()
            {
                Id = e.Id,
                BookID = e.BookID,
                BookName = e.EBook.Book.Name,
                MemberID = e.MemberID,
                MemberName = e.Member.Name,
                CreateDate = e.CreateDate,
                PermissionType = e.PermissionType
            })
                          .ToList();
            return model;
        }

        public List<EBooksPermissionDto> SearchEBook(string keyword)
        {
            var db = new AppDbContext();

            var models = db.EBooks
                           .AsNoTracking()
                           .Include(b => b.Book);
            if (!string.IsNullOrEmpty(keyword))
            {
                models = models.Where(x => x.Book.Name.Contains(keyword));
            }
            var model = models.Select(e => new EBooksPermissionDto()
            {
                Id = e.Id,
                BookName = e.Book.Name
            }).ToList();

            return model;
        }

    }
}