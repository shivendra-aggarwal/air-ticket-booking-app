using System;
using System.Collections.Generic;
using System.Text;

namespace ATS.Models
{
    public class Booking : BaseEntity
    {
        public DateTime BookingDate { get; set; }

        public int BookingStatus { get; set; }

        public Guid BookingExternalId { get; set; }

        public decimal BookingAmount { get; set; }
    }
}
