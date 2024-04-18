using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class WeHomeController : Controller
    {
        // GET: WeHome
        public ActionResult Index()
        {
            return View();
        }
    }
}