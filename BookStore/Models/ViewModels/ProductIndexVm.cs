using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class ProductIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "產品名稱")]
        public string Name { get; set; }

        [Display(Name = "價格")]
        public decimal Price { get; set; }

        [Display(Name = "上架狀態")]
        public string ProductStatus { get; set; }

        [Display(Name = "描述")]
        public string Description { get; set; }

        [Display(Name = "商品分類")]
        public string Category { get; set; }

        [Display(Name = "庫存")]
        public int Stock { get; set; }
    }
}