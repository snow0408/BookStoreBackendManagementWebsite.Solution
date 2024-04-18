using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Models.Services
{
    public class BooksService
    {
        private IBooksRepository _repos;

        public BooksService(IBooksRepository repos)
        {
            _repos = repos;
        }

        public void Create(BooksDto dto)
        {
            _repos.Create(dto);
        }
        public List<BooksIndexVm> Search(string name, string author)
        {
            var dtos = _repos.Search(name, author);
            var vms = dtos.Select(x => new BooksIndexVm()
            {
                Id = x.Id,
                CategoryName = x.CategoryName,
                Author = x.Author,
                Language = x.Language,
                Name = x.Name
            }).ToList();

            return vms;
        }

        public void Update(BooksDto dto)
        {
            _repos.Update(dto);
        }

        public void Delete(int id)
        {
            _repos.Delete(id);
        }

        public BooksEditVm Get(int id)
        {
            return _repos.Get(id).ToEditVm();
        }

        public Dictionary<string, int> GetBookSelectList()
        {
            var bookList = new Dictionary<string, int>();
            var books = _repos.Search("", "");
            foreach (var book in books) bookList.Add(book.Name, book.Id);

            return bookList;
        }

        public List<SelectListItem> GetBookLanguageSelectList()
        {
            var list = new List<SelectListItem>();

            list.Add(new SelectListItem()
            {
                Text = "中文",
                Value = "中文",
                Selected = true
            });
            list.Add(new SelectListItem()
            {
                Text = "英文",
                Value = "英文",
                Selected = false
            });

            return list;
        }
    }
}