using ATS.Business.Interfaces;
using ATS.UI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using static ATS.Common.ATSEnums;

namespace ATS.UI.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IAirVendorManager airVendorManager;
        private readonly IBookingManager bookingManager;
        public BookingController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            airVendorManager = (IAirVendorManager)serviceProvider.GetService(typeof(IAirVendorManager));
            bookingManager = (IBookingManager)serviceProvider.GetService(typeof(IBookingManager));

        }
        public async Task<IActionResult> Index()
        {
            BookingViewModel bookingViewModel = new BookingViewModel();
            bookingViewModel.AvailableSeats = await airVendorManager.GetAllSeats();

            return View(bookingViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking(BookingViewModel bookingViewModel)
        {
            var bookingDetails = await bookingManager.CreateBooking(new DTO.BookingDTO()
            {
                BookingReferenceNumber = Guid.NewGuid(),
                BookingAmount = int.Parse(string.IsNullOrEmpty(bookingViewModel.TotalAmount) ? "0" : bookingViewModel.TotalAmount),
                BookingDate = DateTime.Now,
                BookingExternalSeatId = Guid.Parse(bookingViewModel.SelectedSeatId),
                BookingVendorName = bookingViewModel.SelectedSeatVendorName
            });

            if ((BookingStatus)bookingDetails.BookingStatus == BookingStatus.Confirmed)
            {
                bookingViewModel.BookingReferenceNumber = bookingDetails.BookingReferenceNumber;
                return RedirectToAction("Confirmation", bookingViewModel);
            }

            return new EmptyResult();
        }

        public async Task<IActionResult> Confirmation(BookingViewModel bookingViewModel)
        {
            return View(bookingViewModel);
        }
    }
}