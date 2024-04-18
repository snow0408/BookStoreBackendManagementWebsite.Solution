using BookStore.Models.EFModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.Dtos
{
    public class ArticleDto
    {
        public int ArticleID { get; set; }

        public int EmployeeID { get; set; }

        public string Title { get; set; }

        public DateTime PublishTime { get; set; }

        public string Content { get; set; }

        public string Category { get; set; }

        public virtual Employee Employee { get; set; }
    }
}