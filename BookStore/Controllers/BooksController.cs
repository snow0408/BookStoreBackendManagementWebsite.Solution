using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using BookStore.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        private static IBooksRepository _repos = new BooksEFRepository();
        private BooksService _service = new BooksService(_repos);
        // GET: Books
        public ActionResult Index(string name, string author)
        {
            var vms = _service.Search(name, author);

            ViewBag.Name = name;
            ViewBag.Author = author;

            return View(vms);
        }

        //---------------------新增----------
        public ActionResult Create()
        {
            ViewBag.CategoryId = 0;
            ViewBag.BookLanguageList = _service.GetBookLanguageSelectList();


            return View();
        }


        [HttpPost]
        public ActionResult Create(BooksCreateVm vm)
        {
            ViewBag.CategorySelect = vm.CategoryName;
            ViewBag.CategoryId = vm.CategoryID;
            ViewBag.BookLanguageList = _service.GetBookLanguageSelectList();

            ColumnValid(vm);

            if (!ModelState.IsValid)
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


        public ActionResult Edit(int id)
        {

            ViewBag.BookLanguageList = _service.GetBookLanguageSelectList();

            var vm = _service.Get(id);
            ViewBag.CategoryId = vm.CategoryID;
           
            vm.CategoryName = "[{\"value\":\"" + vm.CategoryName + "\"," + "\"id\":" + vm.CategoryID.ToString() + "}]";
            return View(vm);

        }

        [HttpPost]
        public ActionResult Edit(BooksEditVm vm)
        {
            ViewBag.CategorySelect = vm.CategoryName;
            ViewBag.CategoryId = vm.CategoryID;
            ViewBag.BookLanguageList = _service.GetBookLanguageSelectList();

            ColumnValid(vm);

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

       
        public ActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
            }
            catch
            {
                ModelState.AddModelError("", "無法刪除，此書籍還有產品資訊，請刪除後再繼續");
            }
            return RedirectToAction("Index");
        }


        //欄位驗證
        public void ColumnValid(IBookVm vm)
        {
            if (vm.CategoryID == 0)
            {
                ModelState.AddModelError("CategoryID", "請選擇書籍");
            }
        }
    }
}