namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class UsedBooksAllocationRecord
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }

        public int OrderID { get; set; }

        public int MemberID { get; set; }

        [Required]
        [StringLength(50)]
        public string AllocationAccount { get; set; }

        public int AllocationAmount { get; set; }

        public int PlatformShareAmount { get; set; }

        public virtual Member Member { get; set; }

        public virtual UsedBooksOrder UsedBooksOrder { get; set; }
    }
}
