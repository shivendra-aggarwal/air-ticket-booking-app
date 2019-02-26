using ATS.DTO;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ATS.Business.Interfaces
{
    public interface ISeats
    {
        Task<IEnumerable<SeatDTO>> GetAvailableSeats(AirVendorDTO airVendorDTO);
    }
}
