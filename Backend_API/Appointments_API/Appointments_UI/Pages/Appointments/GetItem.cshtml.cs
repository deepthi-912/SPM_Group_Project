using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;

namespace HWK6.Pages.Expenditures
{
    using HWK4.Models;
    // gets the item from the UI and displays the details
    public class GetItemModel : PageModel
    {
        public Expenditures bill = new();
            async void OnGet()
            {
                int Id = int.Parse(Request.Form["Id"]);
                using (var client = new HttpClient())
                {
                    var responseTask = client.GetAsync("http://localhost:5273/Expenditures/" + Id);
                    responseTask.Wait();
                    var result = responseTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = await result.Content.ReadAsStringAsync();
                        bill = JsonConvert.DeserializeObject<Expenditures>(readTask);
                    }
            }
         }
    }
}
