using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookStore.Models.Dtos;

namespace BookStore.Models.Interfaces
{
    public interface IArticleRepository
    {
        //Get all articles
        IEnumerable<ArticleDto> GetAll();

        //Get articles by keyword
        List<ArticleDto> Search(string keyword);
        //Search article
        ArticleDto SearchKeyword(string keyword);

        //Get article by id
        ArticleDto Get(int id);
        //Add article
        void Create(ArticleDto dto);
        //Update article
        void Update(ArticleDto dto);
        //Delete article
        void Delete(int id);
    }
}
