using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    public interface IGroupFunctionRepository
    {
        IEnumerable<GroupFunctionDto> GetAllFunctions();
        GroupFunctionDto GetFunctionById(int id);
        void AddFunction(GroupFunctionDto function);
        void UpdateFunction(GroupFunctionDto function);
        void DeleteFunction(int id);
    }
}
