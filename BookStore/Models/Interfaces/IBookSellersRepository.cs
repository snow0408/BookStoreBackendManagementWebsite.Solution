using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    public interface IBookSellersRepository
    {
        // 獲取所有書商
        IEnumerable<BookSellersDto> GetAllBookSellers();

        // 查詢書商
        List<BookSellersDto> Search(string name);
        BookSellersDto SearchFirstName(string name);

        // 獲取特定書商
        BookSellersDto Get(int id);

        // 新增書商
        void Create(BookSellersDto dto);

        // 更新書商
        void Update(BookSellersDto dto);

        // 刪除書商
       void Delete(int ID);

       

    }
}
