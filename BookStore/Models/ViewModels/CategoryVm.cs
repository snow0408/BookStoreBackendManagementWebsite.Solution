using BookStore.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class CategoryVm
    {
        public int Id { get; set; }

        [Display(Name = "分類名稱")]
        [Required(ErrorMessage = DAHelper.Required)]
        [StringLength(10,ErrorMessage =DAHelper.StringLength)]
        public string Name { get; set; }

        [Display(Name = "顯示排序")]
        [Required(ErrorMessage = DAHelper.Required)]
        public int DisplayOrder { get; set; }
    }
}