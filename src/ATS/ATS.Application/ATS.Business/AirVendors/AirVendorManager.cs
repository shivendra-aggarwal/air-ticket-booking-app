using ATS.Business.Interfaces;
using ATS.Business.Interfaces.AirVendors;
using ATS.DataAccess.Repositories.Interfaces;
using ATS.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ATS.Business.AirVendors
{
    /// <summary>
    /// this complex type will act as facilitator for Air vendor strategy
    /// where we will execute features for all active vendors.
    /// </summary>
    public class AirVendorManager : IAirVendorManager
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IAirVendorRepository airVendorRepository;
        private readonly IAirVendorObjectManager airVendorObjectManager;
        public AirVendorManager(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            airVendorRepository = (IAirVendorRepository)serviceProvider.GetService(typeof(IAirVendorRepository));
            airVendorObjectManager = (IAirVendorObjectManager)serviceProvider.GetService(typeof(IAirVendorObjectManager));
        }

        /// <summary>
        /// Using air vendor strategy 
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<SeatDTO>> GetAllSeats()
        {
            List<SeatDTO> availableSeats = new List<SeatDTO>();
            try
            {
                IEnumerable<AirVendorDTO> airVendorDTOs;
                var airVendors = await airVendorRepository.Get();

                //TODO: Model to DTO conversion to be sorted
                airVendorDTOs = airVendors.Select(v =>
                new AirVendorDTO()
                {
                    Id = v.Id,
                    AccessUrl = v.AccessUrl,
                    VendorName = v.VendorName,
                    AvailabilityTestUrl = v.AvailabilityTestUrl
                }).ToList();

                foreach (var vendor in airVendorDTOs)
                {
                    IAvailable airVendor = await airVendorObjectManager.GetObjectByType(vendor.VendorName) as IAvailable;

                    if (airVendor != null)
                    {
                        vendor.AvailabilityStatus = await airVendor.CheckAvailability(vendor.AvailabilityTestUrl);
                    }

                    if (vendor.AvailabilityStatus)
                    {
                        ISeats seats = await airVendorObjectManager.GetObjectByType(vendor.VendorName) as ISeats;
                        if (seats != null)
                        {
                            availableSeats.AddRange(await seats.GetAvailableSeats(vendor));
                        }

                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return availableSeats;
        }

        /// <summary>
        /// This method is responsible to process for booking transaction with confirming from different vendors
        /// and storing booking details in database
        /// </summary>
        /// <param name="bookingDTO"></param>
        /// <returns></returns>
        public async Task<bool> ProcessBooking(BookingDTO bookingDTO)
        {
            bool result = default(bool);
            try
            {
                var airVendors = await airVendorRepository.Get();

                bookingDTO.AccessUrl = airVendors.FirstOrDefault(av => string.Equals(av.VendorName, bookingDTO.BookingVendorName, StringComparison.OrdinalIgnoreCase))?.AccessUrl;

                IBookSeat bookSeat = await airVendorObjectManager.GetObjectByType(bookingDTO.BookingVendorName) as IBookSeat;

                if (bookSeat == null)
                {
                    throw new Exception(bookingDTO.BookingVendorName + " is not registered properly, please check with administrator");
                }

                if(!await bookSeat.ProcessSeatBooking(bookingDTO))
                {
                    throw new Exception("Booking confirmation not received, please try later");
                }

                result = true;
            }
            catch (Exception)
            {
                throw;
            }

            return result;
        }
    }
}
