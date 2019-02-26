using ATS.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ATS.Business.Interfaces
{
    public interface IAirVendorManager
    {
        Task<IEnumerable<SeatDTO>> GetAllSeats();
    }
}
