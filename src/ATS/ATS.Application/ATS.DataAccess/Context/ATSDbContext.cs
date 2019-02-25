using ATS.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.DataAccess.Context
{
    public class ATSDbContext : DbContext
    {
        public ATSDbContext(DbContextOptions<ATSDbContext> dbContextOptions)
            : base(dbContextOptions)
        {

        }

        public HashSet<AirVendor> AirVendors { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
