using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;

namespace BookStore.Models.Exts
{
    public static class BooksExts
    {

        public static BooksDto ToDto(this BooksEditVm vm)
        {
            return new BooksDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                CategoryId = vm.CategoryID,
                Author = vm.Author,
                Language = vm.Language,
            };
        }
        public static BooksDto ToDto(this BooksCreateVm vm)
        {
            return new BooksDto()
            {
                Id = vm.Id,
                Name = vm.Name,
                CategoryId = vm.CategoryID,
                Author = vm.Author,
                Language = vm.Language,
            };
        }
        public static BooksDto ToDto(this Book entity)
        {
            return new BooksDto()
            {
                Id = entity.Id,
                Name = entity.Name,
                CategoryId = entity.CategoryID,
                Author = entity.Author,
                Language = entity.Language,
            };
        }
        public static BooksEditVm ToEditVm(this BooksDto dto)
        {
            return new BooksEditVm()
            {
                Id = dto.Id,
                Name = dto.Name,
                CategoryID = dto.CategoryId,
                Author = dto.Author,
                Language = dto.Language,
                CategoryName = dto.CategoryName,
            };
        }
    }
}