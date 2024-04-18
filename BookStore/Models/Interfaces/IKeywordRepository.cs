using BookStore.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Models.Interfaces
{
    public interface IKeywordRepository
    {
        void Create(KeywordDto dto);

        void Delete(int id);

        List<KeywordDto> Search(string name);

        void Update(KeywordDto dto);

        KeywordDto SearchFirstName(string name);

        KeywordDto Get(int id);
    }
}
