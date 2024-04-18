using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class UsedBookOrderVm
    {
        [Display(Name = "訂單編號")]
        public int Id { get; set; }

        [Display(Name = "買家")]
        public string BuyerName { get; set; }

        [Display(Name = "賣家")]
        public string SellerName { get; set; }

        [Display(Name = "下單日期")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "訂單金額")]
        public int TotalAmount { get; set; }

        [Display(Name = "訂單狀態")]
        public string Status { get; set; }

        [Display(Name = "運費")]
        public int ShippingFee { get; set; }

        [Display(Name = "付款方式")]
        public string PaymentMethod { get; set; }
    }
}