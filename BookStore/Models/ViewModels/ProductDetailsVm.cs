using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class ProductDetailsVm
    {
        [Display(Name = "進貨ID")]
        public int Id { get; set; }

        [Display(Name = "產品ID")]
        public int ProductId { get; set; }

        [Display(Name = "商品名稱")]
        public string Name { get; set; }

        [Display(Name = "商品分類")]
        public string Category { get; set; }

        [Display(Name = "出版商")]
        public string BooksellerName { get; set; }

        [Display(Name = "庫存")]
        public int Stock { get; set; }

        [Display(Name = "狀態")]
        public string Status { get; set; }

        [Display(Name = "定價")]
        public decimal Price { get; set; }
        

        //// 新增属性：进货数量和报废数量，用于进货和报废操作
        //[Display(Name = "進貨數量")]
        //public int StockInQuantity { get; set; }

        //[Display(Name = "報廢數量")]
        //public int ScrapQuantity { get; set; }

        // 表單屬性
        public PdInStockVm pdInStockVm { get; set; }
        // 新增属性：历史进货记录列表
        public List<PdInStockVm> PdInStockRecords { get; set; }
    }
}