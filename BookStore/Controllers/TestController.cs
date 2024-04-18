using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            var db = new AppDbContext();
            var model = db.GroupPermissions.AsNoTracking()
                                           .Include(x => x.GroupFunctions)
                                           .Select(x => new TestDto
                                           {
                                               FuncName = x.GroupFunctions,
                                               PermName = x.GroupName
                                           });
            return View(model);
        }
    }
}