using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using LoginRateAppWebProject.Models;
using System.Net.Http;
using Newtonsoft.Json;
using System.Collections;

namespace LoginRateAppWebProject.Pages.Admin
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }

        public async Task<IActionResult> Index()
        {
            List<Ratings> ratingList = new List<Ratings>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://tcapprateapi.azurewebsites.net/api/Commands"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    ratingList = JsonConvert.DeserializeObject<List<Ratings>>(apiResponse);
                }
            }
            return Page(ratingList);
        }

        public IActionResult Page(List<Ratings> ratingList)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<Ratings> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //IEnumerator IEnumerable.GetEnumerator(Ratings)
        //{
        //    throw new NotImplementedException();
        //}
    }
}