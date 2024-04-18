namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AnalyzeUserInteraction
    {
        public int ID { get; set; }

        public int MemberID { get; set; }

        public int BookID { get; set; }

        public DateTime InteractionDate { get; set; }

        [Required]
        [StringLength(50)]
        public string InteractionType { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
