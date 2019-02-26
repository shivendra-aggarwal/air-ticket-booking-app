using ATS.Business.AirVendors.GoAir.Data;
using ATS.Business.Interfaces;
using ATS.DTO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Threading.Tasks;
using System.Linq;

namespace ATS.Business.AirVendors.GoAir
{
    public class GoAirAirlines : BaseAirVendor, IAirVendor, ISeats
    {
        public async Task<IEnumerable<SeatDTO>> GetAvailableSeats(AirVendorDTO airVendorDTO)
        {
            IEnumerable<SeatDTO> result = null;
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(airVendorDTO.AccessUrl + "/api/seats");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var goAirSeats = JsonConvert.DeserializeObject<IEnumerable<GoAirSeat>>(jsonString);

                    if(goAirSeats != null && goAirSeats.Any())
                    {
                        result = goAirSeats.Select(g => 
                        new SeatDTO() {
                            ExternalId = g.ExternalId,
                            AvailableDate = g.Date,
                            BasePrice = g.BasePrice,
                            FlightNumber = g.FlightNumber,
                            FromCityName = g.FromCity,
                            ToCityName = g.ToCity,
                            SeatNumber = g.SeatNumber,
                            SeatType = g.SeatType,
                            VendorName = g.VendorName
                        });
                    }
                }
            }

            return result;
        }
    }
}
