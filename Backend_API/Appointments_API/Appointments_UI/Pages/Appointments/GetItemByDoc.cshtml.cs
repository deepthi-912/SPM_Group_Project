using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Appointments_UI.Pages.Appointments
{
    using System.Security.Cryptography;
    using Appointments_API.Models;
    // gets the item from the UI and displays the details
    public class GetItemByDocModel : PageModel
    {
        public List<Appointment> ap = new();
        public async void OnGet()
        {

            string id = Request.Query["dId"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                //HTTP GET
                var responseTask = client.GetAsync("Appointment/Analysis-GetAppointmentsByDoctor?dId=" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    ap = JsonConvert.DeserializeObject<List<Appointment>>(readTask);
                }
            }
        }
    }
}
