using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Appointments_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace AppointmentsDetails.Pages.Appointments
{
    //Gets the maximum value
	public class AppointmentsCount : PageModel
    {
        public int apcount = new();
        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                //HTTP GET
                var responseTask = client.GetAsync("Appointment/Analysis-GetAppointmentsCount");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    apcount = JsonConvert.DeserializeObject<int>(readTask);
                }
            }
        }
    }
}
