using BookStore202401.Models.Dtos;
using BookStore202401.Models.Exts;
using BookStore202401.Models.Interfaces;
using BookStore202401.Models.Repositories;
using BookStore202401.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore202401.Models.Service
{
    public class OrderDetailsService
    {
        private readonly IOrderDetailsRepo _repo;

        public OrderDetailsService(IOrderDetailsRepo repo)
        {
            _repo = repo;
        }

        

        //查詢//
        public List<OrderDetailsVm> Search(int OrdersId)
        {
            return _repo.Search(OrdersId)
                .Select(x => x.OrderDetailsVm())
                .ToList();
        }


        //取得一筆資料
        public OrderDetailsVm Get(int id)
        {
            return _repo.Get(id).OrderDetailsVm();
        }


        public List<SelectListItem> GetStatusSelectList()
        {
            List<SelectListItem> mySelectItemList = new List<SelectListItem>();

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "未付款",
                Value = "未付款",
                Selected = true
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "未出貨",
                Value = "未出貨",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "已送達",
                Value = "已送達",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "已退款",
                Value = "已退款",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "已退貨",
                Value = "已退貨",
                Selected = false
            });

            mySelectItemList.Add(new SelectListItem()
            {
                Text = "已取消",
                Value = "已取消",
                Selected = false
            });
            mySelectItemList.Add(new SelectListItem()
            {
                Text = "已完成",
                Value = "已完成",
                Selected = false
            });



            return mySelectItemList;
        }
        public List<SelectListItem> StatusSelectList()
        {

            var StatusSelectList = GetStatusSelectList();
            StatusSelectList.Add(new SelectListItem()
            {
                Text = "全部",
                Value = "",
                Selected = true
            });

            return StatusSelectList;
        }
    }
}