using BookStore.Models.Dtos;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
    public static class EBooksPermissionExt
    {
        public static EBooksPermissionDto ToEBooksPermissionDto(this EBooksPermissionVm vm)
        {
            return new EBooksPermissionDto
            {
                BookID = vm.BookID,
                MemberID = vm.MemberID,
                PermissionType = vm.PermissionType
            };
        }
    }
}