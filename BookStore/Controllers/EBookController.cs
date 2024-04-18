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
    public class EBookController : Controller
    {
        private static IEBookRepo _repo=new EBookRepository();
        private EBookService _service = new EBookService(_repo);

        public ActionResult Index(string  bookName)
        {
            var vms = _service.Search(bookName)
                               .ToList();
            return View(vms);
        }
       
        //新增
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(EBookVm vm)
        {
           if(!ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                _service.Create(vm.ToDto());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
              
            }
           return View(vm);
        }

        //修改
        public ActionResult Edit(int id)
        {
            var dto = _service.Get(id);
                var vm = new EBookVm() { 
                    Id = dto.Id,
                    BookId = dto.BookId,
                    FileLink = dto.FileLink,
                    Sample = dto.Sample
                };


            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(EBookVm vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }
            try
            {
                _service.Update(vm.ToDto());
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(vm);
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
    }
}