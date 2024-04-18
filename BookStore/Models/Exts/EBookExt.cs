using BookStore.Models.Dtos;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
    public static class EBookExt
    {
        public static EBookVm ebookVm(this EBookDto dto)
        {
            return new EBookVm()
            {
                Id = dto.Id,
                BookId = dto.BookId,
                FileLink = dto.FileLink,
                Sample = dto.Sample,
                BookName = dto.BookName
            };
        }
        public static EBookDto ToDto(this EBookVm vm)
        {
            return new EBookDto()
            {
                Id = vm.Id,
                BookId = vm.BookId,
                FileLink = vm.FileLink,
                Sample = vm.Sample,
                BookName = vm.BookName

            };
        }
    }
}