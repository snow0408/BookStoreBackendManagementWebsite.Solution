namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class BookReview
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ReviewID { get; set; }

        public int MemberID { get; set; }

        public DateTime ReviewTime { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(1)]
        public string Rating { get; set; }

        public bool IsSpoiler { get; set; }

        public virtual Member Member { get; set; }
    }
}
