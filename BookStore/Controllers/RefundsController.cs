using Antlr.Runtime.Tree;
using BookStore202401.Models.Interfaces;
using BookStore202401.Models.Repositories;
using BookStore202401.Models.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;

namespace BookStore.Controllers
{
    public class RefundsController : Controller
    {
        
        public ActionResult Refunds(int id)
        {
            RefundsService service=new RefundsService(new RefundsRepository());

            var Refunds = service.Get(id);
            
                      return View(Refunds);
                     
        }
        public ActionResult Returns(int id)
        {
            ReturnsService services = new ReturnsService(new ReturnsRepository());

            var Returns = services.Get(id);
            return View(Returns);
        }
    }
}