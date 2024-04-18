using BookStore.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class PdInStockVm
    {
        public int ID { get; set; }

        [Display(Name = "商品編號")]
        public int ProductId { get; set; }

        [Display(Name = "商品名稱")]
        public string ProductName { get; set; }


        [Display(Name = "品項類別")]
        public string CategoryName { get; set; }

        [Display(Name = "進貨數量")]
        [Required(ErrorMessage = "{0}必選")]
        public int Qty { get; set; }

        [Display(Name = "進貨日")]
        [Required(ErrorMessage = "{0}必填")]
        public DateTime BuyDate { get; set; }

        [Display(Name = "進貨價格")]
        [Required(ErrorMessage = "{0}必填")]
        public decimal BuyPrice { get; set; }

        [Display(Name = "進貨數量")]
        public int StockInQuantity { get; set; }

        [Display(Name = "報廢數量")]
        public int ScrapQuantity { get; set; }

        //public List<PdInStockVm> PdInStockRecords { get; set; } 
    }
}