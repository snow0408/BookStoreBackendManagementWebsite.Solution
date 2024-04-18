using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
    public static class CategoryExts
    {

        public static CategoryIndexVm ToCategoryIndexVm(this CategoryDto dto)
        {
            return new CategoryIndexVm
            {
                Id = (int)dto.Id,
                Name = dto.Name,
                DisplayOrder = dto.DisplayOrder,
            }; 
        }
        public static CategoryVm ToCategoryVm(this CategoryDto dto)
        {
            return new CategoryVm
            {
                Id = (int)dto.Id,
                Name = dto.Name,
                DisplayOrder = dto.DisplayOrder,
            };
        }
        public static CategoryDto ToCategoryDto(this CategoryVm vm)
        {
            return new CategoryDto
            {
                Id = vm.Id,
                Name = vm.Name,
                DisplayOrder = vm.DisplayOrder,
            };
        }
        public static CategoryDto ToCategoryDto(this Category entity)
        {
            var dto = new CategoryDto();
            if (entity != null)
            {
                dto.Id = entity.Id;
                dto.Name = entity.Name;
                dto.DisplayOrder = entity.DisplayOrder;
            }
            return dto;
        }

    }
}