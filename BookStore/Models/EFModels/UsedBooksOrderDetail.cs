namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UsedBooksOrderDetail
    {
        public int Id { get; set; }

        public int OrderID { get; set; }

        public int BookID { get; set; }

        public int UnitPrice { get; set; }

        public virtual UsedBook UsedBook { get; set; }

        public virtual UsedBooksOrder UsedBooksOrder { get; set; }
    }
}
