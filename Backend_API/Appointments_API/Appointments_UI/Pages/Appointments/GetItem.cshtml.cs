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
    using Appointments_API.Models;
    // gets the item from the UI and displays the details
    public class GetItemModel : PageModel
    {
        public Appointments ap = new();
            async void OnGet()
            {
                int Id = int.Parse(Request.Form["appointment_id"]);
                using (var client = new HttpClient())
                {
                    var responseTask = client.GetAsync("http://localhost:5071/Appointments/" + Id);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        ap = JsonConvert.DeserializeObject<Appointments>(readTask);
                    }
            }
         }
    }
}
