using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    public interface ICategoryRepository
    {
        void Create(CategoryDto dto);

        void Delete(int id);

        List<CategoryDto> Search(string name);  

        void Update(CategoryDto dto);

        CategoryDto SearchFirstName(string name);

        CategoryDto Get(int id);


    }
}
