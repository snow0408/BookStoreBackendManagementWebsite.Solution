using BookStore.Models.Dtos;
using System.Collections.Generic;

namespace BookStore.Models.Interfaces
{
    public interface IBookProductRepository
    {
        void Create(BookProductDto dto);
        void Delete(int id);
        List<BookProductDto> Search(string name);
        void Update(BookProductDto dto);
        BookProductDto Get(int id);

        BookProductDto GetByProductId(int ProductId);
    }
}
