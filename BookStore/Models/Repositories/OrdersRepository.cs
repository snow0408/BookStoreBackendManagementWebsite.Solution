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
    public class OrderRepository : IOrderRepo
    {
        //在這裡寫CRUD
        private AppDbContext db = new AppDbContext();

        public void Edit(OrdersDto dto)
        {
            var model = db.Orders.Find(dto.Id);
            model.Message = dto.Message;
            db.SaveChanges();
        }
        public int Create(OrdersDto dto)
        {
            var model = new Order
            {
                OrderDate = dto.OrderDate,
                PaymentMethod = dto.PaymentMethod,
                TotalAmount = dto.TotalAmount,
                Status = dto.Status,
                MemberId = dto.MemberId
            };

            db.Orders.Add(model);
            db.SaveChanges();
            return model.Id;
        }

        public void Delete(int id)
        {
            var orders = db.Orders.Find(id);
            db.Orders.Remove(orders);
            db.SaveChanges();
        }

        public OrdersDto Get(int id)
        {
            var orders = db.Orders.Include(x => x.Member)
                                .FirstOrDefault(x => x.Id == id);

            if (orders == null)
            {
                return null;
            }
            var OrderDto = new OrdersDto
            {
                Id = orders.Id,
                MemberId = orders.MemberId,
                MemberName = orders.Member.Name,
                PaymentMethod = orders.PaymentMethod,
                OrderDate = orders.OrderDate,
                TotalAmount = orders.TotalAmount,
                Status = orders.Status,
                Message = orders.Message
            };
            return OrderDto;
        }

        public List<OrdersDto> Search(string memberName, string status)
        {

            var orders = db.Orders.Include(x => x.Member);
            if (!string.IsNullOrEmpty(status))
            {
                orders = orders.Where(x => x.Status.Contains(status));
            }
            if (!string.IsNullOrEmpty(memberName))
            {
                orders = orders.Where(x => x.Member.Name.Contains(memberName));
            }
            var order = orders.Select(x => new OrdersDto
            {
                Id = x.Id,
                OrderDate = x.OrderDate,
                MemberName = x.Member.Name,
                PaymentMethod = x.PaymentMethod,
                TotalAmount = x.TotalAmount,
                Status = x.Status,
                MemberId = x.MemberId,
                DiscountAmount = x.DiscountAmount ?? 0,
            }).ToList();
            return order;
        }
        public List<OrdersDto> SearchByDate(DateTime startDate, DateTime endDate)
        {
            var orders = db.Orders
                .Where(x => x.OrderDate >= startDate && x.OrderDate <= endDate)
                .Select(x => new OrdersDto
                {
                    Id = x.Id,
                    OrderDate = x.OrderDate,
                    MemberName = x.Member.Name,
                    PaymentMethod = x.PaymentMethod,
                    TotalAmount = x.TotalAmount,
                    Status = x.Status,
                    MemberId = x.MemberId,
                    DiscountAmount = x.DiscountAmount ?? 0,
                }).ToList();
            return orders;
        }


        public void Update(OrdersDto dto)
        {
            var orders = db.Orders.Find(dto.Id);


            orders.OrderDate = dto.OrderDate;
            orders.Status = dto.Status;
            orders.TotalAmount = dto.TotalAmount;
            orders.Message = dto.Message;

            db.SaveChanges();
        }

    
    }
}








