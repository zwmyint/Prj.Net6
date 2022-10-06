using Microsoft.EntityFrameworkCore;
using Prj.Net6.APIJWTRefreshToke.Entities;
using System.Collections.Generic;

namespace Prj.Net6.APIJWTRefreshToke.Helpers
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        private readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // in memory database used for simplicity, change to a real db for production applications
            options.UseInMemoryDatabase("TestDb");
        }
    }
}
