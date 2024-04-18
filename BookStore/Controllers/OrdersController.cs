using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStore202401.Models.Infra;
using BookStore202401.Models.ViewModels;
using BookStore202401.Models.Repoositories;
using System.Data.Entity;
using System.Net;
using BookStore202401.Models.Interfaces;
using BookStore202401.Models.Service;
using BookStore202401.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore202401.Models.Repositories;
using Microsoft.Ajax.Utilities;
using System.Security.Policy;
using BookStore202401.Models.Exts;

namespace BookStore202401.Controllers
{
    public class OrdersController : Controller
    {
        private static IOrderRepo _repos = new OrderRepository();
        private OrderService _service = new OrderService(_repos);
        private OrderDetailsService services = new OrderDetailsService(new OrderDetailsRepository());


        public ActionResult Index(string memberName, string status, DateTime? startDate, DateTime? endDate)
        {
            ViewBag.statusSelectList = services.StatusSelectList();

            if (startDate.HasValue && endDate.HasValue)
            {
                // 在這裡將 startDate 和 endDate 加入到條件中
                List<OrderIndexVm> searchResults = _service.Search(memberName, status)
                                                      .Where(order => order.OrderDate >= startDate.Value && order.OrderDate <= endDate.Value)
                                                      .ToList();

                return View(searchResults);
            }
            else
            {
                // 如果沒有提供日期條件，則直接返回所有訂單
                List<OrderIndexVm> allOrders = _service.Search(memberName, status).ToList();
                return View(allOrders);
            }
        }


        public ActionResult Details(int id)
        {
            OrderDetailsService service = new OrderDetailsService(new OrderDetailsRepository());

            var order = service.Search(id);


            LogisticsOrdersService services = new LogisticsOrdersService(new LogisticsOrdersRepository());
            var LogisticsOrder = services.Get(id);


            OrderService orderService = new OrderService(new OrderRepository());
            var order2 = orderService.Get(id);

			if(LogisticsOrder ==null)
            {
				ViewBag.IsExitisLogistic = false;

                LogisticsOrder = new LogisticsOrdersDto
                {
					Id = 0,
                    OrderId = id,
                    TrackingNumber = "",
                    EstimatedDeliveryDate = DateTime.Now,
                    ActualDeliveryDate = DateTime.Now,
                    RecipientName = "",
                    RecipientPhone = "",
                    RecipientAddress = ""
				
				};
			}
			else
            {				
				ViewBag.IsExitisLogistic = true;
			}


			ViewBag.LogisticsOrder = LogisticsOrder;
			ViewBag.Order = order2;
            ViewBag.MemberName = order2.MemberName;


            return View(order);

        }



        [HttpPost]
        public ActionResult Details(OrderIndexVm vm)
        {
            //存到資料庫

            var order = _service.Get(vm.Id).OrderIndexVm();
            order.Message = vm.Message;


            _service.Update(order.ToDto());

            return RedirectToAction("Index");

        }
        public ActionResult Edit(int id)
        {
            ViewBag.statusSelectList = services.GetStatusSelectList();
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var order = _service.Get(id);

            if (order == null)
            {

                return HttpNotFound();
            }

            var OrderIndexVm = new OrderIndexVm
            {
                Id = order.Id,
                MemberName = order.MemberName,
                OrderDate = order.OrderDate,
                PaymentMethod = order.PaymentMethod,
                TotalAmount = order.TotalAmount,
                Status = order.Status

            };

            return View(OrderIndexVm);
        }

        [HttpPost]
        public ActionResult Edit(OrderIndexVm model)
        {
            ViewBag.statusSelectList = services.GetStatusSelectList();
            if (ModelState.IsValid)
            {
                try
                {
                    var order = _service.Get(model.Id);
                    order.Status = model.Status;


                    _service.Update(order);

                    return RedirectToAction("Index");
                }
                catch
                {

                    return View("Error");
                }
            }
            return View(model);
        }


    }
}