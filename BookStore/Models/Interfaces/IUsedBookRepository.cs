using BookStore.Models.Dtos;
using System.Collections.Generic;

namespace BookStore.Models.Interfaces
{
    public interface IUsedBookRepository
    {
        List<UsedBookDto> Search(string email, string ISBN, string bookName);

        void Edit(UsedBookDto dto);

        void UpdateProductStatus(int id, bool status);
        UsedBookDto Get(int id);

    }
}
