using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models.Repositories
{
    public class PdInStockEFRepository : IPdInStockRepository
    {
        public void Create(PdInStockDto dto)
        {
            using (var db = new AppDbContext())
            {

                PdInStock model = new PdInStock()
                {

                    ProductId = dto.ProductId,
                    Qty = dto.Qty,
                    BuyPrice = dto.BuyPrice,
                    BuyDate = dto.BuyDate,
                };
                var product = db.Products.Find(dto.ProductId);

                product.Stock = dto.Stock;
                db.PdInStocks.Add(model);

                db.SaveChanges();
            }

        }

        public void Delete(int ID)
        {
            var db = new AppDbContext();
            var model = db.PdInStocks.Find(ID);
            db.PdInStocks.Remove(model);
            db.SaveChanges();
        }



        public IEnumerable<PdInStockDto> GetAllPdInStocks()
        {
            var db = new AppDbContext();

            var models = db.PdInStocks
                .AsNoTracking()
                .Select(p => new PdInStockDto()
                {
                    ID = p.ID,
                    ProductId = p.ProductId,
                    ProductName = p.Product.Name,
                    CategoryName = p.Product.Category,
                    BooksellerName = p.Bookseller.Name,
                    Qty = p.Qty,
                    BuyPrice = p.BuyPrice,
                    BuyDate = p.BuyDate,
                    Stock = p.Product.Stock,

                });

            return models.ToList();
        }


        public PdInStockDto Get(int ID)
        {
            var db = new AppDbContext();
            var PdInStock = db.PdInStocks.Find(ID);

            return PdInStock?.ToPdInStockDto(); // 使用安全的 null 條件運算符
        }

        public List<PdInStockDto> Search(string ProductName)
        {
            var db = new AppDbContext();

            var model = db.PdInStocks
                            .AsNoTracking()
                            .Select(p => new PdInStockDto()
                            {
                                ID = p.ID,
                                ProductId = p.ProductId,
                                ProductName = p.Product.Name,
                                CategoryName = p.Product.Category,
                                BooksellerName = p.Bookseller.Name,
                                Qty = p.Qty,
                                BuyPrice = p.BuyPrice,
                                BuyDate = p.BuyDate,
                                Stock = p.Product.Stock,


                            });

            if (!string.IsNullOrEmpty(ProductName))
            {
                model = model.Where(p => p.ProductName.Contains(ProductName));
            }

            return model.ToList();
        }

        public PdInStockDto SearchFirstName(string ProductName)
        {
            var db = new AppDbContext();
            var PdInStock = db.PdInStocks.FirstOrDefault(p => p.Product.Name == ProductName);

            return PdInStock.ToPdInStockDto();
        }

        public void Update(PdInStockDto dto)
        {
            var db = new AppDbContext();

            var model = db.PdInStocks.Find(dto.ID);
            model.Qty = dto.Qty;
            model.BuyPrice = dto.BuyPrice;
             
            db.SaveChanges();
        }

        //public IEnumerable<PdInStockDto> GetPdInStocksByProductId(int id)
        //{
        //    var pdInStocks =p.GetPdInStocksByProductId(id);


        //    var pdInStockVms = pdInStocks.Select(p => p.ToPdInStockVm()).ToList();

        //    return pdInStockVms;
        //}

        public IEnumerable<PdInStockDto> GetPdInStocksByProductId(int productId)
        {
            using (var db = new AppDbContext())
            {
                var models = db.PdInStocks
                               .Where(p => p.ProductId == productId)
                               .AsNoTracking()
                               .Select(p => new PdInStockDto
                               {
                                   ID = p.ID,
                                   ProductId = p.ProductId,
                                   ProductName = p.Product.Name,
                                   CategoryName = p.Product.Category,                                   
                                   Qty = p.Qty,
                                   BuyPrice = p.BuyPrice,
                                   BuyDate = p.BuyDate,
                                   Stock = p.Product.Stock,
                               }).ToList();

                return models;
            }
        }
    }
}