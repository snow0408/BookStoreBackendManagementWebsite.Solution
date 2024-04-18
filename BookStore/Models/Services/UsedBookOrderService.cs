using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Models.Services
{
    public class UsedBookOrderService
    {
        private IUsedBookOrderRepository _repo;
        public UsedBookOrderService(IUsedBookOrderRepository repo)
        {
            _repo = repo;
        }

        //訂單搜尋
        public List<UsedBookOrderVm> Search(string status, string member)
        {
            var dtos = _repo.Search(status, member);
            var vms = dtos.Select(x => new UsedBookOrderVm()
            {
                Id = x.Id,
                BuyerName = x.BuyerName,
                SellerName = x.SellerName,
                Status = x.Status,
                OrderDate = x.OrderDate,
                TotalAmount = x.TotalAmount,
                ShippingFee = x.ShippingFee,
                PaymentMethod = x.PaymentMethod
            }).ToList();

            return vms;
        }

        public List<UsedBookOrderVm> DateSearch(List<UsedBookOrderVm> vms, DateTime? startDate, DateTime? endDate)
        {
            if (startDate != null) 
            {
                vms = vms.Where(x => x.OrderDate > startDate).ToList();
            }
            if (endDate != null) 
            {
                vms=vms.Where(x=>x.OrderDate < endDate).ToList();
            }
            return vms;
        }

        //訂單狀態選項
        public List<SelectListItem> OrderStatus()
        {
            List<SelectListItem> statusList = new List<SelectListItem>();

            statusList.Add(new SelectListItem()
            {
                Text = "未付款",
                Value = "未付款",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "未出貨",
                Value = "未出貨",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "已出貨",
                Value = "已出貨",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "已送達",
                Value = "已送達",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "已完成",
                Value = "已完成",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "已取消",
                Value = "已取消",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "退貨處理中",
                Value = "退貨處理中",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "已退貨",
                Value = "已退貨",
                Selected = false
            });

            return statusList;
        }
        public List<SelectListItem> OrderStatusSelect()
        {

            var statusSelectList = OrderStatus();
            statusSelectList.Insert(0, new SelectListItem()
            {
                Text = "全部",
                Value = "",
                Selected = true
            });

            return statusSelectList;
        }

        //單筆訂單資料
        public UsedBookOrderVm Get(int id)
        {
            return _repo.Get(id).ToUsedBookOrderVm();
        }

        //更新狀態
        public void UpdateStatus(int id, string status)
        {
            _repo.UpdateStatus(id, status);
        }

        //訂單明細
        public List<UsedBookOrderDetailVm> SearchDetail(int id)
        {
            var dtos = _repo.SearchDetail(id);
            var vms = dtos.Select(x => new UsedBookOrderDetailVm()
            {
                Id = x.Id,
                OrderID = x.OrderID,
                BookID = x.BookID,
                BookName = x.BookName,
                UnitPrice = x.UnitPrice
            }).ToList();

            return vms;
        }

        //貨運資料
        public List<UsedBooksLogisticsOrderVm> SearchLogisticsOrder(int id)
        {
            var dtos = _repo.SearchLogisticsOrder(id);
            var vms = dtos.Select(x => new UsedBooksLogisticsOrderVm()
            {
                LogisticsCompany = x.LogisticsCompany,
                TrackingNumber = x.TrackingNumber,
                EstimateDeliveryDate = x.EstimateDeliveryDate,
                ActualDeliveryDate = x.ActualDeliveryDate,
                SenderName = x.SenderName,
                SenderPhone = x.SenderPhone,
                SenderAddress = x.SenderAddress,
                RecipientName = x.RecipientName,
                RecipientPhone = x.RecipientPhone,
                RecipientAddress = x.RecipientAddress
            }).ToList();

            return vms;
        }
    }
}