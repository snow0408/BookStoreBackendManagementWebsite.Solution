using BookStore.Models.EFModels;
using BookStore202401.Models.Dtos;
using BookStore202401.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Repositories
{
    public class LogisticsOrdersRepository : ILogisticsOrdersRepo
    {
        private AppDbContext db= new AppDbContext();
        public LogisticsOrdersDto Get(int id)
        {
           var model = db.LogisticsOrders.FirstOrDefault(x => x.OrderId == id);
            if (model == null)
            {
                return null;
            }
            var dto = new LogisticsOrdersDto
            {
                OrderId = model.OrderId,
                TrackingNumber = model.TrackingNumber,
                EstimatedDeliveryDate = model.EstimatedDeliveryDate,
                ActualDeliveryDate = model.ActualDeliveryDate,
                RecipientName = model.RecipientName,
                RecipientPhone = model.RecipientPhone,
                RecipientAddress = model.RecipientAddress
            };
            return dto;
        }

        public List<LogisticsOrdersDto> Search(int id)
        {
         var query = db.LogisticsOrders
                .Select(x => new LogisticsOrdersDto()
                {
                    OrderId = x.OrderId,
                    TrackingNumber = x.TrackingNumber,
                    EstimatedDeliveryDate = x.EstimatedDeliveryDate,
                    ActualDeliveryDate = x.ActualDeliveryDate,
                    RecipientName = x.RecipientName,
                    RecipientPhone = x.RecipientPhone,
                    RecipientAddress = x.RecipientAddress

                }).ToList();
           
            return query;
        }

       
    }
}