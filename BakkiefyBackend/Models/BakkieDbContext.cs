using System;
using System.Collections.Generic;

using System.Linq;
using System.Web;
using Microsoft.EntityFrameworkCore;

namespace BakkiefyBackend.Models
{
    public class BakkieDbContext : DbContext
    {
        public BakkieDbContext(DbContextOptions<BakkieDbContext> contextOptions)
            :base(contextOptions)
        {
        }
        public virtual DbSet<Bakkie> Bakkies { get; set; }
        public virtual DbSet<BakkieRequest> BakkieRequests { get; set; }
        public virtual DbSet<BakkieSize> BakkieSizes { get; set; }
        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<CustomerBlackList> CustomerBlackLists { get; set; }
        public virtual DbSet<Driver> Drivers { get; set; }
        public virtual DbSet<DriverBlackList> DriverBlackLists { get; set; }
        public virtual DbSet<Online> Onlines { get; set; }
        public virtual DbSet<Rating> Ratings { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
          
        }
       


    }
}