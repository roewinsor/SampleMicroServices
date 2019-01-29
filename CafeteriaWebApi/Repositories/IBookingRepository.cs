using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.Models;

namespace CafeteriaWebApi.Repositories
{
    public interface IBookingRepository
    {
        /*IEnumerable<BookingModel> GetAll();
        Booking Get(string id);
        long Add(Booking b);
        long Update(string id, Booking b);
        long Delete(string id);
        */
        Task<IEnumerable<BookingModel>> ReadAllAsync();
        Task<BookingModel> ReadOneAsync(string BookingId);
        Task<BookingModel> CreateAsync(BookingModel booking);
        Task<BookingModel> UpdateAsync(BookingModel booking);
        Task<BookingModel> DeleteAsync(string BookingId);
    }
}
