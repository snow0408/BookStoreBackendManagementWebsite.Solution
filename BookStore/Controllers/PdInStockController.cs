using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using static System.Data.Entity.Infrastructure.Design.Executor;
using BookStore.Models.Dtos;
using BookStore.Models.Services;
using BookStore.Models.Repositories;
using System.Web.Services.Description;
using BookStore.Models.Interfaces;
using BookStore.Models.Exts;
using System.Xml.Linq;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class PdInStockController : Controller
    {
        private ProductService _productService;
        private PdInStockService _pdInStockService;
        private IPdInStockRepository _repo;
        private IProductRepository _productRepo;

        public PdInStockController()
        {
            _repo = new PdInStockEFRepository();
            _productRepo = new ProductEFRepository();
            _productService = new ProductService(_productRepo);
            _pdInStockService = new PdInStockService(_repo, _productRepo);
        }

        // 顯示特定商品的詳細信息
        public ActionResult Details(int id)
        {
            var product = _productService.Get(id); // 獲得產品
            if (product == null)
            {
                return HttpNotFound();
            }

            //得到進貨紀錄
            var pdInStockRecords = _pdInStockService.GetPdInStocksByProductId(id)
                .Select(p => new PdInStockVm
                {
                    ID = p.ID,
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    CategoryName = p.CategoryName,
                    Qty = p.Qty,
                    BuyDate = p.BuyDate,
                    BuyPrice = p.BuyPrice,

                }).ToList();

            var viewModel = new ProductDetailsVm
            {
                ProductId = product.Id,
                Name = product.Name,
                Category = product.Category,

                Stock = product.Stock,
                Status = product.ProductStatus,
                Price = product.Price,
                PdInStockRecords = pdInStockRecords
            };


            return View(viewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StockIn(ProductDetailsVm model)
        {
            // 獲取相應的產品
            var product = _productRepo.Get(model.ProductId);
            if (product == null)
            {
                ModelState.AddModelError("", "找不到商品。");
                return RedirectToAction("Details", new { id = model.ProductId });
            }
            if (ModelState.IsValid)
            {


                try
                {
                    // 更新產品庫存
                    product.Stock += model.pdInStockVm.Qty;
                    //_productRepo.UpdateStock(product);

                    // 創建進貨紀錄
                    var pdInStockDto = new PdInStockDto
                    {
                        ProductId = model.ProductId,
                        Qty = model.pdInStockVm.Qty,
                        BuyDate = model.pdInStockVm.BuyDate,
                        BuyPrice = model.pdInStockVm.BuyPrice,
                        Stock = product.Stock
                    };

                    _repo.Create(pdInStockDto);

                    // 重定向到詳細信息視圖
                    return RedirectToAction("Details", new { id = model.ProductId });
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }

            // 如果有任何錯誤，重新顯示進貨表單
            return RedirectToAction("Details", new { id = model.ProductId });
        }




        // 處理報廢操作
        [HttpPost]
        public ActionResult Scrap(int productId, int qty)
        {
            _pdInStockService.Scrap(productId, qty); // 假設您有這個方法
            return RedirectToAction("Details", new { productId = productId });
        }

        public ActionResult GetPdInStockRecordsPartial(int productId)
        {
            var pdInStockRecords = _pdInStockService.GetPdInStocksByProductId(productId)
                .Select(p => new PdInStockVm
                {
                    ID = p.ID,
                    ProductId = p.ProductId,
                    ProductName = p.ProductName,
                    CategoryName = p.CategoryName,
                    Qty = p.Qty,
                    BuyDate = p.BuyDate,
                    BuyPrice = p.BuyPrice,
                }).ToList();

            // 顯示記錄列表
            return PartialView("_PdInStockRecordsPartial", pdInStockRecords);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PdInStockVm model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                var dto = new PdInStockDto
                {

                    ProductId = model.ProductId,
                    Qty = model.Qty,
                    BuyPrice = model.BuyPrice,
                    BuyDate = model.BuyDate,
                };

                _pdInStockService.CreatePdInStocks(dto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(model);
            }
        }



    }
}