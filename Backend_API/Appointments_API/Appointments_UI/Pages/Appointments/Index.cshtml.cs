using System;
using System.Collections.Generic;
using System.Linq;
using Appointments_API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Newtonsoft.Json;

namespace AppointmentsDetails.Pages.Appointments
{
    using Appointments_API.Models;
    public class IndexModel : PageModel
    {
        public List<Appointments> Appointments = new();

        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                //HTTP GET
                var responseTask = client.GetAsync("Appointment");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();

                    Appointments = JsonConvert.DeserializeObject<List<Appointments>>(readTask);
                }

            }

        }
    }
}
