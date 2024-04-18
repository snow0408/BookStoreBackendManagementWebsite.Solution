using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class MemberRepository : IMemberRepository
    {
        private readonly AppDbContext _db = new AppDbContext();

        public void Create(MemberDto dto)
        {
            var member = new Member
            {
                Name = dto.Name,
                Gender = dto.Gender,
                DateOfBirth = dto.DateOfBirth,
                Email = dto.Email,
                Password = dto.Password,
                MembersLevel = dto.MembersLevel,
                Address = dto.Address,
                PhoneNumber = dto.PhoneNumber,
                Points = dto.Points
            };
            _db.Members.Add(member);
            _db.SaveChanges();
        }
        public void AddMemberFromVm(MemberVm model)
        {
            var dto = new MemberDto
            {
                Name = model.Name,
                Gender = model.Gender,
                DateOfBirth = DateTime.Parse(model.DateOfBirth),
                Email = model.Email,
                Password = model.Password, // 考慮在這裡進行密碼加密
                MembersLevel = model.MembersLevel,
                Address = model.Address,
                PhoneNumber = model.PhoneNumber,
                Points = model.Points
            };

            // 假設有一個方法將 MemberDto 轉換並儲存到數據庫
            Create(dto); // 假設這是將 dto 儲存到數據庫的方法
        }

        public List<MemberDto> GetAll()
        {
            return _db.Members.Select(m => new MemberDto
            {
                Id = m.Id,
                Name = m.Name,
                Gender = m.Gender,
                DateOfBirth = m.DateOfBirth,
                Email = m.Email,
                Password = m.Password,
                MembersLevel = m.MembersLevel,
                Address = m.Address,
                PhoneNumber = m.PhoneNumber,
                Points = m.Points
            }).ToList();
        }

        public MemberDto GetById(int id)
        {
            var member = _db.Members.Find(id);
            if (member != null)
            {
                return new MemberDto
                {
                    Id = member.Id,
                    Name = member.Name,
                    Gender = member.Gender,
                    DateOfBirth = member.DateOfBirth,
                    Email = member.Email,
                    Password = member.Password,
                    MembersLevel = member.MembersLevel,
                    Address = member.Address,
                    PhoneNumber = member.PhoneNumber,
                    Points = member.Points
                };
            }
            return null;
        }

        public void Delete(int id)
        {
            var member = _db.Members.Find(id);
            if (member != null)
            {
                _db.Members.Remove(member);
                _db.SaveChanges();
            }
        }

        public List<MemberDto> Search(string name)
        {
            return _db.Members.Where(m => m.Name.Contains(name)).Select(m => new MemberDto
            {
                Id = m.Id,
                Name = m.Name,
                Gender = m.Gender,
                DateOfBirth = m.DateOfBirth,
                Email = m.Email,
                Password = m.Password,
                MembersLevel = m.MembersLevel,
                Address = m.Address,
                PhoneNumber = m.PhoneNumber,
                Points = m.Points
            }).ToList();
        }

        public void Update(MemberDto dto)
        {
            var member = _db.Members.Find(dto.Id);
            if (member != null)
            {
                member.Name = dto.Name;
                member.Gender = dto.Gender;
                member.DateOfBirth = dto.DateOfBirth;
                member.Email = dto.Email;
                member.Password = dto.Password;
                member.MembersLevel = dto.MembersLevel;
                member.Address = dto.Address;
                member.PhoneNumber = dto.PhoneNumber;
                member.Points = dto.Points;
                _db.Entry(member).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }


    }
}
