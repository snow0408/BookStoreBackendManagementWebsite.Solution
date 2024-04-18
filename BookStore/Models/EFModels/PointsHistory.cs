namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PointsHistory")]
    public partial class PointsHistory
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int MemberId { get; set; }

        public int PointChange { get; set; }

        [Required]
        [StringLength(50)]
        public string ChangeReason { get; set; }

        [Column(TypeName = "date")]
        public DateTime ChangeDate { get; set; }

        public virtual Member Member { get; set; }
    }
}
