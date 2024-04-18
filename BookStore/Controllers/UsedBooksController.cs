using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using BookStore.Models.ViewModels;
using System;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class UsedBooksController : Controller
    {
        private static IUsedBookRepository _repos = new UsedBookRepository();
        private UsedBookService _service = new UsedBookService(_repos);
        // GET: UsedBooks
        public ActionResult Index(string email, string ISBN, string bookName)
        {
            var vms = _service.Search(email, ISBN, bookName);
            ViewBag.Email = email;
            ViewBag.ISBN = ISBN;
            ViewBag.BookName = bookName;

            return View(vms);
        }


        public ActionResult Edit(int id)
        {
            var vm = _service.Get(id);
            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(UsedBookIndexVm vm)
        {
            if (!ModelState.IsValid) return View(vm);

            try
            {
                _service.Edit(vm);
                Console.WriteLine("==");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                ModelState.AddModelError("", ex.Message);
            }
            return View(vm);
        }




    }
}