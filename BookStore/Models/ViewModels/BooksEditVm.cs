using BookStore.Models.Infra;
using BookStore.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class BooksEditVm : IBookVm
    {
        public int Id { get; set; }

        [Display(Name = "書名")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(50, ErrorMessage = DAHelper.StringLength)]
        public string Name { get; set; }

        [Display(Name = "分類")]
        [Required(ErrorMessage = DAHelper.Required)]
        public int CategoryID { get; set; }

        [Display(Name = "作者")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(50, ErrorMessage = DAHelper.StringLength)]
        public string Author { get; set; }

        [Display(Name = "語言")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(50, ErrorMessage = DAHelper.StringLength),]
        public string Language { get; set; }

        //額外使用屬性
        public string CategoryName { get; set; }
    }
}