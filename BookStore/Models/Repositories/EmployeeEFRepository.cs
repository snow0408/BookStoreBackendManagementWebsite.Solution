using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookStore.Models.Repositories
{
    public class EmployeeEFRepository : IEmployeeRepository
    {
        private readonly AppDbContext _db = new AppDbContext();


        public void CreateFromVm(EmployeeVm model)
        {
            EmployeeDto dto = new EmployeeDto
            {
                Name = model.Name,
                Gender = model.Gender,
                Address = model.Address,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                GroupId = model.GroupId,
                Account = model.Account,
                Password = model.Password
            };

            Create(dto);
        }
        public void Create(EmployeeDto dto)
        {

            var employee = new Employee
            {                
                Name = dto.Name,
                Gender = dto.Gender,
                Address = dto.Address,
                Email = dto.Email,
                PhoneNumber = dto.PhoneNumber,
                GroupId = dto.GroupId,
                Account = dto.Account,
                Password = dto.Password
            };

            _db.Employees.Add(employee);
            _db.SaveChanges();
        }

        public List<EmployeeDto> GetAll()
        {
            return _db.Employees.Select(emp => new EmployeeDto
            {
                Id = emp.Id,
                Name = emp.Name,
                Gender = emp.Gender,
                Address = emp.Address,
                Email = emp.Email,
                PhoneNumber = emp.PhoneNumber,
                GroupId = emp.GroupId,
                Account = emp.Account,
                Password = emp.Password
            }).ToList();
        }
        public void Delete(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee != null)
            {
                _db.Employees.Remove(employee);
                _db.SaveChanges();
            }
        }

        public List<EmployeeDto> Search(string name)
        {
            return _db.Employees
                      .Where(e => e.Name.Contains(name))
                      .Select(emp => new EmployeeDto
                      {
                          Id = emp.Id,
                          Name = emp.Name,
                          Gender = emp.Gender,
                          Address = emp.Address,
                          Email = emp.Email,
                          PhoneNumber = emp.PhoneNumber,
                          GroupId = emp.GroupId,
                          Account = emp.Account,
                          Password = emp.Password
                      })
                      .ToList();
        }
        public void UpdateFromVm(EmployeeVm model)
        {
            var employee = _db.Employees.Find(model.Id);
            if (employee != null)
            {
                employee.Name = model.Name;
                employee.Gender = model.Gender;
                employee.Address = model.Address;
                employee.Email = model.Email;
                employee.PhoneNumber = model.PhoneNumber;
                employee.GroupId = model.GroupId;
                employee.Account = model.Account;
                employee.Password = model.Password;

                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
        public void Update(EmployeeDto dto)
        {
            var employee = _db.Employees.Find(dto.Id);
            if (employee != null)
            {
                employee.Name = dto.Name;
                employee.Gender = dto.Gender;
                employee.Address = dto.Address;
                employee.Email = dto.Email;
                employee.PhoneNumber = dto.PhoneNumber;
                employee.GroupId = dto.GroupId;
                employee.Account = dto.Account;
                employee.Password = dto.Password;

                _db.Entry(employee).State = EntityState.Modified;
                _db.SaveChanges();
            }
        }
       

        public EmployeeDto GetById(int id)
        {
            var employee = _db.Employees.Find(id);
            if (employee != null)
            {
                return new EmployeeDto
                {
                    Id = employee.Id,
                    Name = employee.Name,
                    Gender = employee.Gender,
                    Address = employee.Address,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    GroupId = employee.GroupId,
                    Account = employee.Account,
                    Password = employee.Password
                };
            }

            return null;
        }


    }
}