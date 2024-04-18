using BookStore.Models.EFModels;
using BookStore202401.Models.Dtos;
using BookStore202401.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Repositories
{
    public class RefundsRepository : IRefundsRepo
    {
        private AppDbContext db= new AppDbContext();
        public RefundsDto Get(int id)
        {
           var model= db.Refunds.FirstOrDefault(x => x.Id == id);
            if (model == null)
            {
                return null;
            }
            var dto = new RefundsDto
            {
                Id = model.Id,
                OrderId = model.OrderId,
                ApplicationDate = model.ApplicationDate,
                Amount = model.Amount,
                RefundStatus = model.RefundStatus,
            };
            return dto;
        }

        public List<RefundsDto> Search(int OrderId)
        {
         var model = db.Refunds.Where(x => x.OrderId == OrderId).ToList();
            if (model == null)
            {
                return null;
            }
            var dto = model.Select(x => new RefundsDto
            {
                Id = x.Id,
                OrderId = x.OrderId,
                ApplicationDate = x.ApplicationDate,
                Amount = x.Amount,
                RefundStatus = x.RefundStatus,
            }).ToList();
            return dto;
        }

       
    }
}