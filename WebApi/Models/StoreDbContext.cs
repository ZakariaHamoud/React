using Microsoft.EntityFrameworkCore;
using WebApi.Controllers;

namespace WebApi.Models
{
    public class StoreDbContext: DbContext
    {
        public StoreDbContext(DbContextOptions<StoreDbContext> options)
           : base(options)
        {
        }

        public DbSet<DbItems> DbItems { get; set; } = null!;
        public DbSet<DbItemsUnits> DbItemsUnits { get; set; } = null!;
        public DbSet<DbUnits> DbUnits { get; set; } = null!;
        

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DevConnection");

            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
