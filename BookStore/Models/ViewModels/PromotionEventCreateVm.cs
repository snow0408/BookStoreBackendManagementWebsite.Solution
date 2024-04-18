using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
    public class PromotionEventCreateVm
    {
        [Display(Name = "活動編號")]
        public int EventID { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "活動名稱")]
        public string EventName { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "活動序號")]
        public string EventSerialNumber { get; set; }

        [Required]
        [StringLength(500)]
        [Display(Name = "活動描述")]
        public string EventDescription { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "折扣類型")]
        public string DiscountType { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "活動類型")]
        public string EventType { get; set; }
        [Display(Name = "折扣程度")]
        public decimal DiscountRate { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "活動狀態")]
        public string OfferStatus { get; set; }

        [Display(Name = "開始日期")]
        public DateTime StartDate { get; set; }

        [Display(Name = "結束日期")]
        public DateTime EndDate { get; set; }

        [Required]
        [Display(Name = "活動詳情")]
        public string EventDetails { get; set; }

        [Display(Name = "活動檔案")]
        public byte[] EventFile { get; set; }
    }
}