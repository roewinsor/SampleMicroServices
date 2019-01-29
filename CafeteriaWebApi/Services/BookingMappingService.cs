using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaWebApi.Mappers;
using CafeteriaWebApi.DataEntities;
using CafeteriaWebApi.Models;

namespace CafeteriaWebApi.Services
{
    public class BookingMappingService : IBookingMappingServices
    {
        private readonly IMapper<BookingModel, Booking> _bookingModelToBookingEntityMapper;
        private readonly IMapper<Booking, BookingModel> _bookingEntityToBookingModelMapper;
        private readonly IMapper<IEnumerable<Booking>, IEnumerable<BookingModel>> _bookingEntityEnumerableToBookingModelMapper;

        public BookingMappingService(
            IMapper<BookingModel, Booking> bookingModelToBookingEntityMapper,
            IMapper<Booking, BookingModel> bookingEntityToBookingModelMapper,
            IMapper<IEnumerable<Booking>, IEnumerable<BookingModel>> bookingEntityEnumerableToBookingModelMapper
            )
        {
            _bookingModelToBookingEntityMapper = bookingModelToBookingEntityMapper ?? throw new ArgumentNullException(nameof(bookingModelToBookingEntityMapper));
            _bookingEntityToBookingModelMapper = bookingEntityToBookingModelMapper ?? throw new ArgumentNullException(nameof(bookingEntityToBookingModelMapper));
            _bookingEntityEnumerableToBookingModelMapper = bookingEntityEnumerableToBookingModelMapper ?? throw new ArgumentNullException(nameof(bookingEntityEnumerableToBookingModelMapper));

        }

        public Booking Map(BookingModel entity)
        {
            return _bookingModelToBookingEntityMapper.Map(entity);
        }   
    

        public BookingModel Map(Booking entity)
        {
             return _bookingEntityToBookingModelMapper.Map(entity);
        }

        public IEnumerable<BookingModel> Map(IEnumerable<Booking> entity)
        {
            return _bookingEntityEnumerableToBookingModelMapper.Map(entity);
        }
    }



 }




