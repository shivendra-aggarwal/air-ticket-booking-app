using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.JetAir.Models
{
    public class AllocatedSeat
    {
        public int AllocatedSeatId { get; set; }

        public int SeatId { get; set; }

        public Guid ExternalBookingId { get; set; }

    }
}
