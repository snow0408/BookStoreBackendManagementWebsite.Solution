using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.ViewModels
{
    public class ReturnsVm
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int MemberId { get; set; }

        public int LogisticsOrderId { get; set; }

        public int Quantity { get; set; }

        public string ReturnReason { get; set; }

        public string Status { get; set; }

        public DateTime ReturnDate { get; set; }

        public DateTime ProcessdDate { get; set; }

    }
}