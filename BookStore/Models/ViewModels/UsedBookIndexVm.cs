using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class UsedBookIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "會員Email")]
        public string MemberEmail { get; set; }

        [Display(Name = "書名")]
        public string BookName { get; set; }

        [Display(Name = "書籍分類")]
        public string CategoryName { get; set; }

        [Display(Name = "是否上架")]
        public bool ProductStatus { get; set; }

        [Display(Name = "販賣價格")]
        public decimal Price { get; set; }

        public string ISBN { get; set; }

        [Display(Name = "書況")]
        public string BookStatus { get; set; }

    }
}