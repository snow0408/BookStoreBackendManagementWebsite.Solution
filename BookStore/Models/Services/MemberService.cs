using BookStore.Models.Dtos;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;

public class MemberService
{
    private readonly IMemberRepository _memberRepository;


    public MemberService(IMemberRepository memberRepository)
    {
        _memberRepository = memberRepository;
    }
    public void AddMemberFromVm(MemberVm model)
    {
        // 將 MemberVm 轉換為 MemberDto
        var dto = new MemberDto
        {
            Name = model.Name,
            Gender = model.Gender,
            DateOfBirth = DateTime.Parse(model.DateOfBirth),
            Email = model.Email,
            Password = model.Password, // 在實際應用中，應考慮加密處理
            MembersLevel = model.MembersLevel,
            Address = model.Address,
            PhoneNumber = model.PhoneNumber,
            Points = model.Points
        };

        // 使用 _memberRepository 將轉換後的 MemberDto 儲存到數據庫
        _memberRepository.Create(dto);
    }

    public void AddMember(MemberDto dto)
    {
        _memberRepository.Create(dto);
    }

    public List<MemberDto> GetAllMembers()
    {
        return _memberRepository.GetAll();
    }

    public MemberDto GetMemberById(int id)
    {
        return _memberRepository.GetById(id);
    }

    public void UpdateMember(MemberDto dto)
    {
        _memberRepository.Update(dto);
    }


    public List<MemberDto> SearchMembersByName(string name)
    {
        return _memberRepository.Search(name);
    }
    public void DeleteMember(int id)
    {
        _memberRepository.Delete(id);
    }
}
