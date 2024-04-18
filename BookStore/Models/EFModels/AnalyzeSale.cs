namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AnalyzeSale
    {
        public int ID { get; set; }

        public long DateRange { get; set; }

        public int BookID { get; set; }

        public int Quantity { get; set; }

        public decimal Total { get; set; }

        public virtual Product Product { get; set; }
    }
}
