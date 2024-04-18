using BookStore202401.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Interfaces
{
    public interface IOrderDetailsRepo
    {
      
        List<OrderDetailsDto> Search(int productId); 

        OrderDetailsDto Get(int id); 
    }
}