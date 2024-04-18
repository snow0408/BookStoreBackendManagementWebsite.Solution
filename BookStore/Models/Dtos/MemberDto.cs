using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.Dtos
{
    public class MemberDto
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public bool Gender { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string MembersLevel { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public int Points { get; set; }
    }
}