using BookStore202401.Models.Dtos;
using BookStore202401.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Exts
{
    public static class RefundsExts
    {
        public static RefundsVm RefundsVm(this RefundsDto dto)
        {

            return new RefundsVm()
            {
                Id = dto.Id,
                OrderId = dto.OrderId,
                ApplicationDate = dto.ApplicationDate,
                Amount = dto.Amount,
                RefundStatus = dto.RefundStatus

            };
        }
    }
}