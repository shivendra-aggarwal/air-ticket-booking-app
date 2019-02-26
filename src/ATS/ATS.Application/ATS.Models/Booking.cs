using System;

namespace ATS.Models
{
    public class Booking : BaseEntity
    {
        public Guid BookingReferenceNumber { get; set; }

        public DateTime BookingDate { get; set; }

        public int BookingStatus { get; set; }

        public Guid BookingExternalSeatId { get; set; }

        public string BookingVendorName { get; set; }

        public decimal BookingAmount { get; set; }
    }
}
