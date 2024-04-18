using BookStore.Models.Dtos;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Services
{
    public class EBookService
    {
        private IEBookRepo _repo;

        public EBookService(IEBookRepo repos)
        {
            _repo = repos;
        }
        public void Create(EBookDto dto)
        {
            _repo.Create(dto);

        }

        //要看這裡
        public List<EBookVm> Search(string bookName)
        {
            var dtos = _repo.Search(bookName);
            var vms = dtos.Select(x => new EBookVm()
            {
                Id = x.Id,
                BookId = x.BookId,
                FileLink = x.FileLink,
                Sample = x.Sample,
                BookName=x.BookName
            }).ToList();
            return vms;
        }
		public List<EBookVm> SearchEBook(string keyword)
		{
			var dtos = _repo.SearchEBook(keyword);
			var vms = dtos.Select(x => new EBookVm()
			{
				Id = x.Id,
				BookName = x.BookName
			}).ToList();

			return vms;
		}
		public EBookDto Get(int id)
        {
            return _repo.Get(id);
        }
        public void Delete(int id)
        {
            _repo.Delete(id);
        }
        public void Update(EBookDto dto)
        {
            _repo.Update(dto);
        }

    }


}