namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UsedBooksOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsedBooksOrder()
        {
            UsedBooksAllocationRecords = new HashSet<UsedBooksAllocationRecord>();
            UsedBooksLogisticsOrders = new HashSet<UsedBooksLogisticsOrder>();
            UsedBooksOrderDetails = new HashSet<UsedBooksOrderDetail>();
            UsedBooksReturns = new HashSet<UsedBooksReturn>();
        }

        public int Id { get; set; }

        public int BuyerId { get; set; }

        public int SellerId { get; set; }

        public DateTime OrderDate { get; set; }

        public int TotalAmount { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public int ShippingFee { get; set; }

        [StringLength(50)]
        public string PaymentMethod { get; set; }

        public virtual Member Member { get; set; }

        public virtual Member Member1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsedBooksAllocationRecord> UsedBooksAllocationRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsedBooksLogisticsOrder> UsedBooksLogisticsOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsedBooksOrderDetail> UsedBooksOrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsedBooksReturn> UsedBooksReturns { get; set; }
    }
}
