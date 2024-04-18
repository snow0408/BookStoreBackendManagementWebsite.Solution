using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService = new EmployeeService(new EmployeeEFRepository());
        private readonly GroupService _groupService = new GroupService(new GroupPermissionEFRepository(), new GroupFunctionEFRepository());

        // GET: Enployees
        public ActionResult Index(string search)
        {
            var employees = _employeeService.GetAllEmployees();

            if (!String.IsNullOrEmpty(search))
            {
                employees = employees.Where(e => e.Name.Contains(search)).ToList();
            }

            return View(employees);
        }



        // GET: Enployees/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Enployees/Create
        private readonly EmployeeEFRepository _employeeRepository;

        public EmployeeController()
        {
            _employeeRepository = new EmployeeEFRepository();
        }

        public ActionResult Create()
        {
            var groupPermissions = _groupService.GetAllGroupPermissions()
        .Select(gp => new SelectListItem
        {
            Value = gp.Id.ToString(),
            Text = gp.GroupName
        }).ToList();

            ViewBag.GroupOptions = new SelectList(groupPermissions, "Value", "Text");

            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        [ValidateAntiForgeryToken] // 防止跨站請求偽造
        public ActionResult Create(EmployeeVm model)
        {
            if(!ModelState.IsValid) return View(model);
            try
            {
                _employeeRepository.CreateFromVm(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "發生錯誤: " + ex.Message);
            }

            return View(model); 
        }



        public ActionResult Edit(int id)
        {
            var employeeDto = _employeeRepository.GetById(id);
            if (employeeDto == null)
            {
                return HttpNotFound();
            }
            var groupPermissions = _groupService.GetAllGroupPermissions()
                        .Select(gp => new SelectListItem
                        {
                            Value = gp.Id.ToString(),
                            Text = gp.GroupName 
                        })
                        .ToList();

            ViewBag.GroupOptions = new SelectList(groupPermissions, "Value", "Text", employeeDto.GroupId);
           


                       var model = new EmployeeVm
            {
                Id = employeeDto.Id,
                Name = employeeDto.Name,
                Gender = employeeDto.Gender,
                Address = employeeDto.Address,
                Email = employeeDto.Email,
                PhoneNumber = employeeDto.PhoneNumber,
                GroupId = employeeDto.GroupId,
                Account = employeeDto.Account,
                Password = employeeDto.Password
            };

            return View(model);
        }

        // POST: Employee/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeVm model)
        {
            if (ModelState.IsValid)
            {
                _employeeRepository.UpdateFromVm(model);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Enployees/Delete/5

        public ActionResult Delete(int id)
        {
            _employeeRepository.Delete(id);
            return RedirectToAction("Index");
        }

        // POST: Enployees/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var employee = _employeeRepository.GetById(id); // 假設有 GetById 方法
            if (employee == null)
            {
                return HttpNotFound();
            }

            var model = new EmployeeVm() // 或您的相應 ViewModel
            {
                // 將 employee 的資料映射到 ViewModel
                // 例如: Id = employee.Id, Name = employee.Name, ...
            };

            return View(model);
        }
        public ActionResult Search(int id)
        {
            return View();
        }

    }

}
