using BookStore.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class BookSellersIndexVm
    {
        public int ID { get; set; }

        [Display(Name = "書商名稱")]
        public string Name { get; set; }

        [Display(Name = "聯絡人")]
        public string ContactPerson { get; set; }

        [Display(Name = "手機號碼")]
        public string Phone { get; set; }

        [Display(Name = "地址")]
        public string Address { get; set; }


        [Display(Name = "統編號碼")]
        public int? Compiled { get; set; }
    }
}