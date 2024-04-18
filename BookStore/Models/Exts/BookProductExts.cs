using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;

namespace BookStore.Models.Exts
{
    public static class BookProductExts
    {
        public static BookProductDto ToBookProductDto(this BookProduct entity)
        {
            return new BookProductDto
            {
                Id = entity.Id,
                BookId = entity.BookId,
                ProductId = entity.ProductId,
                PublisherId = entity.PublisherId,
                PublishDate = entity.PublishDate,
                ISBN = entity.ISBN
            };
        }
        public static BookProductDto ToDto(this BookProductCreateVm vm)
        {
            return new BookProductDto()
            {
                BookId = (int)vm.BookId,
                ProductId = (int)vm.ProductId,
                PublisherId = (int)vm.PublisherId,
                PublishDate = (DateTime)vm.PublishDate,
                ISBN = vm.ISBN
            };
        }
    }
}