using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Repositories
{
    public class GroupFunctionEFRepository : IGroupFunctionRepository
    {
        private readonly AppDbContext _context = new AppDbContext();


        public IEnumerable<GroupFunctionDto> GetAllFunctions()
        {
            return _context.GroupFunctions
                .Select(f => new GroupFunctionDto { Id = f.Id, Name = f.Name })
                .ToList();
        }

        public GroupFunctionDto GetFunctionById(int id)
        {
            var function = _context.GroupFunctions.Find(id);
            if (function == null) return null;

            return new GroupFunctionDto
            {
                Id = function.Id,
                Name = function.Name
            };
        }

        public void AddFunction(GroupFunctionDto function)
        {
            var entity = new GroupFunction
            {
                Name = function.Name
            };
            _context.GroupFunctions.Add(entity);
            _context.SaveChanges();
            function.Id = entity.Id; 
        }

        public void UpdateFunction(GroupFunctionDto function)
        {
            var entity = _context.GroupFunctions.Find(function.Id);
            if (entity == null) return;

            entity.Name = function.Name;
            _context.SaveChanges();
        }

        public void DeleteFunction(int id)
        {
            var function = _context.GroupFunctions.Find(id);
            if (function == null) return;

            _context.GroupFunctions.Remove(function);
            _context.SaveChanges();
        }
    }

}