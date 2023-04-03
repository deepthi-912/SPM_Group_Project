///Importing C# libraries for implementing Index page 
using System;
using System.Collections.Generic;
using System.Linq;
using HWK4.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using Newtonsoft.Json;
///Index Page implementation using HTTP GET method 
namespace HWK6.Pages.Expenditures
{
    using HWK4.Models;
    public class IndexModel : PageModel
    {

        public List<Expenditures> expenditures = new();

        public async void OnGet()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5273");
                
                //HTTP GET
                var responseTask = client.GetAsync("Expenditures");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    var readTask = await result.Content.ReadAsStringAsync();
                    expenditures = JsonConvert.DeserializeObject<List<Expenditures>>(readTask);
                }

            }

        }
    }
}
