using BookStore.Models.Dtos;
using BookStore.Models.Interfaces;
using System.Collections.Generic;

namespace BookStore.Models.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupPermissionRepository _groupPermissionRepository;
        private readonly IGroupFunctionRepository _groupFunctionRepository;

        public GroupService(IGroupPermissionRepository groupPermissionRepository, IGroupFunctionRepository groupFunctionRepository)
        {
            _groupPermissionRepository = groupPermissionRepository;
            _groupFunctionRepository = groupFunctionRepository;
        }

        // 取得所有群組權限
        public IEnumerable<GroupPermissionDto> GetAllGroupPermissions()
        {
            return _groupPermissionRepository.GetAllPermissions();
        }

        // 通過ID取得特定群組權限，包括關聯的功能
        public GroupPermissionDto GetGroupPermissionById(int id)
        {
            // 確保此方法在存儲庫中實作時也拉取了關聯的功能
            return _groupPermissionRepository.GetPermissionById(id);
        }

        // 建立新的群組權限
        public void CreateGroupPermission(GroupPermissionDto dto)
        {
            _groupPermissionRepository.AddPermission(dto);
        }

        // 更新現有的群組權限及其功能關聯
        public void UpdateGroupPermission(GroupPermissionDto dto)
        {
            _groupPermissionRepository.UpdatePermission(dto);
        }

        // 取得所有群組功能
        public IEnumerable<GroupFunctionDto> GetAllGroupFunctions()
        {
            return _groupFunctionRepository.GetAllFunctions();
        }

        // 通過群組ID取得一個群組及其功能
        public GroupPermissionDto GetGroupWithFunctionsById(int groupId)
        {
            // 此方法需要在存儲庫中實作，以包括功能
            return _groupPermissionRepository.GetPermissionWithFunctionsById(groupId);
        }
        public IEnumerable<int> GetSelectedFunctionsForGroup(int groupId)
        {
            var groupWithFunctions = GetGroupWithFunctionsById(groupId);
            if (groupWithFunctions != null)
            {
                // 假設 GroupPermissionDto 有一個包含功能 ID 的屬性 FunctionIds
                return groupWithFunctions.FunctionIds;
            }
            return new List<int>(); // 如果找不到群組或沒有選擇的功能，返回空列表
        }
        public void DeleteGroupPermission(int id)
        {
            _groupPermissionRepository.DeletePermission(id);
        }
    }
}
