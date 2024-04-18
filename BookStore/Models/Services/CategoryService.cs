using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Services
{
    public class CategoryService
    {
        private ICategoryRepository _repos;
        public CategoryService(ICategoryRepository repos)
        {
            _repos = repos;
        }
        public void Create(CategoryDto dto)
        {
            IsNameExist(dto.Name, dto.Id);
            _repos.Create(dto);
        }
        public void Delete(int id)
        {
            _repos.Delete(id);
        }
        public List<CategoryIndexVm> Search(string name)
        {
            return _repos.Search(name)
                         .Select(x => x.ToCategoryIndexVm())
                         .OrderBy(x => x.DisplayOrder)
                         .ToList();
        }

        //public List<SelectListItem> GetCategorySelectList()
        //{
        //    var list = new List<SelectListItem>();
        //    var categories = _repos.Search("");
        //    foreach (var oneCategory in categories)
        //    {
        //        list.Add(new SelectListItem()
        //        {
        //            Text = oneCategory.Name,
        //            Value = oneCategory.Id.ToString(),
        //            Selected = false
        //        });
        //    }
        //    list[0].Selected = true;
        //    return list;
        //}

        public void Update(CategoryDto dto)
        {

            IsNameExist(dto.Name, dto.Id);
            _repos.Update(dto);
        }


        public CategoryVm Get(int id)
        {
            return _repos.Get(id).ToCategoryVm();
        }

        //---------funciton---------
        private void IsNameExist(string name, int? id)
        {
            var category = _repos.SearchFirstName(name);

            if (category.Id != null && id != category.Id) throw new Exception("分類名稱已重複");
        }

        public Dictionary<string, int> GetCategorySelectList()
        {
            var categoryList = new Dictionary<string, int>();
            var categories = _repos.Search("");
            foreach (var category in categories) categoryList.Add(category.Name, (int)category.Id);

            return categoryList;
        }
    }
}