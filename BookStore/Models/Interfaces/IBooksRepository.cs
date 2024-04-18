using BookStore.Models.Dtos;
using System.Collections.Generic;

namespace BookStore.Models.Interfaces
{
    public interface IBooksRepository
    {
        void Create(BooksDto entity);

        List<BooksDto> Search(string name, string author);

        void Update(BooksDto dto);

        void Delete(int id);

        BooksDto Get(int id);
    }
}
