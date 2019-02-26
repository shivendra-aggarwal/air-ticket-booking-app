using ATS.Business.Interfaces;
using ATS.DataAccess.Repositories.Interfaces;
using ATS.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
                    IAirVendor airVendor = await airVendorObjectManager.GetObjectByType(vendor.VendorName) as IAirVendor;

                    if (airVendor != null)
                    {
                        vendor.AvailabilityStatus = await airVendor.CheckAvailability(vendor.AvailabilityTestUrl);
                    }

                    if (vendor.AvailabilityStatus)
                    {
                        ISeats seats = await airVendorObjectManager.GetObjectByType(vendor.VendorName) as ISeats;
                        if(seats != null)
                        {
                            availableSeats.AddRange(await seats.GetAvailableSeats(vendor));
                        }
                        
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }

            return availableSeats;
        }
    }
}
