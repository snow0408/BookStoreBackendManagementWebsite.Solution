using BookStore202401.Models.Dtos;
using BookStore202401.Models.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Exts
{
    public static class ReturnsExts
    {
        public static ReturnsVm ReturnsVm(this ReturnsDto dto)
        {

            return new ReturnsVm()
            {
                Id = dto.Id,
                OrderId = dto.OrderId,
                MemberId = dto.MemberId,
                LogisticsOrderId = dto.LogisticsOrderId,
                Quantity = dto.Quantity,
                ReturnReason = dto.ReturnReason,
                Status = dto.Status,
                ReturnDate = dto.ReturnDate,
                ProcessdDate = dto.ProcessdDate,
            };
               
        }
    }
}