using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.GoAir.Models
{
    public class BookingDTO
    {
        public Guid BookingReferenceNumber { get; set; }

        public DateTime BookingDate { get; set; }

        public int BookingStatus { get; set; }

        public Guid BookingExternalSeatId { get; set; }

        public string BookingVendorName { get; set; }

        public string AccessUrl { get; set; }

        public decimal BookingAmount { get; set; }
    }
}
