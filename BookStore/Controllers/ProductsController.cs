using BookStore.Models.Dtos;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class ProductsController : Controller
    {
        private ProductService _service = new ProductService(new ProductEFRepository());
        private BooksService _bookService = new BooksService(new BooksEFRepository());
        private BookSellersService _bookSellerService = new BookSellersService(new BookSellersEFRepository());

        // GET: Products
        public ActionResult Index(ProductsFilterDto searchDto)
        {
            List<SelectListItem> pdCategoryList = _service.GetProductCategoryList();
            List<SelectListItem> pdStatusList = _service.GetProductStatusList();

            pdStatusList.Insert(0, new SelectListItem() { Text = "全部", Value = "", Selected = false });
            pdCategoryList.Insert(0, new SelectListItem() { Text = "全部", Value = "", Selected = false });

            //選項
            ViewBag.ProductStatusList = pdStatusList;
            ViewBag.ProductCategoryList = pdCategoryList;

            var vms = _service.Search(searchDto);

            //搜尋資料
            ViewBag.Name = searchDto.Name;
            if (searchDto.MinPrice != null) ViewBag.MinPrice = searchDto.MinPrice;
            if (searchDto.MaxPrice != null) ViewBag.MaxPrice = searchDto.MaxPrice;
            if (searchDto.Stock != null) ViewBag.Stock = searchDto.Stock;

            return View(vms);
        }
        //---------------新增---------------

        public ActionResult Create()
        {
            ViewBag.ProductStatusList = _service.GetProductStatusList();
            ViewBag.ProductCategoryList = _service.GetProductCategoryList();
            ViewBag.SelectBookId = 0;
            ViewBag.SelectPublisherId = 0;


            ViewBag.PublisherDate = DateTime.Now;

            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductCreateVm vm)
        {
            //下拉式清單填入
            ViewBag.ProductStatusList = _service.GetProductStatusList();
            ViewBag.ProductCategoryList = _service.GetProductCategoryList();

            //提交錯誤 資料回傳
            if (vm.BookProduct == null) ViewBag.PublisherDate = DateTime.Now;
            else
            {
                ViewBag.SelectBook = vm.BookProduct.BookName;
                ViewBag.SelectBookSeller = vm.BookProduct.PublisherName;
                ViewBag.ISBN = vm.BookProduct.ISBN;
                ViewBag.SelectBookId = vm.BookProduct.BookId;
                ViewBag.SelectPublisherId = vm.BookProduct.PublisherId;
                if (vm.BookProduct.PublishDate == null) ViewBag.PublisherDate = DateTime.Now;
                else ViewBag.PublisherDate = vm.BookProduct.PublishDate;
            }

            //欄位驗證
            var bookProduct = vm.BookProduct;
            if (vm.Category == "實體書" || vm.Category == "電子書")
            {
                ErrorIsVaild(bookProduct, ModelState);
            }
            if (!ModelState.IsValid) return View(vm);


            try
            {
                _service.Create(vm);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                if (ex.Message == "ISBN長度必須為13")
                {
                    ModelState.AddModelError("BookProduct.ISBN", ex.Message);
                }
                else ModelState.AddModelError("", ex.Message);
            }
            return View(vm);
        }

        //----------------更新-------------
        public ActionResult Edit(int id)
        {

            var vm = _service.Get(id);

            ViewBag.ProductStatusList = _service.GetProductStatusList();
            ViewBag.PublisherDate = DateTime.Now;

            #region 下拉式清單要可以更改的話需要的資訊
            //ViewBag.ProductCategoryList = _service.GetProductCategoryList();

            //vm.BookProduct.BookName = "[{\"value\":\"" + vm.BookProduct.BookName + "\"," + "\"id\":" + vm.BookProduct.BookId.ToString() + "}]";
            //vm.BookProduct.PublisherName = "[{\"value\":\"" + vm.BookProduct.PublisherName + "\"," + "\"id\":" + vm.BookProduct.PublisherId.ToString() + "}]";
            //ViewBag.SelectBookId = 0;
            //ViewBag.SelectPublisherId = 0;
            #endregion

            return View(vm);
        }
        [HttpPost]
        public ActionResult Edit(ProductEditVm vm)
        {
            ViewBag.ProductStatusList = _service.GetProductStatusList();

            if (!ModelState.IsValid) return View(vm);

            try
            {
                _service.Update(vm);
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

        public ActionResult Test()
        {
            return View();
        }

        //-----------------function----
        public void ErrorIsVaild(BookProductCreateVm bookProduct, ModelStateDictionary ModelState)
        {
            if (bookProduct.BookId == 0)
            {
                ModelState.AddModelError("BookProduct.BookId", "請選擇書籍");
            }
            if (bookProduct.PublisherId == 0)
            {
                ModelState.AddModelError("BookProduct.PublisherId", "請選擇出版商");
            }
            if (bookProduct.PublishDate == null)
            {
                ModelState.AddModelError("BookProduct.PublishDate", "請選擇出版日期");
            }
            if (string.IsNullOrEmpty(bookProduct.ISBN))
            {
                ModelState.AddModelError("BookProduct.ISBN", "請輸入ISBN");
            }
            else if (!bookProduct.ISBN.All(char.IsDigit))
            {
                ModelState.AddModelError("BookProduct.ISBN", "ISBN必須是數字");
            }
        }
    }
}
