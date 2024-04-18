namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EBooksPermission
    {
        public int Id { get; set; }

        public int BookID { get; set; }

        public int MemberID { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime CreateDate { get; set; }

        [StringLength(50)]
        public string PermissionType { get; set; }

        public virtual EBook EBook { get; set; }

        public virtual Member Member { get; set; }
    }
}
