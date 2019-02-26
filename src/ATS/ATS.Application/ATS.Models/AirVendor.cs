using System;

namespace ATS.Models
{
    public class AirVendor : BaseEntity
    {
        public string AccessUrl { get; set; }

        public string VendorName { get; set; }

        public string AvailabilityTestUrl { get; set; }
    }
}
