using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class CategoryIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "分類名稱")]
        public string Name { get; set; }

        [Display(Name = "顯示排序")]
        public int DisplayOrder { get; set; }

    }
}