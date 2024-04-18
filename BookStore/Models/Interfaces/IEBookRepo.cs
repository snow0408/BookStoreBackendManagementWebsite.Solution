using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Interfaces
{
    public interface IEBookRepo
    {
        void Create(EBookDto dto);

        void Update(EBookDto dto);

        void Delete(int id);

        EBookDto Get(int id);

        List<EBookDto> Search(string bookName);
		List<EBookDto> SearchEBook(string keyword);


	}
}