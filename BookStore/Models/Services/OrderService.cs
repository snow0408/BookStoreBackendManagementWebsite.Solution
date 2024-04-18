using BookStore202401.Models.Dtos;
using BookStore202401.Models.Exts;
using BookStore202401.Models.Interfaces;
using BookStore202401.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Service
{
	public class OrderService
	{
		private IOrderRepo _repo;
		public OrderService(IOrderRepo repos)
		{
			_repo = repos;
		}
		public void Edit(OrdersDto dto)
        {
            _repo.Edit(dto);
        }

        //新增
        public int Create(OrdersDto dto)
		{
			return _repo.Create(dto);
		}
		//更新
		public void Update(OrdersDto dto)
		{
			_repo.Update(dto);
		}

		//查詢//
		public List<OrderIndexVm> Search(string memberName,string status)
		{
			return _repo.Search(memberName,status)
				.Select(x=>x.OrderIndexVm())
				.ToList();
		}

		//查詢日期
		public List<OrderIndexVm> SearchByDate(DateTime startDate, DateTime endDate)
        {
            return _repo.SearchByDate(startDate, endDate)
                .Select(x => x.OrderIndexVm())
                .ToList();
        }
		
			
		//刪除
		public void Delete(int id)
		{
			_repo.Delete(id);
		}
		//取得一筆資料
		public OrdersDto Get(int id)
		{
			return _repo.Get(id);
		}
	

    }
}