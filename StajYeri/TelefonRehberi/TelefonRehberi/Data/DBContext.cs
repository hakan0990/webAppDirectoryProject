using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;
using TelefonRehberi.Models;

namespace TelefonRehberi.Data
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options)
        {
        }

        public DBContext()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
                var configuration = builder.Build();

                optionsBuilder.UseSqlServer(configuration.GetConnectionString("Default"));
            }
        }

        public DbSet<newResult> newResults { get; set; }
        public DbSet<newLogin> newLogins { get; set; }  
    }
}
