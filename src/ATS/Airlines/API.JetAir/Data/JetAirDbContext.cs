using API.JetAir.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.JetAir.Data
{
    public class JetAirDbContext : DbContext
    {
        public JetAirDbContext(DbContextOptions<JetAirDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }
        public DbSet<Seat> Seats { get; set; }

        public DbSet<AllocatedSeat> AllocatedSeats { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
