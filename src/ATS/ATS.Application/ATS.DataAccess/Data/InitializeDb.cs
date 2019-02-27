using ATS.DataAccess.Context;
using System.Linq;
using static ATS.Common.ATSEnums;

namespace ATS.DataAccess.Data
{
    public class InitializeDb
    {
        public static void LoadAirVendors(ATSDbContext context)
        {
            int count = 0;
            context.AirVendors = new System.Collections.Generic.HashSet<Models.AirVendor>();
            if (!context.AirVendors.Any())
            {
                context.AirVendors.Add(new Models.AirVendor()
                {
                    Id = ++count,
                    AccessUrl = "https://localhost:44341/",
                    VendorName = AirVendorEnum.GoAir.ToString(),
                    AvailabilityTestUrl = "https://localhost:44341/api/values",
                });
                context.AirVendors.Add(new Models.AirVendor()
                {
                    Id = ++count,
                    AccessUrl = "https://localhost:44310/",
                    VendorName = AirVendorEnum.JetAir.ToString(),
                    AvailabilityTestUrl = "https://localhost:44310/api/values",
                });

            }
            context.SaveChangesAsync();
        }
    }
}
