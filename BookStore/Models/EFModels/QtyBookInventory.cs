namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QtyBookInventory
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public decimal BuyPrice { get; set; }

        public int TotalQty { get; set; }

        [Required]
        [StringLength(50)]
        public string State { get; set; }

        public string Remark { get; set; }

        public virtual Product Product { get; set; }
    }
}
