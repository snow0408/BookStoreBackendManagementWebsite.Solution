using System.ComponentModel.DataAnnotations;

namespace BookStore.Models.ViewModels
{
    public class KeywordIndexVm
    {
        public int Id { get; set; }

        [Display(Name = "關鍵詞名稱")]
        public string Name { get; set; }


    }
}