
//C# backend code for edit page implementation 
using System;
using System.Collections.Generic;
using System.Linq;
using Appointments_API.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Newtonsoft.Json;
using HWK6.Pages;
using Appointments_API;

namespace Appointments_UI.Pages.Appointments
{
    using Appointments_API.Models;

    //Edits the item values
    public class EditModel : PageModel
    {
        public Appointments todo = new();
        public string errorMessage = "";
        public string successMessage = "";

        public async void OnGet()
        {
            string id = Request.Query["appointment_id"];
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5053");
                //HTTP GET
                var responseTask = client.GetAsync("Appointments/" + id);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    todo = JsonConvert.DeserializeObject<Appointments>(readTask);
                }
            }
        }

        public async void OnPost()
        {

            todo.appointment_id = int.Parse(Request.Form["appointment_id"]);
            todo.doctor_id = int.Parse(Request.Form["appointment_id"]);
            todo.patient_id = int.Parse(Request.Form["appointment_id"]);
            todo.appointment_time = DateTime.Parse(Request.Form["appointment_time"]);
            todo.patient_name = Request.Form["patient_name"];
            todo.doctor_name = Request.Form["doctor_name"];
            todo.doctor_department = Request.Form["doctor_department"];
            todo.patient_disease = Request.Form["patient_disease"];

            todo.patient_age = int.Parse(Request.Form["patient_age"]);

            if (todo.appointment_time == null)
            {
                errorMessage = "Appointment Time is Required";
            }
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize<Appointments>(todo, opt);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5053");

                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var result = await client.PutAsync("Appointments", content);
                    string resultContent = await result.Content.ReadAsStringAsync();
                    Console.WriteLine(resultContent);

                    if (!result.IsSuccessStatusCode) {
                        errorMessage = "Error editing";
                    } else {
                        successMessage = "Successfully edited";
                    }
                }
            }
        }
    }
}
