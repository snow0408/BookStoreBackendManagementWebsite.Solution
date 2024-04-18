namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Books.EBooks")]
    public partial class EBook
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public EBook()
        {
            EBooksPermissions = new HashSet<EBooksPermission>();
        }

        public int Id { get; set; }

        public int BookId { get; set; }

        [Required]
        [StringLength(500)]
        public string FileLink { get; set; }

        [Required]
        [StringLength(500)]
        public string Sample { get; set; }

        public virtual Book Book { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<EBooksPermission> EBooksPermissions { get; set; }
    }
}
