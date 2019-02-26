using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.DTO
{
    public class AirVendorDTO
    {
        public int Id { get; set; }

        public string AccessUrl { get; set; }

        public string VendorName { get; set; }

        public bool AvailabilityStatus { get; set; }

        public string AvailabilityTestUrl { get; set; }

        public ICollection<SeatDTO> Seats { get; set; }
    }
}
