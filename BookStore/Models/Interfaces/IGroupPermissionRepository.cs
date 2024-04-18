using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    public interface IGroupPermissionRepository
    {
        IEnumerable<GroupPermissionDto> GetAllPermissions();
        GroupPermissionDto GetPermissionById(int id);
        GroupPermissionDto GetPermissionWithFunctionsById(int id);
        void AddPermission(GroupPermissionDto permission);
        void UpdatePermission(GroupPermissionDto permission);
        void DeletePermission(int id);
    }
}
