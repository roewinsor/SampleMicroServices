using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.Models;

namespace CafeteriaWebApi.Services
{
    public interface IBookingServices
    {
        Task<IEnumerable<BookingModel>> ReadAllAsync();
        Task<BookingModel> ReadOneAsync(string BookingId);
        Task<BookingModel> CreateAsync(BookingModel booking);
        Task<BookingModel> UpdateAsync(BookingModel booking);
        Task<BookingModel> DeleteAsync(string BookingId);
    }
}
