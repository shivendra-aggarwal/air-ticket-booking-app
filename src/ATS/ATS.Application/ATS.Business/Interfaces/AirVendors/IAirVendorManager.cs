using ATS.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATS.Business.Interfaces
{
    public interface IAirVendorManager
    {
        Task<IEnumerable<SeatDTO>> GetAllSeats();

        Task<bool> ProcessBooking(BookingDTO bookingDTO);
    }
}
