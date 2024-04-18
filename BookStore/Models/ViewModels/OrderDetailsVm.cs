using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.ViewModels
{
    public class OrderDetailsVm
    {
        [Display(Name = "訂單編號")]
        public int OrderId { get; set; }
      
        [Display(Name = "商品")]
        public string ProductName { get; set; }
        [Display(Name = "數量")]
        public int Quantity { get; set; }
        [Display(Name = "單價")]
        public decimal UnitPrice { get; set; }

        

    }
}