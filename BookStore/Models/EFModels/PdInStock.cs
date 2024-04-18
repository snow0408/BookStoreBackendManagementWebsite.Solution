namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PdInStock")]
    public partial class PdInStock
    {
        public int ID { get; set; }

        public int ProductId { get; set; }

        public int? SupplierID { get; set; }

        public int Qty { get; set; }

        public DateTime BuyDate { get; set; }

        public decimal BuyPrice { get; set; }

        public virtual Bookseller Bookseller { get; set; }

        public virtual Product Product { get; set; }
    }
}
