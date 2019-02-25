using ATS.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Business.AirVendors.GoAir
{
    public class GoAirAirlines : IAirVendor
    {
        public Task<bool> CheckAvailability()
        {
            throw new NotImplementedException();
        }
    }
}
