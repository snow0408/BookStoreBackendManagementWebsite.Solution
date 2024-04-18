using BookStore.Models.Dtos;
using BookStore.Models.Interfaces;

namespace BookStore.Models.Services
{
    public class BookProductService
    {
        private IBookProductRepository _repos;
        public BookProductService(IBookProductRepository repos)
        {
            _repos = repos;
        }
        public void Create(BookProductDto dto)
        {
            _repos.Create(dto);
        }
        public void Delete(int id)
        {
            _repos.Delete(id);
        }
        //public List<BookProductIndexVm> Search(string name)
        //{
        //    return _repos.Search(name)
        //                 .Select(x => x.ToBookProductIndexVm())                         
        //                 .ToList();
        //}

        public void Update(BookProductDto dto)
        {
            _repos.Update(dto);
        }

        public BookProductDto GetByProductId(int id)
        {
            return _repos.GetByProductId(id);
        }

        //public BookProductVm Get(int id)
        //{
        //    return _repos.Get(id).ToBookProductVm();
        //}
    }
}