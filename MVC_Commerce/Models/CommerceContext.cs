using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MVC_Commerce.Models
{
    public class CommerceContext:IdentityDbContext<ApplicationUser>
    {
        public CommerceContext(DbContextOptions<CommerceContext> options) : base(options)
        {

        }
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb; Database=2022Kitaplik2C;Trusted_Connection=True;");
        //}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Favourite>().HasKey(fav => new { fav.UserId, fav.ProductId });
            //modelBuilder.Entity<Favourite>().HasOne(u => u.User).WithMany(fav => fav.Favourites).HasForeignKey(u => u.UserId);
            //modelBuilder.Entity<Favourite>().HasOne(p => p.Product).WithMany(fav => fav.Favourites).HasForeignKey(p => p.ProductId);
            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        //public DbSet<User> Users { get; set; }
        //public DbSet<Comment> Comments { get; set; }
        //public DbSet<Favourite> Favourites { get; set; }



        //Orders
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem > ShoppingCartItems { get; set;}
    }
}
