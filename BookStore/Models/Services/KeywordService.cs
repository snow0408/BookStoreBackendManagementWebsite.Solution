using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Services
{
    public class KeywordService
    {
        private IKeywordRepository _repos;
        public KeywordService(IKeywordRepository repos)
        {
            _repos = repos;
        }
        public void Create(KeywordDto dto)
        {
            IsNameExist(dto.Name, dto.Id);
            _repos.Create(dto);
        }
        public void Delete(int id)
        {
            _repos.Delete(id);
        }
        public List<KeywordIndexVm> Search(string name)
        {
            return _repos.Search(name)
                         .Select(x => x.ToKeywordIndexVm())
                         .ToList();
        }

        public void Update(KeywordDto dto)
        {

            IsNameExist(dto.Name, dto.Id);
            _repos.Update(dto);
        }


        public KeywordVm Get(int id)
        {
            return _repos.Get(id).ToKeywordVm();
        }

        //---------funciton---------
        private void IsNameExist(string name, int? id)
        {
            var Keyword = _repos.SearchFirstName(name);

            if (Keyword.Id != null && id != Keyword.Id) throw new Exception("關鍵詞名稱已重複");
        }

        public Dictionary<string, int> GetKeywordSelectList()
        {
            var keywordList = new Dictionary<string, int>();
            var keywords = _repos.Search("");
            foreach (var keyword in keywords) keywordList.Add(keyword.Name, (int)keyword.Id);

            return keywordList;
        }
    }
}