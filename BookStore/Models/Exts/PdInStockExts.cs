using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
    public static class PdInStockExts
    {

        public static PdInStockVm ToPdInStockVm(this PdInStockDto dto)
        {
            return new PdInStockVm
            {
                ID = dto.ID,
                ProductId = dto.ProductId,
                ProductName = dto.ProductName,
                CategoryName = dto.CategoryName,
                Qty = dto.Qty,
                BuyPrice = dto.BuyPrice,
                BuyDate = dto.BuyDate,

            };
        }

        public static PdInStockDto ToPdInStockDto(this PdInStockVm vm)
        {
            return new PdInStockDto
            {
                ID = vm.ID,
                ProductId = vm.ProductId,
                Qty = vm.Qty,
                BuyPrice = vm.BuyPrice,
                BuyDate = vm.BuyDate,

            };
        }

        public static PdInStockIndexVm ToPdInStockIndexVm(this PdInStockDto dto)
        {
            return new PdInStockIndexVm
            {
                ID = dto.ID,
                ProductId = dto.ProductId,
                Qty = dto.Qty,
                BuyPrice = dto.BuyPrice,
                BuyDate = dto.BuyDate,

            };
        }

        public static PdInStockDto ToPdInStockDto(this PdInStock entity)
        {
            var dto = new PdInStockDto();
            if (entity != null)
            {
                dto.ID = entity.ID;
                dto.ProductId = entity.ProductId;
                dto.Qty = entity.Qty;
                dto.BuyPrice = entity.BuyPrice;
                dto.BuyDate = entity.BuyDate;
                dto.BuyDate = entity.BuyDate;

            }
            return dto;
        }

        public static ProductDetailsVm ToProductDetailsVm(this ProductDto productDto)
        {
            if (productDto == null)
            {
                return null;
            }

            
            var viewModel = new ProductDetailsVm
            {
                Id = productDto.Id,
                Name = productDto.Name,
                
                
            };

            return viewModel;
        }
    }
}