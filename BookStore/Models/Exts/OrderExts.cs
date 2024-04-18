using BookStore202401.Models.Dtos;
using BookStore202401.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Exts
{
    public static class OrderExts
    {
        public static OrderIndexVm OrderIndexVm(this OrdersDto dto)
        {

            return new OrderIndexVm()
            {
                Id = dto.Id,
                MemberName = dto.MemberName,
                OrderDate = dto.OrderDate,
                PaymentMethod = dto.PaymentMethod,
                TotalAmount = dto.TotalAmount,
                Status = dto.Status,
                Message = dto.Message
            };
        }
        public static OrdersDto ToDto(this OrderIndexVm vm)
        {

            return new OrdersDto()
            {
                Id = vm.Id,
                MemberName = vm.MemberName,
                OrderDate = vm.OrderDate,
                PaymentMethod = vm.PaymentMethod,
                TotalAmount = vm.TotalAmount,
                Status = vm.Status,
                Message = vm.Message
            };
        }
    }
}