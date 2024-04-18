using BookStore.Models.Dtos;
using BookStore.Models.Infra;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class ProductEditVm
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

        [Display(Name = "分類")]
        public string Category { get; set; }

        public int Stock { get; set; }

        public BookProductDto BookProduct { get; set; }

    }
}