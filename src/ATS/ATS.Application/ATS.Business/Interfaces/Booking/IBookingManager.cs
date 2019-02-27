using ATS.DTO;
using System.Threading.Tasks;

namespace ATS.Business.Interfaces
{
    public interface IBookingManager
    {
        Task<BookingDTO> CreateBooking(BookingDTO bookingDTO);
    }
}
