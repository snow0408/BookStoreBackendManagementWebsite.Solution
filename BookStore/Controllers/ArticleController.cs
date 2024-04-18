using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class ArticleController : Controller
    {
        private static IArticleRepository _repo = new ArticleEFRepository();
        private ArticleService _service = new ArticleService(_repo);
        private AppDbContext db = new AppDbContext();

        #region --- pages ---
        public ActionResult Details()
        {
            return View();
        }
        //public ActionResult Index()
        //{
        //    var vms = _service.Search();
        //    return View();
        //}

        public ActionResult Index(string searchString)
        {
            List<ArticleIndexVm> ArticleIndexVm = GetAll(searchString);
            return View(ArticleIndexVm);
        }

        public ActionResult Create()
        {
            ViewBag.Categories = _service.Categories();
            return View();
        }
        #endregion

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ArticleCreateVm model)
        {
            ViewBag.Categories = _service.Categories();
            if (!ModelState.IsValid) return View(model);
            CreateArticle(model);
            try
            {
                //_service.Create(vm.ToArticleDto());

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }

        private void CreateArticle(ArticleCreateVm model)
        {
            var repos = new ArticleEFRepository();
            var service = new ArticleService(repos);

            ArticleDto dto = new ArticleDto
            {
                //ArticleID = model.ArticleID,
                //EmployeeID = model.EmployeeID,
                Title = model.Title,
                //PublishTime = (DateTime)model.PublishTime,
                Content = model.Content,
                Category = model.Category,
                //Employee = model.Employee
            };
            service.CreateArticle(dto);

        }

        private void CreateArticles(ArticleVm model)
        {
            ArticleDto dto = new ArticleDto
            {
                Title = model.Title,
                PublishTime = model.PublishTime,
                Content = model.Content,
                Category = model.Category,
                Employee = model.Employee
            };
            _service.CreateArticle(dto);
            //db.SaveChanges();
        }

        private List<ArticleIndexVm> GetAll(string searchString)
        {
            var articles = db.Articles.AsNoTracking()
                .OrderBy(p => p.ArticleID)
                .Where(p => string.IsNullOrEmpty(searchString) ||
                p.Title.Contains(searchString))
                .Select(p => new ArticleIndexVm
                {
                    ArticleID = p.ArticleID,
                    Title = p.Title,
                    Category = p.Category,
                })
                .ToList();
            return articles;
        }

        public ActionResult Edit(int id)
        {
            ViewBag.Categories = _service.Categories();
            ArticleCreateVm model = LoadArticle(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ArticleCreateVm model)
        {
            ViewBag.Categories = _service.Categories();
            if (!ModelState.IsValid) return View(model);
            try
            {
                //_service.Update(vm.ToArticleDto());
                UpdateArticle(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }

        public ActionResult ArticleList(string searchString)
        {
            List<ArticleIndexVm> data = GetAll(searchString);
            return View(data);
        }

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            try
            {
                //_service.Delete(id);
                DeleteArticle(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return RedirectToAction("Index");
        }

        private void DeleteArticle(int id)
        {
            //directly call EF or service object
            var db = new AppDbContext();
            var entity = db.Articles.Find(id);
            db.Articles.Remove(entity);
            db.SaveChanges();
        }

        private void UpdateArticle(ArticleCreateVm model)
        {
            //directly call EF or service object
            var db = new AppDbContext();
            var entity = db.Articles.Find(model.ArticleID);
            if(entity != null)
            {

            entity.EmployeeID = model.EmployeeID;
            entity.Title = model.Title;
            entity.PublishTime = model.PublishTime;
            entity.Content = model.Content;
            entity.Category = model.Category;
            db.SaveChanges();
            }
            else
            {
                throw new InvalidOperationException("找不到該文章。");
            }
        }

        //get single article
        private ArticleCreateVm LoadArticle(int id)
        {
            var model = new AppDbContext().Articles.Find(id);
            return new ArticleCreateVm
            {
                ArticleID = model.ArticleID,
                Title = model.Title,
                Content = model.Content,
                Category = model.Category,
            };
        }
    }
}
