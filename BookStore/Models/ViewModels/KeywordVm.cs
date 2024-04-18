using BookStore.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BookStore.Models.ViewModels
{
    public class KeywordVm
    {
        public int Id { get; set; }

        [Display(Name = "關鍵詞名稱")]
        [Required(ErrorMessage = DAHelper.Required)]
        public string Name { get; set; }
    }
}