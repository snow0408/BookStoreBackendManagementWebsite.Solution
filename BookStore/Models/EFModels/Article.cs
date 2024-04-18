namespace BookStore.Models.EFModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Article
    {
        public int ArticleID { get; set; }

        public int? EmployeeID { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public DateTime? PublishTime { get; set; }

        public string Content { get; set; }

        [StringLength(50)]
        public string Category { get; set; }

        public virtual Employee Employee { get; set; }
    }
}
