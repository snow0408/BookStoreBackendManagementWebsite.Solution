using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Services
{
    public class PdInStockService
    {
        //private IPdInStockRepository _repos;
        //private PdInStockEFRepository repo;

        //public PdInStockService(IPdInStockRepository repos) => _repos = repos;

        //public PdInStockService(PdInStockEFRepository repo)
        //{
        //    this.repo = repo;
        //}

        private IPdInStockRepository _repos;
        private IProductRepository _productRepos;

        public PdInStockService(IPdInStockRepository repos, IProductRepository productRepos)
        {
            _repos = repos;
            _productRepos = productRepos;
        }
        public void StockIn(int productId, int qty)//是增加庫存量
        {
            // 檢查產品是否存在
            var product = _productRepos.Get(productId);
            if (product == null)
            {
                throw new Exception("產品不存在。");
            }

            // 增加庫存數量
            product.Stock += qty;

            // 更新產品資訊
            _productRepos.Update(product);

            // 創建進貨記錄
            var pdInStock = new PdInStockDto
            {
                ProductId = productId,
                Qty = qty,
                BuyDate = DateTime.Now,
                // BuyPrice 需要您自行確定如何設置
                BuyPrice = product.Price // 假設進貨價格等於產品定價
            };

            // 儲存進貨記錄
            _repos.Create(pdInStock);
        }


        //是處理減少庫存量
        public void Scrap(int productId, int qty)
        {
            // 檢查產品是否存在
            var product = _productRepos.Get(productId);
            if (product == null)
            {
                throw new Exception("產品不存在。");
            }

            // 檢查庫存是否足夠
            if (product.Stock < qty)
            {
                throw new Exception("庫存不足，無法報廢指定數量的產品。");
            }

            // 減少庫存數量
            product.Stock -= qty;

            // 更新產品資訊
            _productRepos.Update(product);

            // 創建報廢記錄，這裡假設您有一個類似的方法來處理報廢
            var pdInStock = new PdInStockDto
            {
                ProductId = productId,
                Qty = -qty, // 報廢的數量用負數表示
                BuyDate = DateTime.Now,
                // BuyPrice 可以設為0，表示沒有購買成本
                BuyPrice = 0
            };

            // 儲存報廢記錄
            _repos.Create(pdInStock);
        }

        public void CreatePdInStocks(PdInStockDto dto)
        {
            if (dto == null)
            {
                throw new ArgumentNullException(nameof(dto));
            }

            var product = _productRepos.Get(dto.ProductId);
            if (product == null)
            {
                throw new InvalidOperationException($"找不到 ProductId 為 {dto.ProductId} 的產品。");
            }

            // 可以在這裡進行其他檢查，比如庫存情況等

            // 創建進貨記錄
            _repos.Create(dto);
        }
        public List<PdInStockIndexVm> Search(string ProductName)
        {
            return _repos.Search(ProductName)
                         .Select(p => p.ToPdInStockIndexVm())
                         .OrderBy(p => p.ProductId)
                         .ToList();
        }


       
        private bool IsNameUnique(string ProductName, int? ID)
        {
            var existingPdInStocks = _repos.GetAllPdInStocks().ToList();
            return existingPdInStocks.Exists(seller => seller.ProductName.Equals(ProductName, StringComparison.OrdinalIgnoreCase) && (ID == null || seller.ID != ID));
        }

        public void DeletePdInStock(int ID)
        {
            _repos.Delete(ID);
        }


        public void Update(PdInStockDto dto)
        {

           
            _repos.Update(dto);
        }

        

        public PdInStockVm Get(int ID)
        {
            return _repos.Get(ID).ToPdInStockVm();
        }

        
        public List<PdInStockVm> GetPdInStocksByProductId(int productId)
        {
            
            var pdInStocks = _repos.GetPdInStocksByProductId(productId);

           
            var pdInStockVms = pdInStocks.Select(p => p.ToPdInStockVm()).ToList();

            return pdInStockVms;
        }

    }
}