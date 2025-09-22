using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using static RapidApiConsume.Models.ExchangeViewModel;

namespace RapidApiConsume.Controllers   
{
    public class ExchangeController : Controller
    {
        List<ExchangeViewModel.Exchange_Rates> exchange_Rates = new List<ExchangeViewModel.Exchange_Rates>();
        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://booking-com15.p.rapidapi.com/api/v1/meta/getExchangeRates?base_currency=TRY"),
                Headers =
    {
        { "x-rapidapi-key", "128bd94e78msh8a7d11cb52bce26p11b9f4jsn6129c3707d09" },
        { "x-rapidapi-host", "booking-com15.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                System.Diagnostics.Debug.WriteLine(body);
                var values = JsonConvert.DeserializeObject<ExchangeViewModel>(body);
                return View(values?.Data?.ExchangeRates?.ToList() ?? new List<ExchangeViewModel.Exchange_Rates>());
            }
        }
    }
}
