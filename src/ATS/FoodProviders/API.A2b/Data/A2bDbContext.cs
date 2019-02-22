using API.A2b.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.A2b.Data
{
    public class A2bDbContext : DbContext
    {
        public A2bDbContext(DbContextOptions<A2bDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<Meal> Meals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
