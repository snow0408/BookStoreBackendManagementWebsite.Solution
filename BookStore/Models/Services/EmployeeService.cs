using BookStore.Models.Dtos;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void AddEmployee(EmployeeDto dto)
        {
           
            _employeeRepository.Create(dto);
        }

        public List<EmployeeDto> GetAllEmployees()
        {
            return _employeeRepository.GetAll();
        }
        
    }
}