using BookStore.Models.Dtos;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Models.Interfaces
{
    public interface IPromotionEventRepository
    {      
        void Create(PromotionEventDto entity); //Create use
        IEnumerable<PromotionEventDto> GetAll(); //GetAll use
        void Update(PromotionEventDto entity); //Update use
        void Delete(int id); //Delete use
        void Save();
        //public List<SelectListItem> Search(int page, int pageSize, string searchString);
        List<PromotionEventDto> Search(int page, int pageSize);

        List<PromotionEventDto> SearchEvent(string keyword);
    }
}
