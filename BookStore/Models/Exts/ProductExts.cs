using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;

namespace BookStore.Models.Exts
{
    public static class ProductExts
    {
        public static ProductDto ToProductDto(this Product entity)
        {
            return new ProductDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                ProductStatus = entity.ProductStatus,
                Description = entity.Description,
                Category = entity.Category,
                Stock = entity.Stock
            };
        }
        public static ProductIndexVm ToProductIndexVm(this ProductDto dto)
        {
            return new ProductIndexVm
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                ProductStatus = dto.ProductStatus,
                Description = dto.Description,
                Category = dto.Category,
                Stock = dto.Stock
            };
        }

        public static ProductDto ToDto(this ProductCreateVm dto)
        {
            return new ProductDto
            {
                Name = dto.Name,
                Price = dto.Price,
                ProductStatus = dto.ProductStatus,
                Description = dto.Description,
                Category = dto.Category
            };
        }
        public static ProductDto ToDto(this ProductEditVm dto)
        {
            return new ProductDto
            {
                Id = dto.Id,
                Name = dto.Name,
                Price = dto.Price,
                ProductStatus = dto.ProductStatus,
                Description = dto.Description,
                Category = dto.Category,
                Stock = dto.Stock,
            };
        }


    }
}