namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Orders.Return")]
    public partial class Return
    {
        public int Id { get; set; }

        public int OrderId { get; set; }

        public int MemberId { get; set; }

        public int LogisticsOrderId { get; set; }

        public int Quantity { get; set; }

        [Required]
        [StringLength(50)]
        public string ReturnReason { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime ReturnDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime ProcessdDate { get; set; }

        public virtual Member Member { get; set; }

        public virtual LogisticsOrder LogisticsOrder { get; set; }

        public virtual Order Order { get; set; }
    }
}
