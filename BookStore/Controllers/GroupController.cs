using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using BookStore.Models.Repositories;
using BookStore.Models.Services;
using BookStore.Models.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class GroupController : Controller
    {
        private AppDbContext _context = new AppDbContext();
        private readonly GroupService _groupService = new GroupService (new GroupPermissionEFRepository(), new GroupFunctionEFRepository());


        public ActionResult Index()
        {
            var groupPermissions = _groupService.GetAllGroupPermissions();
            // ViewModel 的準備省略，根據實際需要進行轉換
            return View(groupPermissions);
        }

        public ActionResult Create()
        {
            var allFunctionsVm = _groupService.GetAllGroupFunctions()
                .Select(f => new GroupFunctionVm { Id = f.Id, Name = f.Name })
                .ToList();

            var viewModel = new GroupCreateVm
            {
                AllFunctions = allFunctionsVm,
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GroupCreateVm viewModel)
        {
            if (ModelState.IsValid)
            {
                _groupService.CreateGroupPermission(new GroupPermissionDto
                {
                    GroupName = viewModel.GroupName,
                    FunctionIds = viewModel.SelectedFunctions
                });
                return RedirectToAction("Index");
            }

            // 如果出現錯誤，重新準備 ViewModel
            viewModel.AllFunctions = _groupService.GetAllGroupFunctions()
                .Select(f => new GroupFunctionVm { Id = f.Id, Name = f.Name })
                .ToList();

            return View(viewModel);
        }

        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                // 处理错误，例如重定向到错误页面或返回到列表
                return RedirectToAction("Index");
            }

            var groupPermission = _groupService.GetGroupPermissionById(id.Value); // 使用 `id.Value` 访问值
            if (groupPermission == null)
            {
                return HttpNotFound();
            }

            var allFunctions = _groupService.GetAllGroupFunctions()
                                             .Select(f => new GroupFunctionVm { Id = f.Id, Name = f.Name })
                                             .ToList();
            var selectedFunctions = _groupService.GetSelectedFunctionsForGroup(id.Value).ToList(); // 注意这里的改动，确保使用id.Value

            var viewModel = new GroupEditVm
            {
                GroupId = id.Value, // 使用id.Value确保我们有一个非空的值
                CanChooseFunctions = allFunctions, // 这里假设所有功能都是可选的
                SelectedFunctions = selectedFunctions
            };

            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GroupEditVm viewModel)
        {
            if (ModelState.IsValid)
            {
                _groupService.UpdateGroupPermission(new GroupPermissionDto
                {
                    Id = viewModel.GroupId,
                    FunctionIds = viewModel.SelectedFunctions
                });

                // 更新成功后重定向到群组列表页
                return RedirectToAction("Index");
            }

            // 如果模型状态无效或更新过程中出现错误，重新准备视图模型以便用户可以修正并重新提交
            viewModel.CanChooseFunctions = _groupService.GetAllGroupFunctions()
                                                         .Select(f => new GroupFunctionVm { Id = f.Id, Name = f.Name })
                                                         .ToList();

            // 返回带有错误信息的视图模型给用户
            return View(viewModel);
        }
        public ActionResult EditGroupPermissions(int groupId)
        {
            var group = _groupService.GetGroupPermissionById(groupId); // 獲取群組資訊
            var allFunctions = _groupService.GetAllGroupFunctions(); // 獲取所有功能
            var selectedFunctions = _groupService.GetSelectedFunctionsForGroup(groupId); // 獲取群組選擇的功能

            var model = new GroupPermissionsVm
            {
                GroupId = groupId,
                GroupName = group.GroupName,
                AvailableFunctions = allFunctions.Select(f => new GroupFunctionVm { Id = f.Id, Name = f.Name }).ToList(),
                SelectedFunctions = selectedFunctions.ToList() // 直接使用 selectedFunctions，無需進行轉換
            };

            return View("EditGroupPermissions", model); // 確保指向正確的檢視名稱
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        // GET: Group/Delete/5
        public ActionResult Delete(int id)
        {
            var groupPermission = _groupService.GetGroupPermissionById(id);
            if (groupPermission == null)
            {
                return HttpNotFound();
            }

            // 如果找到了，就传递给视图进行确认
            return View(groupPermission);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            _groupService.DeleteGroupPermission(id); // 执行删除操作
            return RedirectToAction("Index"); // 重定向到列表页
        }



        // 如果找到了，就传递给视图进行确认

    }
}
