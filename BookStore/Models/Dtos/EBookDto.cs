using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Dtos
{
    public class EBookDto
    {
        public string BookName { get; set; }
        public int Id { get; set; }
       
        public int BookId { get; set; }
        public string FileLink { get; set; }
        public string Sample { get; set; }
    }
}