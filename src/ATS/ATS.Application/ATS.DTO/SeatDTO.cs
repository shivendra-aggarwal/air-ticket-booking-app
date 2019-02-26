using System;

namespace ATS.DTO
{
    public class SeatDTO
    {
        public Guid ExternalId { get; set; }

        public DateTime AvailableDate { get; set; }

        public int BasePrice { get; set; }

        public string FromCityName { get; set; }

        public string ToCityName { get; set; }

        public string FlightNumber { get; set; }

        public string SeatType { get; set; }

        public int SeatNumber { get; set; }
        
        public string VendorName { get; set; }
    }
}
