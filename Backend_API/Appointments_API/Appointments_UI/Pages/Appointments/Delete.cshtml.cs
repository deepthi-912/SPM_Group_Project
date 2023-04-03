using System;
using System.Collections.Generic;
using System.Linq;
using Appointments_API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace Appointments_UI.Pages.Appointments
{
    using System.ComponentModel.DataAnnotations;
    using Appointments_API.Models;

    //Deletes an Item
    public class DeleteModel : PageModel
    {
        public Appointment todo = new();
        public string errorMessage = "";
        public string successMessage = "";
        public async void OnGet()
        {

        string id = Request.Query["id"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                //HTTP GET
                var responseTask = client.GetAsync("Appointment/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    todo = JsonConvert.DeserializeObject<Appointment>(readTask);
                }
            }
        }


        public async void OnPost()
        {
            bool isDeleted = false;
            int id = int.Parse(Request.Form["id"]);

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                var response = await client.DeleteAsync("/Appointment/" + id);
                if (response.IsSuccessStatusCode)
                {
                    isDeleted = true;
                }
            }

            if (isDeleted)
            {
                successMessage = "Successfully deleted";
            }
            else
            {
                errorMessage = "Error deleting";
            }
        }
    }
}
