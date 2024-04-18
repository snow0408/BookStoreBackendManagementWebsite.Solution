namespace BookStore.Models.Dtos
{
    public class UsedBookDto
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public string BookName { get; set; }

        public int CategoryId { get; set; }

        public bool ProductStatus { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public string ISBN { get; set; }

        public string Pictrue { get; set; }

        public string BookStatus { get; set; }

        //會員資訊
        public string MemberEmail { get; set; }

        //分類資訊
        public string CategoryName { get; set; }
    }
}