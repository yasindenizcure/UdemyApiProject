using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Dtos.FollowersDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using static HotelProject.WebUI.Dtos.FollowersDto.ResultTwitterFollowersDto;

namespace HotelProject.WebUI.ViewComponents.Dashboard
{
    public class _DashboardSubscribeCountPartial : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // INSTAGRAM //
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://instagram-scraper-20251.p.rapidapi.com/userinfo/?username_or_id=yasincure_"),
                Headers =
        {
            { "x-rapidapi-key", "128bd94e78msh8a7d11cb52bce26p11b9f4jsn6129c3707d09" },
            { "x-rapidapi-host", "instagram-scraper-20251.p.rapidapi.com" },
        },
            };

            Data model = new Data();

            using (var response = await client.SendAsync(request))
            {
                var body = await response.Content.ReadAsStringAsync();
                var root = JsonConvert.DeserializeObject<Rootobject1>(body);

                ViewBag.v1 = root?.data?.follower_count;
                ViewBag.v2 = root?.data?.following_count;

                model = root?.data;
            }

            // TWİTTER //
            var client2 = new HttpClient();
            var request2 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://twitter241.p.rapidapi.com/user?username=altercure"),
                Headers =
        {
            { "x-rapidapi-key", "128bd94e78msh8a7d11cb52bce26p11b9f4jsn6129c3707d09" },
            { "x-rapidapi-host", "twitter241.p.rapidapi.com" },
        },
            };

            using (var response2 = await client2.SendAsync(request2))
            {
                var body2 = await response2.Content.ReadAsStringAsync();
                var json = JsonConvert.DeserializeObject<dynamic>(body2);
                var twitterRoot = JsonConvert.DeserializeObject<ResultTwitterFollowersDto.Rootobject>(body2);

                ViewBag.v3 = twitterRoot?.result?.data?.user?.result?.legacy?.followers_count;
                ViewBag.v4 = twitterRoot?.result?.data?.user?.result?.legacy?.friends_count;
            }

            // LİNKEDİN //
            var client3 = new HttpClient();
            var request3 = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://fresh-linkedin-scraper-api.p.rapidapi.com/api/v1/user/follower-and-connection?username=yasin-cure"),
                Headers =
    {
        { "x-rapidapi-key", "128bd94e78msh8a7d11cb52bce26p11b9f4jsn6129c3707d09" },
        { "x-rapidapi-host", "fresh-linkedin-scraper-api.p.rapidapi.com" },
    },
            };
            using (var response3 = await client3.SendAsync(request3))
            {
                var body3 = await response3.Content.ReadAsStringAsync();
                var linkedinRoot = JsonConvert.DeserializeObject<ResultLinkedinFollowersDto.Rootobject>(body3);


                if (linkedinRoot?.data != null)
                {
                    ViewBag.v5 = linkedinRoot.data.follower_count;
                    ViewBag.v6 = linkedinRoot.data.connection_count;
                }
            }
            return View(model);
        }
    }
}

