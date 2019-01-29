using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.Mappers;
using CafeteriaWebApi.Models;
using CafeteriaWebApi.DataEntities;

namespace CafeteriaWebApi.Services
{
    public interface IBookingMappingServices : IMapper<BookingModel, Booking>, IMapper<Booking, BookingModel>, IMapper<IEnumerable<Booking>, IEnumerable<BookingModel>>
    {
    }
}
