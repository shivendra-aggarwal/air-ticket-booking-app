using System;

namespace ATS.DTO
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
