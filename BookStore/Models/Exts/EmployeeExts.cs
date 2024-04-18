using BookStore.Models.Dtos;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
    public static class EmployeeExts
    {
        public static EmployeeVm ToEmployeeVm(this EmployeeDto dto)
        {
            return new EmployeeVm
            {
                Id = dto.Id,
                Name = dto.Name,
                Gender = dto.Gender,
                Address = dto.Address,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                GroupId = dto.GroupId,
                Account = dto.Account,
                Password = dto.Password,


            };
        }
    }
}