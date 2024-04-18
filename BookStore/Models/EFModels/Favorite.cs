namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Favorite
    {
        public int FavoriteID { get; set; }

        public int? MemberID { get; set; }

        public int? ItemID { get; set; }

        public virtual Member Member { get; set; }
    }
}
