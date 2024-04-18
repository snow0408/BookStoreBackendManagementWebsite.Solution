namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class News
    {
        [StringLength(50)]
        public string NewsID { get; set; }

        public int EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public DateTime PublishTime { get; set; }

        [Required]
        public string Content { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
