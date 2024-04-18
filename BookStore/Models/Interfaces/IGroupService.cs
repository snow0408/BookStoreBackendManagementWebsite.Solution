using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    public interface IGroupService
    {
        IEnumerable<GroupPermissionDto> GetAllGroupPermissions();
        GroupPermissionDto GetGroupPermissionById(int id);
        void CreateGroupPermission(GroupPermissionDto dto);
        void UpdateGroupPermission(GroupPermissionDto dto);
        IEnumerable<GroupFunctionDto> GetAllGroupFunctions();
        GroupPermissionDto GetGroupWithFunctionsById(int id);
        IEnumerable<int> GetSelectedFunctionsForGroup(int groupId);
    }
}

