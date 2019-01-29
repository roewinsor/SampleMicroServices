using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using CafeteriaService.ApiController;
using Newtonsoft.Json;
using System.Text;
using CafeteriaService.Models;

namespace CafeteriaService.Controllers
{
    public class BookingController : Controller
    {

        BookingApi _bookingApi = new BookingApi();


        // GET: Booking/List
        public async Task<IActionResult> List()
        {

            List<Booking> bookingList = new List<Booking>();

            HttpClient client = _bookingApi.InitializeClient();

            HttpResponseMessage res = await client.GetAsync("api/booking");

            //Checking the response is successful or not which is sent using HttpClient  
            if (res.IsSuccessStatusCode)
            {
                //Storing the response details recieved from web api   
                var result = res.Content.ReadAsStringAsync().Result;

                //Deserializing the response recieved from web api and storing into the  list  
                bookingList = JsonConvert.DeserializeObject<List<Booking>>(result);

            }
            //returning the  list to view  
            return View(bookingList);
   
        }


        // GET: Booking/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Booking/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Name,CustomerName,BookingDate,TotalPersons,ContactNumber,Email,Message")] Booking booking )
        {
            booking.ReferenceId = Convert.ToBase64String(Guid.NewGuid().ToByteArray()).Substring(0, 4).ToUpper();
            booking.BookingStatus = new BookingStatus { StatusName = "Pending", StatusDescription = "For Review" };

            if (ModelState.IsValid)
            {
                HttpClient client = _bookingApi.InitializeClient();
                
                var content = new StringContent(JsonConvert.SerializeObject(booking), Encoding.UTF8, "application/json");
                HttpResponseMessage res = client.PostAsync("api/booking", content).Result;
                if (res.IsSuccessStatusCode)
                {
                    ViewData["Message"] = "Success";
                    return View(booking);
                }
            }
            return View(booking);
        }
    }
}