using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.Dtos
{
    public class PromotionEventDto
    {
        [Key]
        public int EventID { get; set; }

        [Required]
        [StringLength(255)]
        public string EventName { get; set; }

        [Required]
        [StringLength(100)]
        public string EventSerialNumber { get; set; }

        [Required]
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

        [Required]
        public string EventDetails { get; set; }

        [Required]
        public byte[] EventFile { get; set; }
    }
}