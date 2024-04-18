using BookStore202401.Models.Dtos;
using BookStore202401.Models.Exts;
using BookStore202401.Models.Interfaces;
using BookStore202401.Models.Repositories;
using BookStore202401.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Service
{
    public class ReturnsService
    {
        private readonly IReturnsRepo _repo;

        public ReturnsService(IReturnsRepo repo)
        {
            _repo = repo;
        }
       

        //查詢//
        public List<ReturnsVm> Search(int orderId)
        {
            return _repo.Search(orderId)
                .Select(x => x.ReturnsVm())
                .ToList();
        }

        //取得一筆資料
        public ReturnsDto Get(int id)
        {
            return _repo.Get(id);
        }

    }
}