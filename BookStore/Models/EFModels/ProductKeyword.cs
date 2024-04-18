namespace BookStore.Models.EFModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ProductKeyword
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int KeywordId { get; set; }

        public virtual Keyword Keyword { get; set; }

        public virtual Product Product { get; set; }
    }
}
