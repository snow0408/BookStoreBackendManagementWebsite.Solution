using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore202401.Models.Infra
{
    public class Pagination
    {
        public Pagination(int pageNumber, int pageSize, int totalCount)
        {
            //todo:驗證參數合理性
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }
        public int PageNumber { get; }//目前頁數
        public int PageSize { get; }//每頁筆數
        public int TotalCount { get; }//符合條件總筆數

        //計算總頁數
        public int Pages => (int)Math.Ceiling((double)TotalCount / PageSize);//總頁數
        public bool HashPrevPage => PageNumber > 1;//是否有上一頁
        public bool HashNextPage => PageNumber < Pages;//是否有下一頁
    }

    //存放分頁資料
    public class PagedList<T> where T : class
    {

        public PagedList(IEnumerable<T> data, int pageNumber, int pageSize, int totalCount)
        {
            Data = data;
            Pagination = new Pagination(pageNumber, pageSize, totalCount);
        }
        public IEnumerable<T> Data { get; private set; }//分頁資料
        public Pagination Pagination { get; private set; }
    }
}