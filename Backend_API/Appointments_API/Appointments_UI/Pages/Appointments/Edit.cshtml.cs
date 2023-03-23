using System;
using System.Collections.Generic;
using System.Linq;
using HWK4.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Newtonsoft.Json;
using HWK6.Pages;

namespace HWK6.Pages.Expenditures
{
    using HWK4.Models;

    //Edits the item values
    public class EditModel : PageModel
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
            todo.ID = int.Parse(Request.Form["ID"]);
            todo.ExpenditureType = Request.Form["ExpenditureType"];

            todo.Expenditure = int.Parse(Request.Form["Expenditure"]);

            if (todo.ExpenditureType.Length == 0 || todo.Expenditure==0)
            {
                errorMessage = "Expenditure Type is Required";
            }
            else
            {
                var opt = new JsonSerializerOptions() { WriteIndented = true };
                string json = System.Text.Json.JsonSerializer.Serialize<Expenditures>(todo, opt);

                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:5273");

                    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                    var result = await client.PutAsync("Expenditures", content);
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