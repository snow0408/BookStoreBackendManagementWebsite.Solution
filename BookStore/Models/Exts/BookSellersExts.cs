using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
    public static class BookSellersExts
    {

        public static BookSellersVm ToBookSellerVm(this BookSellersDto dto)
        {
            return new BookSellersVm
            {
                ID = dto.ID,
                Name = dto.Name,
                ContactPerson = dto.ContactPerson,
                Phone = dto.Phone,
                Address = dto.Address,
                Compiled = dto.Compiled,
                BankAccount = dto.BankAccount
            };
        }

        public static BookSellersDto ToBookSellersDto(this BookSellersVm vm)
        {
            return new BookSellersDto
            {
                ID = vm.ID,
                Name = vm.Name,
                ContactPerson = vm.ContactPerson,
                Phone = vm.Phone,
                Address = vm.Address,
                Compiled = vm.Compiled,
                BankAccount = vm.BankAccount
            };
        }

        public static BookSellersIndexVm ToBookSellersIndexVm(this BookSellersDto dto)
        {
            return new BookSellersIndexVm
            {
                ID = dto.ID,
                Name = dto.Name,
                ContactPerson = dto.ContactPerson,
                Phone = dto.Phone,
                Address = dto.Address,
                Compiled = dto.Compiled
            };
        }

        public static BookSellersDto ToBookSellersDto(this Bookseller entity)
        {
            var dto = new BookSellersDto();
            if (entity != null)
            {
                dto.ID = entity.ID;
                dto.Name = entity.Name;
                dto.ContactPerson = entity.ContactPerson;
                dto.Phone = entity.Phone;
                dto.Address = entity.Address;
                dto.Compiled = entity.Compiled;
                dto.BankAccount = entity.BankAccount;
            }
            return dto;
        }
    }
}