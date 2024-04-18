using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Models.Services
{
    public class ProductService
    {
        private IProductRepository _repos;
        public ProductService(IProductRepository repos)
        {
            _repos = repos;
        }
        public void Create(ProductCreateVm vm)
        {

            bool canCreateBookProduct = false;
            if (vm.Category == "實體書" || vm.Category == "電子書")
            {
                if (vm.BookProduct.ISBN.Length != 13)
                {
                    throw new Exception("ISBN長度必須為13");
                }
                canCreateBookProduct = true;
            }
            var dto = vm.ToDto();
            var productId = _repos.Create(dto);

            if (canCreateBookProduct)
            {
                vm.BookProduct.ProductId = productId;
                new BookProductService(new BookProductEFRepository()).Create(vm.BookProduct.ToDto());
            }
        }
        public void Delete(int id)
        {
            _repos.Delete(id);
        }
        public List<ProductIndexVm> Search(ProductsFilterDto searchDto)
        {
            return _repos.Search(searchDto)
                         .Select(x => x.ToProductIndexVm())
                         .ToList();
        }

        public void Update(ProductEditVm vm)
        {
            var dto = vm.ToDto();

            _repos.Update(dto);
        }


        public ProductEditVm Get(int id)
        {
            var product = _repos.Get(id);
            var bookProduct = new BookProductService(new BookProductEFRepository()).GetByProductId(product.Id);

            var vm = new ProductEditVm()
            {
                Id = id,
                Name = product.Name,
                Price = product.Price,
                ProductStatus = product.ProductStatus,
                Description = product.Description,
                Category = product.Category,
                Stock = product.Stock,
            };

            if (bookProduct != null)
            {
                vm.BookProduct = bookProduct;
            }

            return vm;
        }

        public List<SelectListItem> GetProductStatusList()
        {
            List<SelectListItem> mySelectItemList = new List<SelectListItem>();

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "有存貨",
                Value = "有存貨",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "缺貨",
                Value = "缺貨",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "預購",
                Value = "預購",
                Selected = false
            });
            return mySelectItemList;
        }

        public List<SelectListItem> GetProductCategoryList()
        {
            List<SelectListItem> mySelectItemList = new List<SelectListItem>();
            mySelectItemList.Add(new SelectListItem()
            {
                Text = "實體書",
                Value = "實體書",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "電子書",
                Value = "電子書",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "其他",
                Value = "其他",
                Selected = false
            });
            return mySelectItemList;
        }
        //---------funciton---------

    }
}