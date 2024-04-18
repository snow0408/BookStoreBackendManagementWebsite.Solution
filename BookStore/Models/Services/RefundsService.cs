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
    public class RefundsService
    {
        private readonly IRefundsRepo _repo;

        public RefundsService(IRefundsRepo repo)
        {
            _repo = repo;
        }
       

        //查詢//
        public List<RefundsVm> Search(int OrderId)
        {
            return _repo.Search(OrderId)
                .Select(x => x.RefundsVm())
                .ToList();
        }

        //取得一筆資料
        public RefundsDto Get(int id)
        {
            return _repo.Get(id);
        }

    }
}