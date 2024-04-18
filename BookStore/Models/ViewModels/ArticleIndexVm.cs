using BookStore.Models.EFModels;
using BookStore.Models.Infra;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models.ViewModels
{
    public class ArticleIndexVm
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        [Display(Name = "文章編號")]
        public int ArticleID { get; set; }

        [Required]
        [Display(Name = "標題")]
        [StringLength(50)]
        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "請輸入標題")]
        [RegularExpression(@"^[\u4e00-\u9fa5a-zA-Z0-9]+$", ErrorMessage = "標題只能為中英文或數字")]
        [Remote("TitleCheck", "Articles", ErrorMessage = "標題已存在")]
        public string Title { get; set; }

        [Display(Name = "發佈時間")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Range(typeof(DateTime), "1900-01-01", "2100-01-01", ErrorMessage = "發佈時間不在有效範圍")]

        public DateTime PublishTime { get; set; }

        [Display(Name = "分類")]
        [DataType(DataType.Text)]
        [DisplayFormat(NullDisplayText = "請輸入分類")]

        public string Category { get; set; }

        [Display(Name = "分類清單")]
        [DataType(DataType.Text)]
        public IEnumerable<SelectListItem> Categories { get; set; }
    }
}