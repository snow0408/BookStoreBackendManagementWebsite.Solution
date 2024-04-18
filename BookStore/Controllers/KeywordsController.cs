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
    public class KeywordsController : Controller
    {
     
        private static IKeywordRepository _repo = new KeywordEFRepository();
        private KeywordService _service = new KeywordService(_repo);
        // GET: Keywords
        public ActionResult Index(string name)
        {
            var vms = _service.Search(name);

            return View(vms);
        }
        //---------------新增---------------

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(KeywordVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                _service.Create(vm.ToKeywordDto());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(vm);
        }

        //----------------更新-------------
        public ActionResult Edit(int id)
        {
            var vm = _service.Get(id);
            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(KeywordVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                _service.Update(vm.ToKeywordDto());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(vm);
        }
        //-----------------刪除--------------
        [HttpPost]
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
    }
}