using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Prj.Net6.APIRabbitMQ.Models;
using System.Collections.Generic;

namespace Prj.Net6.APIRabbitMQ.Data
{
   
    public class DbContextClass : DbContext
    {
        //protected readonly IConfiguration Configuration;

        //public DbContextClass(IConfiguration configuration)
        //{
        //    Configuration = configuration;
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        //    }
        //}

        public DbContextClass(DbContextOptions<DbContextClass> options)
        : base(options)
        { }

        public DbSet<ProductRabbitMQ> Products { get; set; }
    }
    
}
