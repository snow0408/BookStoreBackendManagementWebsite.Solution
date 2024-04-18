using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
	public class UsedBookOrderDetailVm
	{
		public int Id { get; set; }

        public int OrderID { get; set; }

        [Display(Name = "編號")]
        public int BookID { get; set; }

        [Display(Name = "書籍名稱")]
        public string BookName { get; set; }

        [Display(Name = "單價")]
        public int UnitPrice { get; set; }

	}
}