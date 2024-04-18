namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class WriteBookReview
    {
        public int ID { get; set; }

        public int MemberID { get; set; }

        public int BookID { get; set; }

        public DateTime ReviewDate { get; set; }

        [Required]
        public string ReviewContent { get; set; }

        public int ReviewRating { get; set; }

        public virtual Member Member { get; set; }

        public virtual Product Product { get; set; }
    }
}
