using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class EBooksPermissionVm
    {
        public int Id { get; set; }

        [Display(Name = "書籍id")]
        public int BookID { get; set; }

		[Display(Name = "書籍名稱")]
		public string BookName { get; set; }

		[Display(Name = "會員ID")]
        public int MemberID { get; set; }

        [Display(Name = "會員名稱")]
        public string MemberName { get; set; }

        [Display(Name = "新增日期")] 
        public DateTime CreateDate { get; set; }

        [Display(Name = "權限來源")]
        public string PermissionType { get; set; }
    }
}