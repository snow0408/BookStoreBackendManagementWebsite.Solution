namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PromotionEvent
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [StringLength(255)]
        public string EventName { get; set; }

        [Required]
        [StringLength(100)]
        public string EventSerialNumber { get; set; }

        [StringLength(500)]
        public string EventDescription { get; set; }

        [Required]
        [StringLength(100)]
        public string DiscountType { get; set; }

        [Required]
        [StringLength(100)]
        public string EventType { get; set; }

        public decimal DiscountRate { get; set; }

        [Required]
        [StringLength(100)]
        public string OfferStatus { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public string EventDetails { get; set; }

        public byte[] EventFile { get; set; }
    }
}
