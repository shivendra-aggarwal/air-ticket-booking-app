using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using ATS.Business.AirVendors.JetAir.Data;
using ATS.Business.Interfaces;
using ATS.DTO;
using Newtonsoft.Json;
using System.Linq;
using ATS.Business.Interfaces.AirVendors;
using System.Text;

namespace ATS.Business.AirVendors.JetAir
{
    public class JetAirAirlines : BaseAirVendor, IAvailable, ISeats, IBookSeat
    {
        /// <summary>
        /// This method will help to check the availability for registered vendor
        /// </summary>
        /// <param name="airVendorDTO"></param>
        /// <returns></returns>
        public async Task<IEnumerable<SeatDTO>> GetAvailableSeats(AirVendorDTO airVendorDTO)
        {
            IEnumerable<SeatDTO> result = null;
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync(airVendorDTO.AccessUrl + "/api/seats");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var goAirSeats = JsonConvert.DeserializeObject<IEnumerable<JetAirSeat>>(jsonString);

                    if (goAirSeats != null && goAirSeats.Any())
                    {
                        result = goAirSeats.Select(g =>
                        new SeatDTO()
                        {
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

        /// <summary>
        /// This method will call respective airline put end point to update seat details against 
        /// booking reference id
        /// </summary>
        /// <param name="bookingDTO"></param>
        /// <returns></returns>
        public async Task<bool> ProcessSeatBooking(BookingDTO bookingDTO)
        {
            bool result = default(bool);
            using (var httpClient = new HttpClient())
            {
                HttpContent content = new StringContent(JsonConvert.SerializeObject(bookingDTO), Encoding.UTF8, "application/json");
                var response = await httpClient.PutAsync(bookingDTO.AccessUrl + "/api/Put", content);
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    var bookingConfirmation = JsonConvert.DeserializeObject<bool>(jsonString);

                    result = bookingConfirmation;
                }
            }

            return result;
        }
    }
}
