namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orders.Refund")]
    public partial class Refund
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public DateTime ApplicationDate { get; set; }

        public int Amount { get; set; }

        [Required]
        [StringLength(50)]
        public string RefundStatus { get; set; }

        public virtual Order Order { get; set; }
    }
}
