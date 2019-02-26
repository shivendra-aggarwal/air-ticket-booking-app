using ATS.Business.Interfaces;
using ATS.DataAccess.Repositories.Interfaces;
using ATS.DTO;
using System;
using System.Threading.Tasks;
using static ATS.Common.ATSEnums;

namespace ATS.Business.Booking
{
    public class BookingManager : IBookingManager
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IBookingRepository bookingRepository;
        private readonly IAirVendorManager airVendorManager;
        public BookingManager(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            this.airVendorManager = (IAirVendorManager)serviceProvider.GetService(typeof(IAirVendorManager));
            bookingRepository = (IBookingRepository)serviceProvider.GetService(typeof(IBookingRepository));
        }

        /// <summary>
        /// This method will be responsible for managing transaction in between 
        /// vendors and ATS and storing booking details into database.
        /// </summary>
        /// <param name="bookingDTO"></param>
        /// <returns></returns>
        public async Task<BookingDTO> CreateBooking(BookingDTO bookingDTO)
        {
            try
            {
                await airVendorManager.ProcessBooking(bookingDTO);

                Models.Booking booking = new Models.Booking()
                {
                    BookingReferenceNumber = bookingDTO.BookingReferenceNumber,
                    BookingAmount = bookingDTO.BookingAmount,
                    BookingDate = DateTime.Now,
                    BookingExternalSeatId = bookingDTO.BookingExternalSeatId,
                    BookingVendorName = bookingDTO.BookingVendorName,
                    BookingStatus = (int)BookingStatus.Confirmed
                };
                
                booking = await bookingRepository.Create(booking);
                bookingDTO.BookingStatus = (int)BookingStatus.Confirmed;
                return bookingDTO;
            }
            catch(Exception)
            {
                throw;
            }
        }
    }
}
