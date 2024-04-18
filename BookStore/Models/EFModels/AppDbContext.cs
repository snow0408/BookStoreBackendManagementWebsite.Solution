using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace BookStore.Models.EFModels
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext()
            : base("name=AppDbContext")
        {
        }

        public virtual DbSet<BookProduct> BookProducts { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<EBook> EBooks { get; set; }
        public virtual DbSet<Keyword> Keywords { get; set; }
        public virtual DbSet<UsedBook> UsedBooks { get; set; }
        public virtual DbSet<AnalyzeActivity> AnalyzeActivities { get; set; }
        public virtual DbSet<AnalyzeOneBook> AnalyzeOneBooks { get; set; }
        public virtual DbSet<AnalyzeSale> AnalyzeSales { get; set; }
        public virtual DbSet<AnalyzeUserInteraction> AnalyzeUserInteractions { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<BookReview> BookReviews { get; set; }
        public virtual DbSet<Bookseller> Booksellers { get; set; }
        public virtual DbSet<CouponRedemption> CouponRedemptions { get; set; }
        public virtual DbSet<Coupon> Coupons { get; set; }
        public virtual DbSet<EBooksPermission> EBooksPermissions { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Favorite> Favorites { get; set; }
        public virtual DbSet<GroupFunction> GroupFunctions { get; set; }
        public virtual DbSet<GroupPermission> GroupPermissions { get; set; }
        public virtual DbSet<Member> Members { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<PdInStock> PdInStocks { get; set; }
        public virtual DbSet<PointsHistory> PointsHistories { get; set; }
        public virtual DbSet<ProductKeyword> ProductKeywords { get; set; }
        public virtual DbSet<ProductPicture> ProductPictures { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<PromotionEvent> PromotionEvents { get; set; }
        public virtual DbSet<Promotion> Promotions { get; set; }
        public virtual DbSet<QtyBookInventory> QtyBookInventories { get; set; }
        public virtual DbSet<QtyflawBook> QtyflawBooks { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<UsedBooksAllocationRecord> UsedBooksAllocationRecords { get; set; }
        public virtual DbSet<UsedBooksCart> UsedBooksCarts { get; set; }
        public virtual DbSet<UsedBooksLogisticsOrder> UsedBooksLogisticsOrders { get; set; }
        public virtual DbSet<UsedBooksOrderDetail> UsedBooksOrderDetails { get; set; }
        public virtual DbSet<UsedBooksOrder> UsedBooksOrders { get; set; }
        public virtual DbSet<WriteBookReview> WriteBookReviews { get; set; }
        public virtual DbSet<LogisticsOrder> LogisticsOrders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Refund> Refunds { get; set; }
        public virtual DbSet<Return> Returns { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }
        public virtual DbSet<UsedBooksReturn> UsedBooksReturns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                .HasMany(e => e.BookProducts)
                .WithRequired(e => e.Book)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.Books)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Category>()
                .HasMany(e => e.UsedBooks)
                .WithRequired(e => e.Category)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<EBook>()
                .HasMany(e => e.EBooksPermissions)
                .WithRequired(e => e.EBook)
                .HasForeignKey(e => e.BookID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsedBook>()
                .Property(e => e.Price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UsedBook>()
                .HasMany(e => e.UsedBooksCarts)
                .WithRequired(e => e.UsedBook)
                .HasForeignKey(e => e.BookID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsedBook>()
                .HasMany(e => e.UsedBooksOrderDetails)
                .WithRequired(e => e.UsedBook)
                .HasForeignKey(e => e.BookID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<AnalyzeActivity>()
                .Property(e => e.SalesGrowthRate)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AnalyzeOneBook>()
                .Property(e => e.SalesAmount)
                .HasPrecision(18, 0);

            modelBuilder.Entity<AnalyzeSale>()
                .Property(e => e.Total)
                .HasPrecision(18, 0);

            modelBuilder.Entity<BookReview>()
                .Property(e => e.Rating)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Bookseller>()
                .HasMany(e => e.BookProducts)
                .WithRequired(e => e.Bookseller)
                .HasForeignKey(e => e.PublisherId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Bookseller>()
                .HasMany(e => e.PdInStocks)
                .WithOptional(e => e.Bookseller)
                .HasForeignKey(e => e.SupplierID);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.CouponRedemptions)
                .WithRequired(e => e.Coupon)
                .HasForeignKey(e => e.CouponID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Coupon>()
                .HasMany(e => e.CouponRedemptions1)
                .WithRequired(e => e.Coupon1)
                .HasForeignKey(e => e.CouponID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.News)
                .WithRequired(e => e.Employee)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<GroupFunction>()
                .HasMany(e => e.GroupPermissions)
                .WithMany(e => e.GroupFunctions)
                .Map(m => m.ToTable("GroupRelationship").MapLeftKey("FunctionId").MapRightKey("GroupId"));

            modelBuilder.Entity<GroupPermission>()
                .HasMany(e => e.Employees)
                .WithRequired(e => e.GroupPermission)
                .HasForeignKey(e => e.GroupId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.UsedBooks)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.AnalyzeUserInteractions)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.BookReviews)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.EBooksPermissions)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Orders)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.PointsHistories)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.Returns)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.UsedBooksAllocationRecords)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.UsedBooksCarts)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.UsedBooksOrders)
                .WithRequired(e => e.Member)
                .HasForeignKey(e => e.BuyerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.UsedBooksOrders1)
                .WithRequired(e => e.Member1)
                .HasForeignKey(e => e.SellerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Member>()
                .HasMany(e => e.WriteBookReviews)
                .WithRequired(e => e.Member)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PdInStock>()
                .Property(e => e.BuyPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.AnalyzeOneBooks)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.BookID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.AnalyzeSales)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.BookID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.AnalyzeUserInteractions)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.BookID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.PdInStocks)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.QtyBookInventories)
                .WithRequired(e => e.Product)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.QtyflawBooks)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.BookID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Product>()
                .HasMany(e => e.WriteBookReviews)
                .WithRequired(e => e.Product)
                .HasForeignKey(e => e.BookID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PromotionEvent>()
                .Property(e => e.DiscountRate)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.Coupons)
                .WithRequired(e => e.Promotion)
                .HasForeignKey(e => e.PromotionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Promotion>()
                .HasMany(e => e.Coupons1)
                .WithRequired(e => e.Promotion1)
                .HasForeignKey(e => e.PromotionID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QtyBookInventory>()
                .Property(e => e.BuyPrice)
                .HasPrecision(18, 0);

            modelBuilder.Entity<UsedBooksOrder>()
                .HasMany(e => e.UsedBooksAllocationRecords)
                .WithRequired(e => e.UsedBooksOrder)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsedBooksOrder>()
                .HasMany(e => e.UsedBooksLogisticsOrders)
                .WithRequired(e => e.UsedBooksOrder)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsedBooksOrder>()
                .HasMany(e => e.UsedBooksOrderDetails)
                .WithRequired(e => e.UsedBooksOrder)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsedBooksOrder>()
                .HasMany(e => e.UsedBooksReturns)
                .WithRequired(e => e.UsedBooksOrder)
                .HasForeignKey(e => e.OrderID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<LogisticsOrder>()
                .HasMany(e => e.Returns)
                .WithRequired(e => e.LogisticsOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.LogisticsOrders)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.OrderDetails)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Refunds)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Order>()
                .HasMany(e => e.Returns)
                .WithRequired(e => e.Order)
                .WillCascadeOnDelete(false);
        }
    }
}
