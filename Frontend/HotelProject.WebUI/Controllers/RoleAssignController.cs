using HotelProject.EntityLayer.Concrete;
using HotelProject.WebUI.Models.Role;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Controllers
{
    [AllowAnonymous]
    public class RoleAssignController : Controller
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public RoleAssignController(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IActionResult Index()
        {
            var values = userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if (user == null)
                return NotFound("Kullanıcı bulunamadı.");

            TempData["userId"] = user.Id;

            var roles = roleManager.Roles.ToList();
            var userRoles = await userManager.GetRolesAsync(user);

            List<RoleAssignViewModel> roleAssignViewModels = new();

            foreach (var item in roles)
            {
                roleAssignViewModels.Add(new RoleAssignViewModel
                {
                    RoleId = item.Id,
                    RoleName = item.Name,
                    RoleExist = userRoles.Contains(item.Name)
                });
            }

            return View(roleAssignViewModels);
        }

        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            var userId = TempData["userId"]?.ToString();

            if (userId == null)
                return BadRequest("User ID bulunamadı.");

            var user = await userManager.FindByIdAsync(userId);

            if (user == null)
                return NotFound("Kullanıcı bulunamadı.");

            foreach (var item in model)
            {
                if (item.RoleExist)
                    await userManager.AddToRoleAsync(user, item.RoleName);
                else
                    await userManager.RemoveFromRoleAsync(user, item.RoleName);
            }

            return RedirectToAction("Index");
        }
    }
}