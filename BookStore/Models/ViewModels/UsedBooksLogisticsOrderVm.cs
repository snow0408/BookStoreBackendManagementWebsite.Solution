using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models.ViewModels
{
	public class UsedBooksLogisticsOrderVm
	{
		[Display(Name = "貨運公司")]
		public string LogisticsCompany { get; set; }

		[Display(Name = "物流單號")]
		public string TrackingNumber { get; set; }

		[Display(Name = "預計送達時間")]
		public DateTime EstimateDeliveryDate { get; set; }

		[Display(Name = "實際送達時間")]
		public DateTime? ActualDeliveryDate { get; set; }

		[Display(Name = "寄件人姓名")]
		public string SenderName { get; set; }

		[Display(Name = "寄件人電話")]
		public string SenderPhone { get; set; }
		
		[Display(Name = "寄件人地址")]
		public string SenderAddress { get; set; }

		[Display(Name = "收件人姓名")]
		public string RecipientName { get; set; }

		[Display(Name = "收件人電話")]
		public string RecipientPhone { get; set; }

		[Display(Name = "收件人地址")]
		public string RecipientAddress { get; set; }
	}
}