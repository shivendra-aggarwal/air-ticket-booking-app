using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ATS.Business.AirVendors.GoAir;
using ATS.Business.Interfaces;
using ATS.UI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ATS.UI.Controllers
{
    public class BookingController : BaseController
    {
        private readonly IServiceProvider serviceProvider;
        private readonly IAirVendorManager airVendorManager;
        public BookingController(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
            airVendorManager = (IAirVendorManager)serviceProvider.GetService(typeof(IAirVendorManager));

        }
        public async Task<IActionResult> Index()
        {
            BookingViewModel bookingViewModel = new BookingViewModel();
            bookingViewModel.AvailableSeats = await airVendorManager.GetAllSeats();
            
            return View(bookingViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateBooking([FromBody]BookingViewModel bookingViewModel)
        {
            return new EmptyResult();
        }
    }
}