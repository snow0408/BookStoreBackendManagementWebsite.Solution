using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class ProductEFRepository : IProductRepository
    {
        public int Create(ProductDto dto)
        {
            var db = new AppDbContext();

            var model = new Product()
            {
                Name = dto.Name,
                Price = dto.Price,
                ProductStatus = dto.ProductStatus,
                Description = dto.Description,
                Category = dto.Category,
                Stock = 0
            };

            db.Products.Add(model);
            db.SaveChanges();

            return model.Id;
        }

        public void Delete(int id)
        {
            var db = new AppDbContext();
            var model = db.Products.Find(id);
            db.Products.Remove(model);
            db.SaveChanges();
        }

        public List<ProductDto> Search(ProductsFilterDto searchDto)
        {
            var db = new AppDbContext();

            var model = db.Products
                            .AsNoTracking()
                            .Select(x => new ProductDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                                Price = x.Price,
                                ProductStatus = x.ProductStatus,
                                Description = x.Description,
                                Category = x.Category,
                                Stock = x.Stock,
                            });

            model = FilterList(model, searchDto).OrderBy(x => x.ProductStatus).ThenBy(x => x.Category);

            return model.ToList();
        }

        public void Update(ProductDto dto)
        {
            var db = new AppDbContext();

            var model = db.Products.Find(dto.Id);
            model.Name = dto.Name;
            model.Price = dto.Price;
            model.ProductStatus = dto.ProductStatus;
            model.Description = dto.Description;
            model.Category = dto.Category;

            db.SaveChanges();
        }

        //查詢名稱     
        public ProductDto Get(int id)
        {
            var db = new AppDbContext();
            var Product = db.Products.Find(id);

            return Product.ToProductDto();
        }

        // ----- function ----
        public IQueryable<ProductDto> FilterList(IQueryable<ProductDto> model, ProductsFilterDto searchDto)
        {
            if (!string.IsNullOrEmpty(searchDto.Name))
            {
                model = model.Where(p => p.Name.Contains(searchDto.Name));
            }
            if (!string.IsNullOrEmpty(searchDto.Category))
            {
                model = model.Where(p => p.Category.Contains(searchDto.Category));
            }
            if (!string.IsNullOrEmpty(searchDto.Status))
            {
                model = model.Where(p => p.ProductStatus.Contains(searchDto.Status));
            }
            if (searchDto.MinPrice != null && searchDto.MinPrice > 0)
            {
                model = model.Where(p => p.Price >= searchDto.MinPrice);
            }
            if (searchDto.MaxPrice != null)
            {
                model = model.Where(p => p.Price <= searchDto.MaxPrice);
            }
            if (searchDto.Stock != null)
            {
                model = model.Where(p => p.Stock <= searchDto.Stock);
            }
            return model;
        }
    }
}