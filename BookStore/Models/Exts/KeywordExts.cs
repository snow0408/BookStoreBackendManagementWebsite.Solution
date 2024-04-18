using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
    public static class KeywordExts
    {
        public static KeywordIndexVm ToKeywordIndexVm(this KeywordDto dto)
        {
            return new KeywordIndexVm
            {
                Id = (int)dto.Id,
                Name = dto.Name,
               
            };
        }
        public static KeywordVm ToKeywordVm(this KeywordDto dto)
        {
            return new KeywordVm
            {
                Id = (int)dto.Id,
                Name = dto.Name,
               
            };
        }
        public static KeywordDto ToKeywordDto(this KeywordVm vm)
        {
            return new KeywordDto
            {
                Id = vm.Id,
                Name = vm.Name,                
            };
        }
        public static KeywordDto ToKeywordDto(this Keyword entity)
        {
            var dto = new KeywordDto();
            if (entity != null)
            {
                dto.Id = entity.Id;
                dto.Name = entity.Name;                
            }
            return dto;
        }

    }
}