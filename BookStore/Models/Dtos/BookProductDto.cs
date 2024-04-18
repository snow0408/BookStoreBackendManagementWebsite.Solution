using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.Dtos
{
    public class BookProductDto
    {
        public int Id { get; set; }
        public int BookId { get; set; }

        public int ProductId { get; set; }
        public int PublisherId { get; set; }

        [Display(Name = "出版日期")]
        public DateTime? PublishDate { get; set; }
        public string ISBN { get; set; }

        //額外屬性
        [Display(Name = "出版商")]
        public string PublisherName { get; set; }

        //Book
        [Display(Name = "書名")]
        public string BookName { get; set; }
        public string Author { get; set; }
        public string BookLanguage { set; get; }
        public string CategoryName { get; set; }
    }
}