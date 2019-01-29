using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CafeteriaWebApi.Services;
using CafeteriaWebApi.Models;

namespace CafeteriaWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/Booking")]
    public class BookingController : Controller
    {

        private readonly IBookingServices _bookingService;
        public BookingController(IBookingServices bookingService)
        {
            _bookingService = bookingService ?? throw new ArgumentNullException(nameof(bookingService));
        }

        // GET: api/Booking
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<BookingModel>), StatusCodes.Status200OK)]
        public async Task<IActionResult> ReadAllAsync()
        {
            var allBooking = await _bookingService.ReadAllAsync();
            return Ok(allBooking);
        }

        [HttpPost]
        [ProducesResponseType(typeof(BookingModel), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAsync([FromBody]BookingModel booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdBooking = await _bookingService.CreateAsync(booking);
            return Ok(createdBooking);
         
        }
        /*
        // POST: api/Booking
        [HttpPost]
        public void Post([FromBody]BookingModel booking)
        {
            _bookingService.Add(booking);
        }
        */
        // GET: api/Booking/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        

        
        // PUT: api/Booking/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
