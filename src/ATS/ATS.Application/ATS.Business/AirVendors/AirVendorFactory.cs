using ATS.Business.AirVendors.GoAir;
using ATS.Business.AirVendors.JetAir;
using ATS.Business.Interfaces;
using System;
using static ATS.Common.ATSEnums;


namespace ATS.Business.AirVendors
{
    public class AirVendorFactory : IAirVendorFactory
    {
        private readonly IServiceProvider serviceProvider;
        public AirVendorFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public object GetObject(AirVendorEnum airVendor)
        {
            switch (airVendor)
            {
                case AirVendorEnum.GoAir:
                    return serviceProvider.GetService(typeof(GoAirAirlines));
                case AirVendorEnum.JetAir:
                    return serviceProvider.GetService(typeof(JetAirAirlines));
                default:
                    break;
            }

            return null;
        }
    }
}
