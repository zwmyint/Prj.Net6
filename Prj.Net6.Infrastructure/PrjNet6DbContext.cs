using Microsoft.EntityFrameworkCore;
using Prj.Net6.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Infrastructure
{

    public class PrjNet6DbContext : DbContext
    {
        public PrjNet6DbContext(DbContextOptions<PrjNet6DbContext> options): base(options)
        {
        }

        // EventBooking App
        public virtual DbSet<Event> Event { get; set; }
        public virtual DbSet<EventBooking> EventBooking { get; set; }

        // Project App
        public virtual DbSet<Project> Projects { get; set; }

        //
        public virtual DbSet<Person> Person { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Email> Email { get; set; }



        //// Task App
        //public virtual DbSet<RefreshToken> RefreshTokens { get; set; }
        //public virtual DbSet<Tasks> Tasks { get; set; }
        //public virtual DbSet<User> Users { get; set; }


    }

}
