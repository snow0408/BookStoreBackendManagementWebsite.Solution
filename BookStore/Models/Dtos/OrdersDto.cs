using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Dtos
{
    public class OrdersDto
    {

        public int Id { get; set; }
        public int MemberId { get; set; }
        public string MemberName { get; set; }

        public DateTime OrderDate { get; set; }

        public string PaymentMethod { get; set; }
       
        public int DiscountAmount { get; set; }


        public int TotalAmount { get; set; }

        public string Status { get; set; }
        public string Message { get; set; }
    }
}