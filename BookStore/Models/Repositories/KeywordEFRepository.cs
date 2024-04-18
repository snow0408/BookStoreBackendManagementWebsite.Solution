using BookStore.Models.Dtos;
using BookStore.Models.EFModels;
using BookStore.Models.Exts;
using BookStore.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace BookStore.Models.Repositories
{
    public class KeywordEFRepository : IKeywordRepository
    {
        public void Create(KeywordDto dto)
        {
            var db = new AppDbContext();

            var model = new Keyword()
            {
                Name = dto.Name,
            };

            db.Keywords.Add(model);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var db = new AppDbContext();
            var model = db.Keywords.Find(id);
            db.Keywords.Remove(model);
            db.SaveChanges();
        }

        public List<KeywordDto> Search(string name)
        {
            var db = new AppDbContext();

            var model = db.Keywords
                            .AsNoTracking()
                            .Select(x => new KeywordDto()
                            {
                                Id = x.Id,
                                Name = x.Name,
                            });

            if (!string.IsNullOrEmpty(name))
            {
                model = model.Where(p => p.Name.Contains(name));
            }

            return model.ToList();
        }

        public void Update(KeywordDto dto)
        {
            var db = new AppDbContext();

            var model = db.Keywords.Find(dto.Id);
            model.Name = dto.Name;

            db.SaveChanges();
        }


        //查詢名稱
        public KeywordDto SearchFirstName(string name)
        {
            var db = new AppDbContext();
            var keyword = db.Keywords.FirstOrDefault(p => p.Name == name);

            return keyword.ToKeywordDto();
        }

        public KeywordDto Get(int id)
        {
            var db = new AppDbContext();
            var keyword = db.Keywords.Find(id);

            return keyword.ToKeywordDto();
        }
    }
}