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
    public class BookingController : Controller
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
            var obj = serviceProvider.GetService(typeof(GoAirAirlines));
            var airVendor = obj as IAirVendor;
            BookingViewModel bookingViewModel = new BookingViewModel();
            bookingViewModel.AvailableSeats = await airVendorManager.GetAllSeats();
            
            return View(bookingViewModel);
        }
    }
}