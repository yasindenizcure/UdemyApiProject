using HotelProject.BusinessLayer.Abstract;
using HotelProject.EntityLayer.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public IActionResult GetStaffList()
        {
            var values = _staffService.TGetList();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            _staffService.TInsert(staff);
            return Ok();
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteStaff(int id)
        {
            var values = _staffService.TGetById(id);
            if (values == null)
            {
                return NotFound($"ID {id} numaralı misafir bulunamadı.");
            }
            _staffService.TDelete(values);
            return Ok();
        }
        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id, Staff staff)
        {
            var existingStaff = _staffService.TGetById(id);
            if (existingStaff == null)
                return NotFound();

            existingStaff.Name = staff.Name;
            existingStaff.Title = staff.Title;
            existingStaff.SocialMedia1 = staff.SocialMedia1;
            existingStaff.SocialMedia2 = staff.SocialMedia2;
            existingStaff.SocialMedia3 = staff.SocialMedia3;

            _staffService.TUpdate(existingStaff);
            return Ok();
        }
        [HttpGet("{id}")]
        public IActionResult GetStaff(int id)
        {
            var values = _staffService.TGetById(id);
            return Ok(values);
        }
        [HttpGet("Last4Staff")]
        public IActionResult GetLast4Staff()
        {
            var values = _staffService.TLast4Staff();
            return Ok(values);

        }
    }
}
