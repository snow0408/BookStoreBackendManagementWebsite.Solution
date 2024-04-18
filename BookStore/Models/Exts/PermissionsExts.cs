using BookStore202401.Models.Dtos;
using BookStore202401.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Exts
{
    public static class PermissionsExts
    {
        public static PermissionsVm PermissionsVm(this PermissionsDto dto)
        {

            return new PermissionsVm()
            {
               
            };
        }
    }
}