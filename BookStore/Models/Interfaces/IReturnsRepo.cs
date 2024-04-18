﻿using BookStore202401.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Interfaces
{
    public interface IReturnsRepo
    {
       
        List<ReturnsDto> Search(int orderId);

        ReturnsDto Get(int id); 
    }
}