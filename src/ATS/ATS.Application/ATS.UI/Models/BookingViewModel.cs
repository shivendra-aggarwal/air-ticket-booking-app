using ATS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.UI.Models
{
    public class BookingViewModel
    {
        public string SelectedSeatId { get; set; }

        public IEnumerable<SeatDTO> AvailableSeats { get; set; }
    }
}
