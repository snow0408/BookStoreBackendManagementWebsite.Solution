using BookStore.Models.Dtos;
using BookStore.Models.ViewModels;

namespace BookStore.Models.Exts
{
    public static class UsedBookExts
    {
        public static UsedBookIndexVm ToUsedBookIndexVm(this UsedBookDto dto)
        {
            return new UsedBookIndexVm()
            {
                Id = dto.Id,
                MemberEmail = dto.MemberEmail,
                BookName = dto.BookName,
                CategoryName = dto.CategoryName,
                ProductStatus = dto.ProductStatus,
                Price = dto.Price,
                ISBN = dto.ISBN,
                BookStatus = dto.BookStatus
            };
        }

        public static UsedBookDto ToUsedBookIndexVm(this UsedBookIndexVm vm)
        {
            return new UsedBookDto()
            {
                Id = vm.Id,
                MemberEmail = vm.MemberEmail,
                CategoryName = vm.CategoryName,
                ProductStatus = vm.ProductStatus,
                Price = vm.Price,
                ISBN = vm.ISBN,
                BookStatus = vm.BookStatus
            };
        }
    }
}