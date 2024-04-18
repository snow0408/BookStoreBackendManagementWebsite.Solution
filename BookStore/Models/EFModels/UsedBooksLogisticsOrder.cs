namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsedBooksLogisticsOrder")]
    public partial class UsedBooksLogisticsOrder
    {
        public int Id { get; set; }

        public int OrderID { get; set; }

        [Required]
        [StringLength(50)]
        public string LogisticsCompany { get; set; }

        [Required]
        [StringLength(50)]
        public string TrackingNumber { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime EstimateDeliveryDate { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ActualDeliveryDate { get; set; }

        [Required]
        [StringLength(50)]
        public string PickupMethod { get; set; }

        [Required]
        [StringLength(50)]
        public string SenderAddress { get; set; }

        [Required]
        [StringLength(50)]
        public string SenderPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string SenderName { get; set; }

        [Required]
        [StringLength(50)]
        public string RecipientName { get; set; }

        [Required]
        [StringLength(50)]
        public string RecipientPhone { get; set; }

        [Required]
        [StringLength(50)]
        public string RecipientAddress { get; set; }

        public virtual UsedBooksOrder UsedBooksOrder { get; set; }
    }
}
