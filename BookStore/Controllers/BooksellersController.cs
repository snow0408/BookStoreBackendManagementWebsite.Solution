using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using System.Data.Entity;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using System.Net;
using BookStore.Models.Dtos;
using System.Data.OleDb;
using System.Data;
using System.IO;
using PagedList;
using System.Web.UI;
using PagedList.Mvc;



namespace BookStore.Controllers
{
    public class BooksellersController : Controller
    {

        private static IBookSellersRepository _repo = new BookSellersEFRepository();
        private BookSellersService _service = new BookSellersService(_repo);
        private AppDbContext db = new AppDbContext();

        // GET: Bookseller

        public ActionResult Index(string searchString, int? page)
        {
            int pageSize = 10; // 
            int pageNumber = (page ?? 1);


            var bookSellers = GetAll(searchString);


            var pagedBookSellers = bookSellers.ToPagedList(pageNumber, pageSize);

            ViewBag.SearchString = searchString;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_PartialView", pagedBookSellers);
            }

            return View(pagedBookSellers);
        }




        //新增
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(BookSellersVm model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                CreateBookSellers(model);
                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(model);
        }

        private void CreateBookSellers(BookSellersVm model)
        {
            BookSellersDto dto = new BookSellersDto
            {
                Name = model.Name,
                ContactPerson = model.ContactPerson,
                Phone = model.Phone,
                Address = model.Address,
                Compiled = model.Compiled,
                BankAccount = model.BankAccount
            };

            _service.CreateBookSeller(dto);
            db.SaveChanges(); // 這裡加入 SaveChanges 以寫入資料庫
        }


        private List<BookSellersIndexVm> GetAll(string searchString)
        {
            var bookSellers = db.Booksellers.AsNoTracking()
                .OrderBy(p => p.ID)
                .Where(p => string.IsNullOrEmpty(searchString) ||
                    p.Name.Contains(searchString) ||
                    p.ContactPerson.Contains(searchString))
                .Select(p => new BookSellersIndexVm
                {
                    ID = p.ID,
                    Name = p.Name,
                    ContactPerson = p.ContactPerson,
                    Phone = p.Phone,
                    Address = p.Address,
                    Compiled = p.Compiled
                })
                .ToList();
            return bookSellers;
        }





        //更新
        public ActionResult Edit(int ID)
        {
            BookSellersVm modle = LoadBookSeller(ID);
            return View(modle);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(BookSellersVm model)
        {
            if (!ModelState.IsValid) return View(model);

            try
            {
                // 呼叫更新方法
                UpdateBookSellers(model);

                // 重導向到索引頁面
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                // 若發生異常，將錯誤訊息加入ModelState
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            // 若有錯誤，返回編輯頁面
            return View(model);
        }


        public ActionResult Delete(int ID)
        {
            try
            {
                _service.Delete(ID);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return RedirectToAction("Index");
        }

     

        private void UpdateBookSellers(BookSellersVm model)
        {
            using (var dbContext = new AppDbContext())
            {
                //透過 ID 找到現有的書商資料
                var existingBookSeller = dbContext.Booksellers.Find(model.ID);

                // 檢查書商是否存在
                if (existingBookSeller != null)
                {
                    //更新現有書商資料的屬性
                    existingBookSeller.Name = model.Name;
                    existingBookSeller.ContactPerson = model.ContactPerson;
                    existingBookSeller.Phone = model.Phone;
                    existingBookSeller.Address = model.Address;
                    existingBookSeller.Compiled = model.Compiled;
                    existingBookSeller.BankAccount = model.BankAccount;

                    //儲存變更到資料庫
                    dbContext.SaveChanges();
                }
                else
                {
                    //若書商不存在，拋出異常
                    throw new InvalidOperationException("找不到資料庫中的書商資料。");
                }
            }
        }

        //取得db的一筆紀錄
        private BookSellersVm LoadBookSeller(int ID)
        {
            var model = new AppDbContext().Booksellers.Find(ID);
            return new BookSellersVm
            {
                ID = model.ID,
                Name = model.Name,
                ContactPerson = model.ContactPerson,
                Phone = model.Phone,
                Address = model.Address,
                Compiled = model.Compiled,
                BankAccount = model.BankAccount
            };
        }

        [HttpPost]
        public ActionResult ImportExcel(HttpPostedFile excelFile)
        {
            if (excelFile != null && excelFile.ContentLength > 0)
            {
                var uploadFolder = Server.MapPath("~/Uploads");
                if (!Directory.Exists(uploadFolder))
                {
                    Directory.CreateDirectory(uploadFolder);
                }

                var filePath = Path.Combine(uploadFolder, Path.GetFileName(excelFile.FileName));
                excelFile.SaveAs(filePath);


                string excelConnectionString = $@"Provider=Microsoft.ACE.OLEDB.12.0;Data Source={filePath};Extended Properties='Excel 12.0 Xml;HDR=YES;'";


                try
                {
                    using (OleDbConnection conn = new OleDbConnection(excelConnectionString))
                    {
                        conn.Open();
                        var cmd = new OleDbCommand("SELECT * FROM [Test$]", conn);
                        var adapter = new OleDbDataAdapter(cmd);
                        var dt = new DataTable();
                        adapter.Fill(dt);

                        foreach (DataRow row in dt.Rows)
                        {

                            var bookSeller = new Bookseller
                            {

                                Name = row["Name"].ToString(),
                                ContactPerson = row["ContactPerson"].ToString(),
                                Phone = row["Phone"].ToString(),
                                Address = row["Address"].ToString(),
                                Compiled = int.Parse(row["Compiled"].ToString())


                            };

                            db.Booksellers.Add(bookSeller);
                        }

                        db.SaveChanges();
                    }

                    // 删除上传的文件
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                    ViewBag.Error = "導入失敗: " + ex.Message;
                    return View("Index");
                }
            }


            ViewBag.Error = "請上傳有效的 Excel 文件。";
            return RedirectToAction("Index");
        }

    }
}