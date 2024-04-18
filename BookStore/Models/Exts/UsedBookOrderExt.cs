using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Exts
{
	public static class UsedBookOrderExt
	{
		public static UsedBookOrderVm ToUsedBookOrderVm(this UsedBookOrderDto dto)
		{
			return new UsedBookOrderVm
			{
				Id = (int)dto.Id,
				BuyerName = dto.BuyerName,
				SellerName = dto.SellerName,
				OrderDate = dto.OrderDate,
				Status = dto.Status,
				TotalAmount = dto.TotalAmount,
				ShippingFee = dto.ShippingFee,
				PaymentMethod = dto.PaymentMethod
			};
		}

		public static UsedBookOrderDto ToUsedBookOrderDto(this UsedBooksOrder entity)
		{
			var dto = new UsedBookOrderDto();
			if (entity != null)
			{
				dto.Id = entity.Id;
				dto.SellerId = entity.SellerId;
				dto.BuyerId = entity.BuyerId;
				dto.OrderDate = entity.OrderDate;
				dto.Status = entity.Status;
				dto.TotalAmount = entity.TotalAmount;
				dto.ShippingFee = entity.ShippingFee;
				dto.PaymentMethod = entity.PaymentMethod;
			}
			return dto;
		}

		public static UsedBookOrderDto ToUsedBookOrderDto(this UsedBookOrderVm vm)
		{
			return new UsedBookOrderDto
			{
				Id = vm.Id,
				Status = vm.Status
			};
		}
	}
}