using Antlr.Runtime.Misc;
using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Infrastructure;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models.Services
{
    public class PromotionEventService
    {
        private IPromotionEventRepository _repo;
        public PromotionEventService(IPromotionEventRepository repo)
        {
            _repo = repo;
        }

        ////取得一筆資料
        //public PromotionEventDto Get(int id)
        //{
        //    return _repo.Get(id);
        //}

        public void Create(PromotionEventDto dto)
        {
            _repo.Create(dto);
        }

        public void Update(PromotionEventDto dto)
        {
            _repo.Update(dto);
        }

        public void Delete(int id)
        {
            _repo.Delete(id);
        }
        public IEnumerable<PromotionEventDto> GetAll()
        {
            return _repo.GetAll();
        }


        public List<SelectListItem> OfferStatusList()
        {

            List<SelectListItem> statusList = new List<SelectListItem>();
            statusList.Add(new SelectListItem()
            {
                Text = "未啟用",
                Value = "未啟用",
                Selected = false

            });
            statusList.Add(new SelectListItem()
            {
                Text = "啟用",
                Value = "啟用",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "已暫停",
                Value = "已暫停",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "停用",
                Value = "停用",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "已結束",
                Value = "已結束",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "已刪除",
                Value = "已刪除",
                Selected = false
            });
            return statusList;
        }

        public List<SelectListItem> DiscountTypeList()
        {

            List<SelectListItem> statusList = new List<SelectListItem>();
            statusList.Add(new SelectListItem()
            {
                Text = "按訂單金額",
                Value = "按訂單金額",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "按類別金額",
                Value = "按類別金額",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "按商品類別",
                Value = "按商品類別",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "按商品",
                Value = "按商品",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "按發行商",
                Value = "按發行商",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "按品牌",
                Value = "按品牌",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "按單價",
                Value = "按單價",
                Selected = false
            });

            return statusList;
        }

        public  List<SelectListItem> EventTypeList()
        {
            List<SelectListItem> statusList = new List<SelectListItem>();
            statusList.Add(new SelectListItem()
            {
                Text = "百分比折扣",
                Value = "百分比折扣",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "現金折扣",
                Value = "現金折扣",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "免運費",
                Value = "免運費",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "滿額送",
                Value = "滿額送",
                Selected = false
            });
            return statusList;
        }

        public List<PromotionEventIndexVm> Search(string name)
        {
            return _repo.SearchEvent(name)
                         .Select(x => new PromotionEventIndexVm()
                         {
                            EventID = x.EventID,
                            EventName = x.EventName,
                            StartDate = x.StartDate,
                            EndDate = x.EndDate,
                            OfferStatus = x.OfferStatus,
                            DiscountType = x.DiscountType,
                            EventSerialNumber =x.EventSerialNumber,
                            EventDescription = x.EventDescription,
                            EventType = x.EventType,
                            DiscountRate = x.DiscountRate,
                         })
                         .OrderBy(x => x.EventName)
                         .ToList();
        }

        //public List<PromotionEventVm> SearchEvent(string keyword)
        //{
        //    var dtos = _repo.SearchEvent(keyword);
        //    var vms = dtos.Select(x => new PromotionEventVm()
        //    {
        //        EventName = x.EventName,
        //    }).ToList();
        //    return vms;
        //}       
    }
}