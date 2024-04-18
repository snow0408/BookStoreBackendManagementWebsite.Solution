using System;
using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class BookProductCreateVm
    {
        [Display(Name = "所選書籍")]
        public int? BookId { get; set; }

        public string BookName { get; set; }

        public int? ProductId { get; set; }

        [Display(Name = "出版商")]
        public int? PublisherId { get; set; }

        public string PublisherName { get; set; }

        [Display(Name = "出版日期")]
        public DateTime? PublishDate { get; set; }

        public string ISBN { get; set; }
    }
}