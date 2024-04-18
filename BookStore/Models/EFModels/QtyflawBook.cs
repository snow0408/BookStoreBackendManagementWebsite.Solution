namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class QtyflawBook
    {
        public int ID { get; set; }

        public int BookID { get; set; }

        [Required]
        [StringLength(100)]
        public string Reason { get; set; }

        public DateTime HandlingDate { get; set; }

        [Required]
        [StringLength(50)]
        public string HandlingMethod { get; set; }

        [Required]
        [StringLength(50)]
        public string Handler { get; set; }

        [Required]
        [StringLength(50)]
        public string Status { get; set; }

        public virtual Product Product { get; set; }
    }
}
