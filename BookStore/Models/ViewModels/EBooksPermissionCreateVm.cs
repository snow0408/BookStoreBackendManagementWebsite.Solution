using BookStore.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class EBooksPermissionCreateVm
    {
        [Display(Name = "書籍名稱")]
        [Required(ErrorMessage = DAHelper.Required)]
        public int BookID { get; set; }

        [Display(Name = "會員ID")]
        [Required(ErrorMessage = DAHelper.Required)]
        public int MemberID { get; set; }

        [Display(Name = "權限來源")]
        [Required(ErrorMessage = DAHelper.Required)]
        public string PermissionType { get; set; }
    }
}