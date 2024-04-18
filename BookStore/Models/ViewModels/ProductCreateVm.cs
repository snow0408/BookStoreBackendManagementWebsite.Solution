using BookStore.Models.Infra;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class ProductCreateVm
    {
        public int Id { get; set; }

        [Display(Name = "商品名稱")]
        [Required(ErrorMessage = DAHelper.Required)]
        public string Name { get; set; }

        [Display(Name = "價格")]
        [Required(ErrorMessage = DAHelper.Required)]
        public decimal Price { get; set; }

        [Display(Name = "存貨狀態")]
        [Required(ErrorMessage = DAHelper.Required)]
        public string ProductStatus { get; set; }

        [Display(Name = "簡介")]
        [Required(ErrorMessage = DAHelper.Required)]
        public string Description { get; set; }

        [Display(Name = "商品分類")]
        [Required(ErrorMessage = DAHelper.Required)]
        public string Category { get; set; }

        [Display(Name = "關鍵詞")]
        public List<int> ProductKeywordsId { get; set; }

        [Display(Name = "商品圖片")]
        public string FileName { get; set; }



        public BookProductCreateVm BookProduct { get; set; }
    }
}