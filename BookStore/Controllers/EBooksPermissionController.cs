using BookStore.Models.EFModels;
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
    public class EBooksPermissionController : Controller
    {
        private static IEBooksPermissionRepostory _repos = new EBooksPermissionEFRepository();
        private EBooksPermissionService _service = new EBooksPermissionService(_repos);

        // GET: EBooksPermission
        public ActionResult Index(string bookName, string member)
        {
            var vms = _service.Search(bookName, member);
            return View(vms);
        }

        //刪除
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("Index");
        }

        //新增
        public ActionResult Create()
        {
            ViewBag.PermissionTypeList = _service.PermissionTypeList();

            return View();
        }
        [HttpPost]
        public ActionResult Create(EBooksPermissionVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                _service.Create(vm.ToEBooksPermissionDto());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(vm);
        }

        public ActionResult SearchEBook(string keyword)
        {
            var ebook = _service.SearchEBook(keyword).Take(5);
            return Json(ebook, JsonRequestBehavior.AllowGet);
        }

        public ActionResult SearchMember(string name)
        {
            var db = new AppDbContext();
            var members = db.Members.Where(m => m.Name.Contains(name))
               .Select(s => new { Name = s.Name, Id = s.Id }).Take(5);
            return Json(members, JsonRequestBehavior.AllowGet);
        }
    }
}