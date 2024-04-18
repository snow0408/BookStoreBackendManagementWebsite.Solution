using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Interfaces
{
    public interface IMemberRepository
    {
        void Create(MemberDto memberDto);
        List<MemberDto> GetAll();
        MemberDto GetById(int id);
        void Delete(int id);
        List<MemberDto> Search(string name);
        void Update(MemberDto dto);
    }
}