using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class EBookVm
    {
        [Display(Name = "書籍名稱")]
        public string BookName { get; set; }
        public int Id { get; set; }
        [Display(Name = "書籍編號")]
        public int BookId { get; set; }
        [Display(Name = "檔案連結")]
        public string FileLink { get; set; }
        [Display(Name = "試閱")]
        public string Sample { get; set; }
    }
}