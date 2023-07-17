using Microsoft.EntityFrameworkCore;
using web_assignment3.Model;

namespace web_assignment3.DatabaseContext
{
    public class MyDatabaseContext:DbContext
    {
        private readonly IConfiguration _configuration;
        public DbSet<Comment> comments { get; set; }
        public DbSet<CommentImage> CommentImages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Cart { get; set; }
        public DbSet<OrderModel> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }

        public MyDatabaseContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // base.OnConfiguring(optionsBuilder);
            //  optionsBuilder.UseInMemoryDatabase(databaseName:"UserDB");

            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
        }

        
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // user

            modelBuilder.Entity<User>()
                .HasKey(u => u.Id);


            // product
            modelBuilder.Entity<Product>()
              .HasKey(p => p.Id);


            modelBuilder.Entity<Product>()
        .Property(p => p.pricing)
        .HasConversion<double>();
            modelBuilder.Entity<Product>()
        .Property(p => p.shippingCost)
        .HasConversion<double>();

            // comment
            modelBuilder.Entity<Comment>()
                .HasKey(c => c.Id);
            
           

            modelBuilder.Entity<CommentImage>()
                .HasKey(ci => ci.Id);


            // cart 

            modelBuilder.Entity<Cart>().HasKey(c => c.Id);

r
            modelBuilder.Entity<OrderModel>()
                .HasKey(ci => ci.OrderId);
            modelBuilder.Entity<OrderItem>()
               .HasKey(ci => ci.OrderItemId);


            modelBuilder.Entity<Cart>().ToTable("Cart");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Comment>().ToTable("Comments");
            modelBuilder.Entity<CommentImage>().ToTable("CommentImages");
            modelBuilder.Entity<OrderModel>().ToTable("Orders");
            modelBuilder.Entity<OrderItem>().ToTable("OrderItem");
        }

     
    }
}
