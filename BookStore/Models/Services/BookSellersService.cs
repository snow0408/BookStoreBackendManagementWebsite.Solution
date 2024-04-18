using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Services
{
    public class BookSellersService
    {
        private IBookSellersRepository _repos;

        public BookSellersService(IBookSellersRepository repos) => _repos = repos;

        public void CreateBookSeller(BookSellersDto dto)
        {
            ValidateBookSeller(dto.Name, dto.ContactPerson, dto.ID);
            _repos.Create(dto);
        }
        public List<BookSellersIndexVm> Search(string name)
        {
            return _repos.Search(name)
                         .Select(x => x.ToBookSellersIndexVm())
                         .OrderBy(x => x.ID)
                         .ToList();
        }

        private void ValidateBookSeller(string name, string contactPerson, int? ID)
        {
            // 確認名稱不為空
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("書商名稱不能為空");
            }

            // 確認聯絡人不為空
            if (string.IsNullOrWhiteSpace(contactPerson))
            {
                throw new ArgumentException("聯絡人不能為空");
            }

            // 確認名稱是否唯一
            if (IsNameUnique(name, ID))
            {
                throw new InvalidOperationException("書商名稱已經存在");
            }
        }

        private bool IsNameUnique(string name, int? ID)
        {
            var existingBookSellers = _repos.GetAllBookSellers().ToList();
            return existingBookSellers.Exists(seller => seller.Name.Equals(name, StringComparison.OrdinalIgnoreCase) && (ID == null || seller.ID != ID));
        }

        public void Delete(int ID)
        {
            _repos.Delete(ID);
        }


        public void Update(BookSellersDto dto)
        {

            IsNameExist(dto.Name, dto.ID);
            _repos.Update(dto);
        }

        private void IsNameExist(string name, int? ID = null)
        {
            var bookSeller = _repos.SearchFirstName(name);

            if (bookSeller.ID != null && ID != bookSeller.ID)
            {
                throw new InvalidOperationException("書商名稱已重複");
            }
        }

        public BookSellersVm Get(int ID)
        {
            return _repos.Get(ID).ToBookSellerVm();
        }

        public Dictionary<string, int> GetBookSellerSelectList()
        {
            var bookSellerList = new Dictionary<string, int>();
            var bookSellers = _repos.GetAllBookSellers();
            foreach (var bobookSeller in bookSellers) bookSellerList.Add(bobookSeller.Name, bobookSeller.ID);

            return bookSellerList;
        }
    }
}
