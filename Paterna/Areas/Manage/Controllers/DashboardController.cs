using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Paterna.Models;

namespace Paterna.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles ="SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DashboardController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser admin = new AppUser()
        //    {
        //        Fullname = "Ceyran25",
        //        UserName = "Ceyran25"
        //    };
        //    var result = await _userManager.CreateAsync(admin,"Ceyran25");
        //    return Ok(result);
        //}
        //public async Task<IActionResult> CreateRole()
        //{
        //    IdentityRole role = new IdentityRole("SuperAdmin");
        //    await _roleManager.CreateAsync(role);
        //    return Ok("Created");
        //}
        //public async Task<IActionResult> AddRole()
        //{
        //    AppUser appUser = await _userManager.FindByNameAsync("SuperAdmin");
        //    _userManager.AddToRoleAsync(appUser, "SuperAdmin");
        //    return Ok("Added");
        //}
    }
}
