using System;
using System.Collections.Generic;
using System.Linq;
using HWK4.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HWK6.Pages.Expenditures
{
    using HWK4.Models;

    //Deletes an Item
    public class DeleteModel : PageModel
    {
        public Expenditures todo = new();
        public string errorMessage = "";
        public string successMessage = "";
        public async void OnGet()
        {
            string id = Request.Query["id"];

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");
                //HTTP GET
                var responseTask = client.GetAsync("Expenditures/" + id);
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = await result.Content.ReadAsStringAsync();
                    todo = JsonConvert.DeserializeObject<Expenditures>(readTask);
                }
            }
        }


        public async void OnPost()
        {
            bool isDeleted = false;
            int id = int.Parse(Request.Form["id"]);

            using (var client = new HttpClient())
            {
                string Url = "http://localhost:5273/Expenditures";
                var uri = new Uri(string.Format(Url, id));
                var response = client.DeleteAsync(uri).Result;
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