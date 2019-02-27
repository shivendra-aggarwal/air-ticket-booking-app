using ATS.DTO;
using System;
using System.Collections.Generic;

namespace ATS.UI.Models
{
    public class BookingViewModel
    {
        public string SelectedSeatId { get; set; }
        public string SelectedSeatVendorName { get; set; }

        public IEnumerable<SeatDTO> AvailableSeats { get; set; }

        public string TotalAmount { get; set; }

        public string BookinStatus { get; set; }

        public Guid BookingReferenceNumber { get; set; }    
    }
}
