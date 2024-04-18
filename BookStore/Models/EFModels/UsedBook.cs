namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Books.UsedBooks")]
    public partial class UsedBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UsedBook()
        {
            UsedBooksCarts = new HashSet<UsedBooksCart>();
            UsedBooksOrderDetails = new HashSet<UsedBooksOrderDetail>();
        }

        public int Id { get; set; }

        public int MemberId { get; set; }

        public int CategoryId { get; set; }

        public bool ProductStatus { get; set; }

        public decimal Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [StringLength(50)]
        public string ISBN { get; set; }

        [StringLength(500)]
        public string Pictrue { get; set; }

        [Required]
        [StringLength(500)]
        public string BookStatus { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public virtual Category Category { get; set; }

        public virtual Member Member { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsedBooksCart> UsedBooksCarts { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<UsedBooksOrderDetail> UsedBooksOrderDetails { get; set; }
    }
}
