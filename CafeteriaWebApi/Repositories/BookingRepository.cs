using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.Models;
using System.Transactions;
using Microsoft.EntityFrameworkCore;
using CafeteriaWebApi.DataEntities;
using CafeteriaWebApi.Services;

namespace CafeteriaWebApi.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IBookingMappingServices _bookingMappingService;
        CafeteriaContext ctx;
        public BookingRepository(CafeteriaContext c, IBookingMappingServices bookingMappingService)
        {
            ctx = c;
            _bookingMappingService = bookingMappingService ?? throw new ArgumentNullException(nameof(bookingMappingService));
        }

        public async Task<BookingModel> CreateAsync(BookingModel booking)
        {

            var bookingToCreate = _bookingMappingService.Map(booking);
            ctx.Booking.Add(bookingToCreate);
            await ctx.SaveChangesAsync();
            var createdBooking = _bookingMappingService.Map(bookingToCreate);
            return createdBooking;
        }

        public Task<BookingModel> DeleteAsync(string BookingId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<BookingModel>> ReadAllAsync()
        {
            var bookings = await ctx.Booking
                   .Include(bs => bs.BookingStatus)
                    .ToListAsync();
            var retriveBookings = _bookingMappingService.Map(bookings);
            return retriveBookings;
        }

        public Task<BookingModel> ReadOneAsync(string BookingId)
        {
            throw new NotImplementedException();
        }

        public Task<BookingModel> UpdateAsync(BookingModel booking)
        {
            throw new NotImplementedException();
        }
    }
}
