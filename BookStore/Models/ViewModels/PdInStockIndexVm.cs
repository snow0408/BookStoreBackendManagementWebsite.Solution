using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class PdInStockIndexVm
    {

        public int ID { get; set; }

        [Display(Name = "商品編號")]
        public int ProductId { get; set; }

        [Display(Name = "商品名稱")]
        public string ProductName { get; set; }

        [Display(Name = "品項類別")]
        public string CategoryName { get; set; }

        [Display(Name = "出版商")]
        public string BooksellerName { get; set; }

        [Display(Name = "進貨數量")]
        public int Qty { get; set; }

        [Display(Name = "最近進貨日")]
        public DateTime BuyDate { get; set; }

        [Display(Name = "進貨價格")]
        public decimal BuyPrice { get; set; }

        [Display(Name = "目前庫存量")]
        public int Stock { get; set; }

        [Display(Name = "庫存狀態")]
        public string Status { get; set; }

    }
}