using HotelProject.WebUI.Dtos.AboutDto;
using HotelProject.WebUI.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.ServiceDto;
using HotelProject.WebUI.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{

    public class RoomController : Controller
    {

        public IActionResult AddRoom()
        {
            return View();
        }

    }
}