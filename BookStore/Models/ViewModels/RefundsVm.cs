using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.ViewModels
{
    public class RefundsVm
    {
        public int Id { get; set; }
        [Display(Name = "訂單編號")]
        public int OrderId { get; set; }
        [Display(Name = "申請日期")]
        public DateTime ApplicationDate { get; set; }
        [Display(Name = "退款金額")]
        public int Amount { get; set; }
        [Display(Name = "退款狀態")]
        public string RefundStatus { get; set; }


    }
}