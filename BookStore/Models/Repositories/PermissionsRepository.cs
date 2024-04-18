using BookStore.Models.EFModels;
using BookStore202401.Models.Dtos;
using BookStore202401.Models.Infra;
using BookStore202401.Models.Interfaces;
using BookStore202401.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing.Printing;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace BookStore202401.Models.Repoositories
{
    public class PermissionRepository : IPermissionsRepo
    {
        //在這裡寫CRUD
        //private AppDbContext db = new AppDbContext();

        //public OrdersDto Get(int id)
        //{
        //    var orders = db.Orders.FirstOrDefault(x => x.Id == id);

        //    if (orders == null)
        //    {
        //        return null;
        //    }
        //    var OrderDto = new OrdersDto
        //    {
        //        Id = orders.Id,
        //        MemberId = orders.MemberId,
        //        PaymentMethodId = orders.PaymentMethodId,
        //        OrderDate = orders.OrderDate,
        //        TotalAmount = orders.TotalAmount,
        //        Status = orders.Status,
        //    };
        //    return OrderDto;
        //}

        //public List<OrdersDto> Search(int memberId)
        //{
        //    return db.Orders.Where(x => x.MemberId == memberId)
        //        .Select(x => new OrdersDto
        //        {
        //            Id = x.Id,
        //            OrderDate = x.OrderDate,
        //            PaymentMethodId = x.PaymentMethodId,
        //            TotalAmount = x.TotalAmount,
        //            Status = x.Status,
        //            MemberId = x.MemberId,
        //            DiscountAmount = x.DiscountAmount ?? 0,
        //        }).ToList();
        //}



        //public void Update(OrdersDto dto)
        //{
        //    var orders = db.Orders.Find(dto.Id);

        //    orders.Id = dto.Id;
        //    orders.OrderDate = dto.OrderDate;
        //    orders.Status = dto.Status;
        //    orders.TotalAmount = dto.TotalAmount;

        //    db.SaveChanges();
        //}
    }
}








