using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.DTO
{
    public class BookingDTO
    {
        public DateTime BookingDate { get; set; }

        public int BookingStatus { get; set; }

        public Guid BookingSeatId { get; set; }

        public string BookingVendorName { get; set; }

        public decimal BookingAmount { get; set; }
    }
}
