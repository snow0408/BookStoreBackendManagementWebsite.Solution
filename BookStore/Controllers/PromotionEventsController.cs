using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;

using System.Net;
using System.Web;
using System.Web.Mvc;
using BookStore.Models;
using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using BookStore.Models.ViewModels;



namespace BookStore.Controllers
{

    public class PromotionEventsController : Controller
    {
        private AppDbContext db = new AppDbContext();
        private static IPromotionEventRepository _repos = new PromotionEventEFRepository();
        private PromotionEventService _service = new PromotionEventService(_repos);

        // GET: PromotionEvents

        public ActionResult Index(string name)
        {
            var vms = _service.Search(name);
                               //.ToList();
            ViewBag.EventTypeList = _service.EventTypeList();
            ViewBag.DiscountTypeList = _service.DiscountTypeList();
            ViewBag.OfferStatusList = _service.OfferStatusList();
            return View(vms);
        }

        // GET: PromotionEvents/Details/5

        public ActionResult Details(int? id)

        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PromotionEvent promotionEvent = db.PromotionEvents.Find(id);

            if (promotionEvent == null)
            {
                return HttpNotFound();
            }
            return View(promotionEvent);
        }

        // GET: PromotionEvents/Create
        public ActionResult Create()
        {
            ViewBag.EventTypeList = _service.EventTypeList();
            ViewBag.DiscountTypeList = _service.DiscountTypeList();
            ViewBag.OfferStatusList = _service.OfferStatusList();
            return View();
        }

        // POST: PromotionEvents/Create

        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。

        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "EventID,EventName,EventSerialNumber,EventDescription,DiscountType,EventType,DiscountRate,OfferStatus,StartDate,EndDate,EventDetails,EventFile")] PromotionEvent promotionEvent)

        {
            if (ModelState.IsValid)
            {
                db.PromotionEvents.Add(promotionEvent);

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(promotionEvent);
        }

        // GET: PromotionEvents/Edit/5

        public ActionResult Edit(int id)
        {
            ViewBag.EventTypeList = _service.EventTypeList();
            ViewBag.DiscountTypeList = _service.DiscountTypeList();
            ViewBag.OfferStatusList = _service.OfferStatusList();
            PromotionEventCreateVm model = LoadPromotionEvent(id);
            return View(model);
        }
       

        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(PromotionEventCreateVm model)

        {
            ViewBag.EventTypeList = _service.EventTypeList();
            ViewBag.DiscountTypeList = _service.DiscountTypeList();
            ViewBag.OfferStatusList = _service.OfferStatusList();
            if (!ModelState.IsValid) return View(model);
            try
            {
                UpdatePromotionEvent(model);
                return RedirectToAction("Index");
            }catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
                return View(model);

        }

        private void UpdatePromotionEvent(PromotionEventCreateVm model)
        {
            var db = new AppDbContext();
            var entity = db.PromotionEvents.Find(model.EventID);
            if (entity != null)
            {
                entity.EventID = model.EventID;
                entity.EventName = model.EventName;
                entity.EventSerialNumber = model.EventSerialNumber;
                entity.EventDescription = model.EventDescription;
                entity.DiscountType = model.DiscountType;
                entity.EventType = model.EventType;
                entity.DiscountRate = model.DiscountRate;
                entity.OfferStatus = model.OfferStatus;
                entity.StartDate = model.StartDate;
                entity.EndDate = model.EndDate;
                entity.EventDetails = model.EventDetails;
                entity.EventFile = model.EventFile;

                db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("找不到該活動。");
            }
        }

        // GET: PromotionEvents/Delete/5

        //public ActionResult Delete(int? id)

        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }

        //    PromotionEvent model = db.PromotionEvents.Find(id);

        //    if (model == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(model);
        //}

        // POST: PromotionEvents/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]

        public ActionResult Delete(int id) //Confirmed

        {
            PromotionEvent promotionEvent = db.PromotionEvents.Find(id);

            db.PromotionEvents.Remove(promotionEvent);

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        private PromotionEventCreateVm LoadPromotionEvent(int id)
        {
            var model = new AppDbContext().PromotionEvents.Find(id);
            return new PromotionEventCreateVm
            {
                EventID = model.EventID,
                EventName = model.EventName,
                EventSerialNumber = model.EventSerialNumber,
                EventDescription = model.EventDescription,
                DiscountType = model.DiscountType,
                EventType = model.EventType,
                DiscountRate = model.DiscountRate,
                OfferStatus = model.OfferStatus,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                EventDetails = model.EventDetails,
                EventFile = model.EventFile

            };
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
