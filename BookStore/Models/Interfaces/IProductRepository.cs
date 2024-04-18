using BookStore.Models.Dtos;
using System.Collections.Generic;

namespace BookStore.Models.Interfaces
{
    public interface IProductRepository
    {
        int Create(ProductDto dto);

        void Delete(int id);

        List<ProductDto> Search(ProductsFilterDto searchDto);

        void Update(ProductDto dto);

        ProductDto Get(int id);
    }
}
