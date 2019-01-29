using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.DataEntities;
using CafeteriaWebApi.Models;


namespace CafeteriaWebApi.Mappers
{
    public class BookingEntityToModel : IMapper<Booking, BookingModel>
    {
        public BookingModel Map(Booking entity)
        {
            var booking = new BookingModel
            {
                BookingId = entity.BookingId,
                ReferenceId = entity.ReferenceId,
                CustomerName = entity.CustomerName,
                BookingDate = entity.BookingDate,
                TotalPersons = entity.TotalPersons,
                ContactNumber = entity.ContactNumber,
                Email = entity.Email,
                Message = entity.Message,
                BookingStatus = new BookingStatusModel {
                    StatusDate =entity.BookingStatus.StatusDate,
                    StatusName = entity.BookingStatus.StatusName,
                    StatusDescription = entity.BookingStatus.StatusDescription
                }

            };
            return booking;
        }
    }
}
