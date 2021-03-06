﻿using ATS.DataAccess.Context;
using ATS.DataAccess.Repositories.Interfaces;
using ATS.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using ATS.DataAccess.Data;

namespace ATS.DataAccess.Repositories
{
    public class AirVendorRepository : IAirVendorRepository
    {
        private ATSDbContext context;
        public AirVendorRepository(ATSDbContext context)
        {
            this.context = context;
        }

        public async Task<AirVendor> Create(AirVendor obj)
        {
            context.AirVendors = new HashSet<AirVendor>();
            context.AirVendors.Add(obj);
            obj.Id = await context.SaveChangesAsync();
            return obj;
        }

        public async Task<IEnumerable<AirVendor>> Get()
        {
            InitializeDb.LoadAirVendors(context);
            return context.AirVendors.ToList();
        }

        public async Task<AirVendor> GetById(int id)
        {
            return context.AirVendors.Where(a => a.Id == id).FirstOrDefault();
        }
    }
}
