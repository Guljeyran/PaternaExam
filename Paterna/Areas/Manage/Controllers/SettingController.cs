using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paterna.DAL;
using Paterna.Models;
using System.Data;

namespace Paterna.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]
    public class SettingController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public SettingController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public IActionResult Index()
        {
            List<Setting> settings = _appDbContext.Settings.ToList();
            return View(settings);
        }
        public IActionResult Update(int id)
        {

            Setting setting = _appDbContext.Settings.Find(id);
            if (setting == null) return NotFound();
            return View(setting);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Setting setting)
        {
            if (!ModelState.IsValid) return View();
            Setting existSETTING = _appDbContext.Settings.Find(setting.Id);
            if (existSETTING == null) return NotFound();
            existSETTING.Value = setting.Value;
            _appDbContext.SaveChanges();
            return RedirectToAction("index");

        }
    }
}
