using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiConsume.Models;
using static RapidApiConsume.Models.BookingApiLocationSearchViewModel;

namespace RapidApiConsume.Controllers
{
    public class SearchLocationIDController : Controller
    {
        private readonly string apiKey = "128bd94e78msh8a7d11cb52bce26p11b9f4jsn6129c3707d09";
        private readonly string apiHost = "booking-com.p.rapidapi.com";

        public async Task<IActionResult> Index(string cityName)
        {
            if (!string.IsNullOrEmpty(cityName))
            {
                // 1. Önce cityName ile dest_id bul
                string destId = await GetDestinationId(cityName);

                if (string.IsNullOrEmpty(destId))
                {
                    ViewBag.Error = "Şehir bulunamadı.";
                    return View(new List<DestinationResult>());
                }

                // 2. Bulunan dest_id ile otel araması yap
                var destinations = await SearchHotels(destId);

                return View(destinations);
            }
            else
            {
                // Eğer kullanıcı cityName girmezse varsayılan şehir (örn. -1456928: Dubai)
                var destinations = await SearchHotels("-1456928");
                return View(destinations);
            }
        }

        private async Task<string> GetDestinationId(string cityName)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://{apiHost}/v1/hotels/locations?name={cityName}&locale=en-gb"),
                    Headers =
                    {
                        { "x-rapidapi-key", apiKey },
                        { "x-rapidapi-host", apiHost },
                    }
                };

                using (var response = await client.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var errorBody = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Location API Error: {response.StatusCode} - {errorBody}");
                    }

                    var body = await response.Content.ReadAsStringAsync();

                    // Response list şeklinde geliyor
                    var locationResponse = JsonConvert.DeserializeObject<List<dynamic>>(body);
                    if (locationResponse != null && locationResponse.Any())
                    {
                        return locationResponse[0].dest_id; // ilk sonucu al
                    }
                }
            }

            return null;
        }

        private async Task<List<DestinationResult>> SearchHotels(string destId)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri($"https://{apiHost}/v2/hotels/search?checkout_date=2026-02-01&filter_by_currency=AED&order_by=popularity&dest_id={destId}&children_ages=5%2C0&categories_filter_ids=class%3A%3A2%2Cclass%3A%3A4%2Cfree_cancellation%3A%3A1&locale=en-gb&dest_type=city&units=metric&include_adjacency=true&children_number=2&room_number=1&adults_number=2&page_number=0&checkin_date=2026-01-31"),
                    Headers =
                    {
                        { "x-rapidapi-key", apiKey },
                        { "x-rapidapi-host", apiHost },
                    },
                };

                using (var response = await client.SendAsync(request))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        var errorBody = await response.Content.ReadAsStringAsync();
                        throw new Exception($"Hotel API Error: {response.StatusCode} - {errorBody}");
                    }

                    var body = await response.Content.ReadAsStringAsync();
                    var apiResponse = JsonConvert.DeserializeObject<BookingApiLocationSearchViewModel.DestinationResponse>(body);

                    var destinations = apiResponse?.Results.Select(x => new DestinationResult
                    {
                        Name = x.Name,
                        DestinationId = x.DestinationId ?? $"city::{x.Ufi}"
                    }).ToList();

                    return destinations ?? new List<DestinationResult>();
                }
            }
        }
    }
}