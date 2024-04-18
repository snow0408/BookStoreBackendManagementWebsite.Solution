namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Books.BookProducts")]
    public partial class BookProduct
    {
        public int Id { get; set; }

        public int BookId { get; set; }

        public int ProductId { get; set; }

        public int PublisherId { get; set; }

        [Column(TypeName = "date")]
        public DateTime PublishDate { get; set; }

        [Required]
        [StringLength(13)]
        public string ISBN { get; set; }

        public virtual Book Book { get; set; }

        public virtual Bookseller Bookseller { get; set; }

        public virtual Product Product { get; set; }
    }
}
