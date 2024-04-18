namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UsedBooksReturn")]
    public partial class UsedBooksReturn
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int OrderID { get; set; }

        [Key]
        [Column(Order = 2)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MemberID { get; set; }

        [Key]
        [Column(Order = 3, TypeName = "datetime2")]
        public DateTime ApplicationDate { get; set; }

        [Key]
        [Column(Order = 4)]
        [StringLength(50)]
        public string ReturnReason { get; set; }

        [Key]
        [Column(Order = 5)]
        [StringLength(50)]
        public string Status { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? ProcessedDate { get; set; }

        public virtual UsedBooksOrder UsedBooksOrder { get; set; }
    }
}
