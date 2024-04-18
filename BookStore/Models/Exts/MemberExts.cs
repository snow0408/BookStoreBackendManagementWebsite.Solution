using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
    public static class MemberExts
    {
        public static MemberVm ToMemberVm(this MemberDto dto)
        {
            return new MemberVm
            {
                Id = dto.Id,
                Name = dto.Name,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth.ToString("d"),
                Email = dto.Email,
                Password = dto.Password,
                MembersLevel = dto.MembersLevel,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Points = dto.Points,


            };
        }
        public static List<MemberVm> ToViewModels(this IEnumerable<MemberDto> dtos)
        {
            return dtos.Select(dto => new MemberVm
            {
                Id = dto.Id,
                Name = dto.Name,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth.ToString("d"),
                Email = dto.Email,
                
                MembersLevel = dto.MembersLevel,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Points = dto.Points,
            }).ToList();
        }
    }
}