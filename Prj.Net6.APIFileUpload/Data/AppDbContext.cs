using Microsoft.EntityFrameworkCore;
using Prj.Net6.APIFileUpload.Entities;
using System.Collections.Generic;

namespace Prj.Net6.APIFileUpload.Data
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public AppDbContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<FileDetails> FileDetails { get; set; }
        public DbSet<UserPwd> UserPWD { get; set; }
    }
}
