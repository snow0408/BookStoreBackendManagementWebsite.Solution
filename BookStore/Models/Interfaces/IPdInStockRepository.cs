using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    public interface IPdInStockRepository
    {

        // 獲取所有進貨紀錄
        IEnumerable<PdInStockDto> GetAllPdInStocks();

        // 查詢進貨紀錄
        List<PdInStockDto> Search(string name);
        PdInStockDto SearchFirstName(string name);

        // 獲取進貨紀錄
        PdInStockDto Get(int id);

        // 新增進貨紀錄
        void Create(PdInStockDto dto);

        // 更新進貨紀錄
        void Update(PdInStockDto dto);

        // 刪除進貨紀錄
        void Delete(int id);

        // 根據ID獲得產品資料
        IEnumerable<PdInStockDto> GetPdInStocksByProductId(int id);



    }
}
