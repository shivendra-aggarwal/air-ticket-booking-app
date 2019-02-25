using ATS.DataAccess.Context;
using ATS.DataAccess.Repositories.Interfaces;
using ATS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

namespace ATS.DataAccess.Repositories
{
    public class AirVendorRepository : IAirVendorRepository
    {
        private ATSDbContext context;
        public AirVendorRepository(ATSDbContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<AirVendor>> Get()
        {
            return context.AirVendors.ToList();
        }

        public async Task<AirVendor> GetById(int id)
        {
            return context.AirVendors.Where(a => a.AirVendorId == id).FirstOrDefault();
        }
    }
}
