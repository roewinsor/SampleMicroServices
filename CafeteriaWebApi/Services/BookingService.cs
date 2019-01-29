using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.Models;
using CafeteriaWebApi.Repositories;

namespace CafeteriaWebApi.Services
{
    public class BookingService : IBookingServices
    {

        private readonly IBookingRepository _bookingRepository;

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository ?? throw new ArgumentNullException(nameof(bookingRepository));
   
        }

        public async Task<BookingModel> CreateAsync(BookingModel booking)
        {
            var createdBooking = await _bookingRepository.CreateAsync(booking);
            return createdBooking;
        }

        public Task<BookingModel> DeleteAsync(string BookingId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookingModel>> ReadAllAsync()
        {
            return _bookingRepository.ReadAllAsync();
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
