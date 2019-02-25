using API.GoAir.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GoAir.Data
{
    public class GoAirDbContext : DbContext
    {
        public GoAirDbContext(DbContextOptions<GoAirDbContext> dbContextOptions)
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
