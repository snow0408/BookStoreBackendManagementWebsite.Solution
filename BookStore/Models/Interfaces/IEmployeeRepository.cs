using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    public interface IEmployeeRepository
    {
        void Create(EmployeeDto employeeDto);
        List<EmployeeDto> GetAll();
        void Delete(int id);
        List<EmployeeDto> Search(string name);

        void Update(EmployeeDto dto);

    }
}
