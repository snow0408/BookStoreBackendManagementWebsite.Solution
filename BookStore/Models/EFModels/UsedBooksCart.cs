namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsedBooksCart")]
    public partial class UsedBooksCart
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int MemberID { get; set; }

        public int BookID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime AddToCartDate { get; set; }

        public int UnitPrice { get; set; }

        public virtual UsedBook UsedBook { get; set; }

        public virtual Member Member { get; set; }
    }
}
