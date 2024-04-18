using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using BookStore.Models.Exts;

namespace BookStore.Models.Repositories
{
	public class UsedBookOrderEFRepository : IUsedBookOrderRepository
	{
		//訂單搜尋
		public List<UsedBookOrderDto> Search(string status, string member)
		{
			var db = new AppDbContext();

			var models = db.UsedBooksOrders
						  .AsNoTracking()
						  .Include(b => b.Member)
						  .Include(s => s.Member1);

			if (!string.IsNullOrEmpty(status))
			{
				models = models.Where(x => x.Status.Contains(status));
			}
			if (!string.IsNullOrEmpty(member))
			{
				models = models.Where(x => x.Member.Name.Contains(member) || x.Member1.Name.Contains(member));
			}
			var model = models.Select(o => new UsedBookOrderDto()
			{
				Id = o.Id,
				BuyerId = o.BuyerId,
				BuyerName = o.Member.Name,
				SellerId = o.SellerId,
				SellerName = o.Member1.Name,
				Status = o.Status,
				OrderDate = o.OrderDate,
				TotalAmount = o.TotalAmount,
				ShippingFee = o.ShippingFee,
				PaymentMethod = o.PaymentMethod
			})
			.ToList();

			return model;
		}

		//單筆訂單資料
		public UsedBookOrderDto Get(int id)
		{
			var db = new AppDbContext();
			var order = db.UsedBooksOrders
						  .Include(b => b.Member)
						  .Include(s => s.Member1)
						  .Where(o => o.Id == id)
						  .Select(o => new UsedBookOrderDto()
						  {
							  Id = o.Id,
							  BuyerId = o.BuyerId,
							  BuyerName = o.Member.Name,
							  SellerId = o.SellerId,
							  SellerName = o.Member1.Name,
							  Status = o.Status,
							  OrderDate = o.OrderDate,
							  TotalAmount = o.TotalAmount,
							  ShippingFee = o.ShippingFee,
							  PaymentMethod = o.PaymentMethod
						  })
						  .FirstOrDefault();

			return order;
		}

		//訂單狀態更新
		public void UpdateStatus(int id, string status)
		{
			var db = new AppDbContext();
			var order = db.UsedBooksOrders.Find(id);

			order.Status = status;

			db.SaveChanges();
		}


		//訂單明細
		public List<UsedBookOrderDetailDto> SearchDetail(int id)
		{
			var db = new AppDbContext();

			var model = db.UsedBooksOrderDetails
						  .AsNoTracking()
						  .Where(o => o.OrderID == id)
						  .Include(b=>b.UsedBook)
						  .Select(o => new UsedBookOrderDetailDto()
						  {
							  Id = o.Id,
							  OrderID = o.OrderID,
							  BookID = o.BookID,
							  BookName=o.UsedBook.Name,
							  UnitPrice = o.UnitPrice
						  })
						  .ToList();
			return model;
		}

		//貨運資料
		public List<UsedBooksLogisticsOrderDto> SearchLogisticsOrder(int id)
		{
			var db = new AppDbContext();

			var model = db.UsedBooksLogisticsOrders
						  .AsNoTracking()
						  .Where(o => o.OrderID == id)
						  .Select(o => new UsedBooksLogisticsOrderDto()
						  {
							  LogisticsCompany = o.LogisticsCompany,
							  TrackingNumber = o.TrackingNumber,
							  EstimateDeliveryDate = o.EstimateDeliveryDate,
							  ActualDeliveryDate = o.ActualDeliveryDate,
							  SenderName = o.SenderName,
							  SenderPhone = o.SenderPhone,
							  SenderAddress = o.SenderAddress,
							  RecipientName = o.RecipientName,
							  RecipientPhone = o.RecipientPhone,
							  RecipientAddress = o.RecipientAddress
						  })
						  .ToList();
			return model;
		}
	}
}