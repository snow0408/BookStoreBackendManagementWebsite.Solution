using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class BooksIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "書籍名稱")]
        public string Name { get; set; }

       

        [Display(Name = "作者")]
        public string Author { get; set; }

        [Display(Name = "分類")]
        public string CategoryName { get; set; }

        [Display(Name = "語言")]
        public string Language { get; set; }


        
    }
}