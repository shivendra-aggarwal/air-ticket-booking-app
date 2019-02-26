using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static API.GoAir.Data.Enumerations.GoAirEnums;

namespace API.GoAir.Data
{
    public class InitializeDb
    {
        public static void LoadSeats(GoAirDbContext context)
        {
            int count = 0;
            if (!context.Seats.Any())
            {
                context.Seats.Add(new Models.Seat()
                {
                    SeatId = ++count,
                    Date = DateTime.Now.AddDays(1),
                    BasePrice = 200,
                    FromCity = CityName.Delhi.ToString(),
                    ToCity = CityName.Pune.ToString(),
                    FlightNumber = "GA-1012",
                    SeatType = SeatType.Window.ToString(),
                    SeatNumber = 34,
                    ExternalId = Guid.NewGuid(),
                    VendorName = VendorName.GirAir.ToString()
                });

                context.Seats.Add(new Models.Seat()
                {
                    SeatId = ++count,
                    Date = DateTime.Now.AddDays(2),
                    BasePrice = 300,
                    FromCity = CityName.Delhi.ToString(),
                    ToCity = CityName.Pune.ToString(),
                    FlightNumber = "GA-1012",
                    SeatType = SeatType.Aisle.ToString(),
                    SeatNumber = 33,
                    ExternalId = Guid.NewGuid(),
                    VendorName = VendorName.GirAir.ToString()
                });
                context.Seats.Add(new Models.Seat()
                {
                    SeatId = ++count,
                    Date = DateTime.Now.AddDays(1),
                    BasePrice = 300,
                    FromCity = CityName.Delhi.ToString(),
                    ToCity = CityName.Bengaluru.ToString(),
                    FlightNumber = "GA-1022",
                    SeatType = SeatType.Window.ToString(),
                    SeatNumber = 21,
                    ExternalId = Guid.NewGuid(),
                    VendorName = VendorName.GirAir.ToString()
                });
                context.Seats.Add(new Models.Seat()
                {
                    SeatId = ++count,
                    Date = DateTime.Now.AddDays(1),
                    BasePrice = 400,
                    FromCity = CityName.Delhi.ToString(),
                    ToCity = CityName.Chennai.ToString(),
                    FlightNumber = "GA-1019",
                    SeatType = SeatType.Window.ToString(),
                    SeatNumber = 20,
                    ExternalId = Guid.NewGuid(),
                    VendorName = VendorName.GirAir.ToString()
                });

                //context.Seats.Add(new Models.Seat()
                //{
                //    SeatId = ++count,
                //    Date = DateTime.Now.AddDays(3),
                //    BasePrice = 250,
                //    FromCity = CityName.Delhi.ToString(),
                //    ToCity = CityName.Pune.ToString(),
                //    FlightNumber = "GA-1012",
                //    SeatType = SeatType.Window.ToString(),
                //    SeatNumber = 31,
                //    ExternalId = Guid.NewGuid(),
                //    VendorName = VendorName.GirAir.ToString()
                //});
                //context.Seats.Add(new Models.Seat()
                //{
                //    SeatId = ++count,
                //    Date = DateTime.Now.AddDays(1),
                //    BasePrice = 150,
                //    FromCity = CityName.Delhi.ToString(),
                //    ToCity = CityName.Chandigarh.ToString(),
                //    FlightNumber = "GA-1049",
                //    SeatType = SeatType.Window.ToString(),
                //    SeatNumber = 18,
                //    ExternalId = Guid.NewGuid(),
                //    VendorName = VendorName.GirAir.ToString()

                //});
                //context.Seats.Add(new Models.Seat()
                //{
                //    SeatId = ++count,
                //    Date = DateTime.Now.AddDays(2),
                //    BasePrice = 180,
                //    FromCity = CityName.Delhi.ToString(),
                //    ToCity = CityName.Chandigarh.ToString(),
                //    FlightNumber = "GA-1049",
                //    SeatType = SeatType.Aisle.ToString(),
                //    SeatNumber = 10,
                //    ExternalId = Guid.NewGuid(),
                //    VendorName = VendorName.GirAir.ToString()
                //});
                //context.Seats.Add(new Models.Seat()
                //{
                //    SeatId = ++count,
                //    Date = DateTime.Now.AddDays(3),
                //    BasePrice = 200,
                //    FromCity = CityName.Delhi.ToString(),
                //    ToCity = CityName.Chandigarh.ToString(),
                //    FlightNumber = "GA-1049",
                //    SeatType = SeatType.Window.ToString(),
                //    SeatNumber = 12,
                //    ExternalId = Guid.NewGuid(),
                //    VendorName = VendorName.GirAir.ToString()
                //});
                //context.Seats.Add(new Models.Seat()
                //{
                //    SeatId = ++count,
                //    Date = DateTime.Now.AddDays(6),
                //    BasePrice = 250,
                //    FromCity = CityName.Delhi.ToString(),
                //    ToCity = CityName.Pune.ToString(),
                //    FlightNumber = "GA-1012",
                //    SeatType = SeatType.Window.ToString(),
                //    SeatNumber = 28,
                //    ExternalId = Guid.NewGuid(),
                //    VendorName = VendorName.GirAir.ToString()
                //});

                context.SaveChanges();
            }
        }

        public static void LoadAllocatedSeats(GoAirDbContext context)
        {
            int count = 0;
            if (!context.AllocatedSeats.Any())
            {
                context.AllocatedSeats.Add(new Models.AllocatedSeat()
                {
                    AllocatedSeatId = ++count,
                    SeatId = 1,
                    ExternalBookingId = Guid.NewGuid()
                });

                context.AllocatedSeats.Add(new Models.AllocatedSeat()
                {
                    AllocatedSeatId = ++count,
                    SeatId = 2,
                    ExternalBookingId = Guid.NewGuid()
                });

                context.SaveChanges();
            }
        }
    }
}
