using Microsoft.EntityFrameworkCore;
using web_assignment3.Model;

namespace web_assignment3.DatabaseContext
{
    public class MyDatabaseContext:DbContext
    {
        private readonly IConfiguration _configuration;

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

        public DbSet<Comment> comments { get; set; }
    }
}
