using BookStore.Models.Infra;
using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class BookSellersVm
    {
        public int ID { get; set; }

        [Display(Name = "出版商名稱")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(50, ErrorMessage = DAHelper.StringLength)]
        public string Name { get; set; }

        [Display(Name = "聯絡人")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(50, ErrorMessage = DAHelper.StringLength)]
        public string ContactPerson { get; set; }

        [Display(Name = "手機號碼")]
        [Required(ErrorMessage = "{0}必填")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "{0}格式不正確，應為10位數字")]
        public string Phone { get; set; } // 更改數據類型為string

        [Display(Name = "地址")]
        [Required(ErrorMessage = "{0}必填")]
        [StringLength(300, ErrorMessage = DAHelper.StringLength)]
        public string Address { get; set; }

        [Display(Name = "統編號碼")]
        [RegularExpression(@"^\d{8}$", ErrorMessage = "{0}應為8位數字")]
        public int? Compiled { get; set; }

        [Display(Name = "銀行帳號")]
        [StringLength(16, ErrorMessage = DAHelper.StringLength)]
        public string BankAccount { get; set; }
    }
}
