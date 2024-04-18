using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
	public class UsedBookOrderController : Controller
	{
		private static IUsedBookOrderRepository _repos = new UsedBookOrderEFRepository();
		private UsedBookOrderService _service = new UsedBookOrderService(_repos);
		// GET: UsedBookOrder
		public ActionResult Index(string status, string member, DateTime? startDate, DateTime? endDate)
		{
			ViewBag.statusList = _service.OrderStatusSelect();
			var vms = _service.Search(status, member);

			if (startDate != null || endDate != null) 
			{
				vms=_service.DateSearch(vms, startDate, endDate);
			}

			return View(vms);
		}

		public ActionResult OrderDetail(int id)
		{
			var orderDetail = _service.SearchDetail(id);

			var order = _service.Get(id);
			ViewBag.Order = order;

			var logistics = _service.SearchLogisticsOrder(id);
			ViewBag.Logistics = logistics;

			ViewBag.statusList = _service.OrderStatus();

			return View(orderDetail);
		}

		public ActionResult SearchUsedBooksLogistics(int id)
		{
			var logistics = _service.SearchLogisticsOrder(id);
			//return Json(logistics, JsonRequestBehavior.AllowGet);
			return View(logistics);
		}

		public ActionResult UpdateStatus(int id, string status)
		{
			_service.UpdateStatus(id, status);
			return Json(new { message = "已更新" }, JsonRequestBehavior.AllowGet);
		}
	}
}