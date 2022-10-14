using Microsoft.EntityFrameworkCore;
using Prj.Net6.WebApp_MVCDatatable.Models;

namespace Prj.Net6.WebApp_MVCDatatable.Data
{
    public class AppDBContext : DbContext
    {
        private readonly DbContextOptions<AppDBContext> _options;

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
            _options = options;
        }

        public DbSet<User> tbl_users_fordt { get; set; }
        public DbSet<User2> tbl_users_fordt2 { get; set; }
    }
}
