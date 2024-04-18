using System.Web.Mvc;
using BookStore.Models.Dtos;
using BookStore.Models.ViewModels;
using BookStore.Models.Services;
using BookStore.Models.Repositories;
using BookStore.Models.Exts;
using System.Collections.Generic;
using System;
using System.Net; // 确保引入正确的命名空间

namespace BookStore.Controllers
{
    public class MemberController : Controller
    {
        private readonly MemberService _memberService = new MemberService(new MemberRepository());

        // GET: Member
        public ActionResult Index(string search)
        {
            List<MemberDto> memberDtos;
            if (string.IsNullOrWhiteSpace(search))
            {
                memberDtos = _memberService.GetAllMembers(); 
            }
            else
            {
                memberDtos = _memberService.SearchMembersByName(search); 
            }

            var memberVms = memberDtos.ToViewModels(); 
            return View(memberVms);
        }



        // GET: Member/Details/5
        public ActionResult Details(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return HttpNotFound();
            }
            // 根据需要转换 DTO 到 ViewModel
            return View(member);
        }

        // GET: Member/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MemberVm model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _memberService.AddMemberFromVm(model); // 使用新方法
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    // 處理新增過程中可能出現的異常
                    ModelState.AddModelError("", "新增失敗: " + ex.Message);
                }
            }

            // 如果數據不合法或新增過程中出錯，重新顯示表單
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var memberDto = _memberService.GetMemberById(id);
            if (memberDto == null)
            {
                return HttpNotFound();
            }
            var memberVm = memberDto.ToMemberVm();
            memberVm.DateOfBirth = memberDto.DateOfBirth.ToString("yyyy-MM-dd");
            return View(memberVm);
        }

        // POST: Member/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(MemberVm model)
        {
            if (ModelState.IsValid) 
            {
                try
                {
                    var memberDto = new MemberDto
                    {
                        Id = model.Id,
                        Name = model.Name,
                        Gender = model.Gender,
                        DateOfBirth = DateTime.Parse(model.DateOfBirth),
                        Email = model.Email,
                        Password = model.Password, 
                        MembersLevel = model.MembersLevel,
                        Address = model.Address,
                        PhoneNumber = model.PhoneNumber,
                        Points = model.Points
                    };
                    _memberService.UpdateMember(memberDto);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ModelState.AddModelError("", "更新失敗: " + ex.Message);
                }
            }

            return View(model);
        }
        // GET: Member/Delete/5
        // GET: Member/Delete/5
        public ActionResult Delete(int id)
        {
            // 這裡可以添加獲取要刪除的會員信息的邏輯，用於確認頁面
            return View();
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _memberService.DeleteMember(id);
            return RedirectToAction("Index");
        }




    }
}
