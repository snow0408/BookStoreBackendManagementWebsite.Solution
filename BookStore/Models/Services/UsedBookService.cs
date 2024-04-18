using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Services
{
    public class UsedBookService
    {
        private IUsedBookRepository _repos;
        public UsedBookService(IUsedBookRepository repos)
        {
            _repos = repos;
        }
        public List<UsedBookIndexVm> Search(string email, string ISBN, string bookName)
        {
            return _repos.Search(email, ISBN, bookName)
                        .Select(x => x.ToUsedBookIndexVm())
                        .ToList();
        }

        public UsedBookIndexVm Get(int id)
        {
            return _repos.Get(id).ToUsedBookIndexVm();
        }

        public void UpdateProductStatus(int id, bool status)
        {
            _repos.UpdateProductStatus(id, status);
        }

        public void Edit(UsedBookIndexVm vm)
        {
            _repos.Edit(vm.ToUsedBookIndexVm());
        }
    }
}