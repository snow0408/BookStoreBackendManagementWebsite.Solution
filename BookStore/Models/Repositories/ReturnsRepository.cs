using BookStore.Models.EFModels;
using BookStore202401.Models.Dtos;
using BookStore202401.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Repositories
{
    public class ReturnsRepository : IReturnsRepo
    {
        private AppDbContext db= new AppDbContext();
        public ReturnsDto Get(int id)
        {
            var model = db.Returns.Where(x => x.Id == id).Select(x => new ReturnsDto()
            {
                Id = x.Id,
                OrderId = x.OrderId,
                MemberId = x.MemberId,
                LogisticsOrderId = x.LogisticsOrderId,
                Quantity = x.Quantity,
                ReturnReason = x.ReturnReason,
                Status = x.Status,
                ReturnDate = x.ReturnDate,
                ProcessdDate = x.ProcessdDate,
            }).FirstOrDefault();
            return model;
        }

        public List<ReturnsDto> Search(int OrderId)
        {
          
            var model = db.Returns.Where(x => x.OrderId == OrderId).Select(x => new ReturnsDto()
            {
                Id = x.Id,
                OrderId = x.OrderId,
                MemberId = x.MemberId,
                LogisticsOrderId = x.LogisticsOrderId,
                Quantity = x.Quantity,
                ReturnReason = x.ReturnReason,
                Status = x.Status,
                ReturnDate = x.ReturnDate,
                ProcessdDate = x.ProcessdDate,
            }).ToList();
            return model;
        }

       
    }
}