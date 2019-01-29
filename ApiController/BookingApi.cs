using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CafeteriaService.ApiController
{
    public class BookingApi
    {

        private string _apiBaseURI = "http://localhost:56434/";
        public HttpClient InitializeClient()
        {
            var client = new HttpClient();
            //Passing service base url  
            client.BaseAddress = new Uri(_apiBaseURI);

            client.DefaultRequestHeaders.Clear();
            //Define request data format  
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            return client;

        }
    }
}
