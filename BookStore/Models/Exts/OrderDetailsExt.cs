using BookStore202401.Models.Dtos;
using BookStore202401.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Exts
{
    public static class OrderDetailsExt
    {
        public static OrderDetailsVm OrderDetailsVm(this OrderDetailsDto dto)
        {
            return new OrderDetailsVm()
            {
                OrderId = dto.OrderId,
                ProductName = dto.ProductName,
                Quantity = dto.Quantity,
                UnitPrice = dto.UnitPrice,
            };
        }   
    }
}