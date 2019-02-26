using ATS.DTO;
using System.Threading.Tasks;

namespace ATS.Business.Interfaces.AirVendors
{
    public interface IBookSeat
    {
        Task<bool> ProcessSeatBooking(BookingDTO bookingDTO);
    }
}
