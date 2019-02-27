using ATS.DataAccess.Context;
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
    public class BookingRepository : IBookingRepository
    {
        private ATSDbContext context;
        public BookingRepository(ATSDbContext context)
        {
            this.context = context;
        }

        public async Task<Booking> Create(Booking obj)
        {
            context.Bookings = new HashSet<Booking>();
            context.Bookings.Add(obj);
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

        Task<IEnumerable<Booking>> IRepository<Booking>.Get()
        {
            throw new NotImplementedException();
        }

        Task<Booking> IRepository<Booking>.GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
