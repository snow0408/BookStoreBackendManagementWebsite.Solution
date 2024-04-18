using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    public interface IEBooksPermissionRepostory
    {
        void Create(EBooksPermissionDto entity);

        List<EBooksPermissionDto> Search(string bookName, string member);

        List<EBooksPermissionDto> SearchEBook(string keyword);

        void Delete(int id);
    }
}