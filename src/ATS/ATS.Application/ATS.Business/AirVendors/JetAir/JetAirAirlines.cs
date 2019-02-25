using ATS.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Business.AirVendors.JetAir
{
    public class JetAirAirlines : IAirVendor
    {
        public Task<bool> CheckAvailability()
        {
            throw new NotImplementedException();
        }
    }
}
