using HotelProject.BusinessLayer.Abstract;
using HotelProject.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AppUserWorkLocationController : ControllerBase
    {
        private readonly IAppUserService _appUserService;
        public AppUserWorkLocationController(IAppUserService appUserService)
        {
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult Index()
        {
            Context context = new Context();
            var values = context.Users.Include(x => x.WorkLocation).Select(y => new
            {
                Name = y.Name,
                Surname = y.Surname,
                WorkLocationId = y.WorkLocationId,
                WorkLocationName = y.WorkLocation.WorkLocationName,
                City = y.City,
                Gender = y.Gender,
                Country = y.Country,
                ImageUrl = y.ImageUrl,
            });
            return Ok(values);
        }
    }
}
