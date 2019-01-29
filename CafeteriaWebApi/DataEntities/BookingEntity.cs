using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CafeteriaWebApi.DataEntities
{
    public class Booking
    {
        public string BookingId { get; set; }
        public string ReferenceId { get; set; }
        public string CustomerName { get; set; }
        public DateTime? BookingDate { get; set; }
        public int TotalPersons { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }

        public BookingStatus BookingStatus { get; set; }
    }


    public class BookingStatus
    {

        public int Id { get; set; }
        public string StatusName { get; set; }
        public string StatusDescription { get; set; }
        public DateTime? StatusDate { get; set; }

        public string BookingId { get; set; }
        public Booking Booking { get; set; }
    }

}
