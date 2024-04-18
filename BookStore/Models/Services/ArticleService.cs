using BookStore.Models.Dtos;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using BookStore.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BookStore.Models.Services
{
    public class ArticleService
    {
        private readonly IArticleRepository _repos;
        public ArticleService(IArticleRepository repos) => _repos = repos;

        public void CreateArticle(ArticleDto dto)
        {
            ValidateArticle(dto.ArticleID, dto.Title);
            _repos.Create(dto);
        }

        public List<ArticleVm> Search(string keyword)
        {
            return _repos.Search(keyword)
                .Select(x => x.ToArticleVm())
                .OrderByDescending(x => x.PublishTime)
                .ToList();
        }

        public void ValidateArticle(int articleID, string title)
        {
            //if (string.IsNullOrWhiteSpace(articleID.ToString()))
            //    throw new ArgumentException("文章編號不可為空白");
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("文章標題不可為空白");
            //if (!_repos.IsExist(articleID))
            //    throw new InvalidOperationException("文章不存在");
            //if (_repos.IsExist(articleID, title))
            //    throw new InvalidOperationException("文章標題重複");
        }



        public ArticleVm GetArticle(int articleID)
        {
            return _repos.Get(articleID).ToArticleVm();
        }

        public void UpdateArticle(ArticleDto dto)
        {
            IsNameExist(dto.ArticleID, dto.Title);
            _repos.Update(dto);
        }

        public void DeleteArticle(int articleID)
        {
            _repos.Delete(articleID);
        }

        public ArticleVm Get(int articleID)
        {
            return _repos.Get(articleID).ToArticleVm();
        }

        //TODO GetArticleSelectList()

        private bool IsNameUnique(int articleID, string title)
        {
            var existingArticles = _repos.GetAll().ToList();
            return existingArticles.Exists(article => article.ArticleID.Equals(articleID) && article.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
            //return existingArticles.Exists(article => article.ArticleID.Equals(articleID, StringComparison.OrdinalIgnoreCase) && article.Title.Equals(title, StringComparison.OrdinalIgnoreCase));
        }

        private void IsNameExist(int articleID, string title)
        //C# 7.3 中無法使用 '可為 Null 的參考型別' 功能。請使用語言版本 8.0 或更高的版本。
        {
            var article = _repos.SearchKeyword(articleID.ToString());
            if (article != null && article.Title != title)
            {
                throw new InvalidOperationException("文章重複");
            }
        }

        public List<SelectListItem> Categories()
        {
            List<SelectListItem> statusList = new List<SelectListItem>();
            statusList.Add(new SelectListItem()
            {
                Text = "主題專欄",
                Value = "Topic",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "書籍推薦",
                Value = "Book",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "最新消息",
                Value = "News",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "藝文活動",
                Value = "Event",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "活動指南",
                Value = "Guide",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "影片專欄",
                Value = "Video",
                Selected = false
            });
            statusList.Add(new SelectListItem()
            {
                Text = "關於我們",
                Value = "About",
                Selected = false
            });
            return statusList;
        }


    }
    //下面寫業務邏輯
}