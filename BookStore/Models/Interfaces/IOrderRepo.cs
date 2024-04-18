using BookStore202401.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Interfaces
{
    public interface IOrderRepo
    {
        //先傳進Dto，再回傳int
        int Create(OrdersDto dto);
        void Update(OrdersDto dto);
        List<OrdersDto> Search(string memberName, string status); //order_number是篩選條件

        List<OrdersDto> SearchByDate(DateTime startDate, DateTime endDate);


        void Delete(int id);
        OrdersDto Get(int id); //回傳一筆紀錄

    

        void Edit(OrdersDto dto);

    }
}