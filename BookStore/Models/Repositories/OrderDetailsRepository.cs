using BookStore.Models.EFModels;
using BookStore202401.Models.Dtos;
using BookStore202401.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace BookStore202401.Models.Repositories
{
    public class OrderDetailsRepository : IOrderDetailsRepo
    {
        private AppDbContext db = new AppDbContext();

        public OrderDetailsDto Get(int id)
        {
            var model = db.OrderDetails.FirstOrDefault(x => x.OrderId == id);
            if (model == null)
            {
                return null;
            }
            var dto = new OrderDetailsDto
            {
                OrderId = model.OrderId,
                ProductName = model.Product.Name,
                Quantity = model.Quantity,
                UnitPrice = model.UnitPrice,
            };
            return dto;
        }

        public List<OrderDetailsDto> Search(int OrderId)
        {
            return db.OrderDetails
               .Include(x => x.Product)
                .Where(x => x.OrderId == OrderId)
                                .Select(x => new OrderDetailsDto()
                                {
                                    OrderId = x.OrderId,
                                    ProductName = x.Product.Name,
                                    Quantity = x.Quantity,
                                    UnitPrice = x.UnitPrice,

                                }).ToList();
        }



    }
}