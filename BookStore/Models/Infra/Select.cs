using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models.Infrastructure
{
    public class Select
    {
        public enum StatusEnum
        {
            未出貨,
            已出貨,
            訂單已完成,
            訂單已取消,
            訂單已退貨
            
        }
    }
}