using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.DataEntities;
using CafeteriaWebApi.Models;
namespace CafeteriaWebApi.Mappers
{
    public class BookingModelToEntities : IMapper<BookingModel, Booking>
    {
        public Booking Map(BookingModel model)
        {
            var bookingEntity = new Booking
            {
                ReferenceId = model.ReferenceId,
                CustomerName = model.CustomerName,
                BookingDate = model.BookingDate,
                TotalPersons = model.TotalPersons,
                ContactNumber = model.ContactNumber,
                Email = model.Email,
                Message = model.Message,
                BookingStatus = new BookingStatus
                {
                    StatusName = model.BookingStatus.StatusName,
                    StatusDescription = model.BookingStatus.StatusDescription
                }


            };
            return bookingEntity;
        }
    }
}
