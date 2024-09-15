using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace HairSalon.Infrastructure
{
    public class HairSalonDbContext : DbContext
    {
        public HairSalonDbContext()
        {
        }

        public HairSalonDbContext(DbContextOptions<HairSalonDbContext> options) : base(options)
        {
        }

        private string GetConnectionString()
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", false, true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", true, true)
                .Build();

            return configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(GetConnectionString(), sqlOptions => sqlOptions.CommandTimeout(120));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
