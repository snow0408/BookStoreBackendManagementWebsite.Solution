using BookStore202401.Models.Dtos;
using BookStore202401.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Exts
{
    public static class LogisticsOrdersExt
    {
        public static LogisticsOrdersVm LogisticsOrdersVm(this LogisticsOrdersDto dto)
        {
            return new LogisticsOrdersVm()
            {
                OrderId = dto.OrderId,
                TrackingNumber = dto.TrackingNumber,
                EstimatedDeliveryDate = dto.EstimatedDeliveryDate,
                ActualDeliveryDate = dto.ActualDeliveryDate,
                RecipientName = dto.RecipientName,
                RecipientPhone = dto.RecipientPhone,
                RecipientAddress = dto.RecipientAddress

            };
        }
    }
}