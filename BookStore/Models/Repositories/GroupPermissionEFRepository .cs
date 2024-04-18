using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models.Repositories
{
    public class GroupPermissionEFRepository : IGroupPermissionRepository
    {
        private readonly AppDbContext _context = new AppDbContext();

        public IEnumerable<GroupPermissionDto> GetAllPermissions()
        {
            return _context.GroupPermissions
                .Select(p => new GroupPermissionDto { Id = p.Id, GroupName = p.GroupName })
                .ToList();
        }

        public GroupPermissionDto GetPermissionById(int id)
        {
            var permission = _context.GroupPermissions.Find(id);
            if (permission == null) return null;

            return new GroupPermissionDto
            {
                Id = permission.Id,
                GroupName = permission.GroupName
            };
        }

        public void AddPermission(GroupPermissionDto permission)
        {
            var entity = new GroupPermission
            {
                GroupName = permission.GroupName
            };
            _context.GroupPermissions.Add(entity);
            _context.SaveChanges();
            permission.Id = entity.Id; // Update DTO with new ID
        }

        public void UpdatePermission(GroupPermissionDto permission)
        {
            var entity = _context.GroupPermissions.Include(x=>x.GroupFunctions).FirstOrDefault(x=>x.Id == permission.Id);
            if (entity == null) return;

            entity.GroupFunctions.Clear();

            if(permission.FunctionIds != null) 
            { 
                foreach (var funcId in permission.FunctionIds)
                {
                    var funcEntity = _context.GroupFunctions.Find(funcId);
                    entity.GroupFunctions.Add(funcEntity);
                }
            }
            _context.SaveChanges();
        }

        public void DeletePermission(int id)
        {
            var permission = _context.GroupPermissions.Find(id);
            if (permission == null) return;

            _context.GroupPermissions.Remove(permission);
            _context.SaveChanges();
        }
        public GroupPermissionDto GetPermissionWithFunctionsById(int id)
        {
            // 假設 _context 是您的 DbContext
            var permission = _context.GroupPermissions
                .Where(p => p.Id == id)
                .Select(p => new GroupPermissionDto
                {
                    Id = p.Id,
                    GroupName = p.GroupName,
                    FunctionIds = p.GroupFunctions.Select(f => f.Id).ToList() // 假設每個 GroupPermission 有一個 GroupFunctions 集合
                })
                .FirstOrDefault();

            return permission;
        }
    }

}