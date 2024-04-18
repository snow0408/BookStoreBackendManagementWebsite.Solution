using BookStore.Models.Dtos;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models.Services
{
    public class EBooksPermissionService
    {
        private IEBooksPermissionRepostory _repo;
        public EBooksPermissionService(IEBooksPermissionRepostory repo)
        {
            _repo = repo;
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }

        public void Create(EBooksPermissionDto dto)
        {
            _repo.Create(dto);
        }

        public List<SelectListItem> PermissionTypeList()
        {
            List<SelectListItem> statusList = new List<SelectListItem>();

            statusList.Add(new SelectListItem()
            {
                Text = "購買",
                Value = "購買",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "活動贈送",
                Value = "活動贈送",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "點數兌換",
                Value = "點數兌換",
                Selected = false
            });


            return statusList;
        }

        public List<EBooksPermissionVm> Search(string bookName, string member)
        {
            var dtos = _repo.Search(bookName, member);
            var vms = dtos.Select(x => new EBooksPermissionVm()
            {
                Id = x.Id,
                BookID = x.BookID,
                BookName = x.BookName,
                MemberID = x.MemberID,
                MemberName = x.MemberName,
                CreateDate = x.CreateDate,
                PermissionType = x.PermissionType
            }).ToList();

            return vms;
        }

        public List<EBooksPermissionVm> SearchEBook(string keyword)
        {
            var dtos = _repo.SearchEBook(keyword);
            var vms = dtos.Select(x => new EBooksPermissionVm()
            {
                Id = x.Id,
                BookName = x.BookName
            }).ToList();

            return vms;
        }
    }
}