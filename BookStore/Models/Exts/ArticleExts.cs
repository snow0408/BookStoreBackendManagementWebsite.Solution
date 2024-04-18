using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.ViewModels;
using System;

namespace BookStore.Models.Exts
{
    public static class ArticleExts
    {
        public static ArticleVm ToArticleVm(this ArticleDto dto)
        {
            return new ArticleVm
            {
                ArticleID = dto.ArticleID,
                EmployeeID = dto.EmployeeID,
                Title = dto.Title,
                PublishTime = dto.PublishTime,
                Content = dto.Content,
                Category = dto.Category
            };
        }
        public static ArticleDto ToArticleDto(this ArticleVm vm)
        {
            return new ArticleDto
            {
                ArticleID = vm.ArticleID,
                EmployeeID = vm.EmployeeID,
                Title = vm.Title,
                PublishTime = vm.PublishTime,
                Content = vm.Content,
                Category = vm.Category
            };
        }

        //public static ArticleVm ToArticleIndexVm(this Article dto)
        //{

        //    return new ArticleIndexVm
        //    {
        //        ArticleID = dto.ArticleID;
        //        EmployeeID = dto.EmployeeID;
        //        Title = dto.Title;
        //        PublishTime = dto.PublishTime;
        //        Content = dto.Content;
        //        Category = dto.Category;
        //    };
        //}

        public static ArticleDto ToArticleDto(this Article entity)
        {
            var dto = new ArticleDto();
            if (entity != null)
            {
                dto.ArticleID = entity.ArticleID;
                dto.EmployeeID = (int)entity.EmployeeID;
                dto.Title = entity.Title;
                dto.PublishTime = (DateTime)entity.PublishTime;
                dto.Content = entity.Content;
                dto.Category = entity.Category;
            }
            return dto;
        }

        public static string FormattedDate(ArticleDto dto) => dto.PublishTime.ToString("yyyy/MM/dd");
    }
}