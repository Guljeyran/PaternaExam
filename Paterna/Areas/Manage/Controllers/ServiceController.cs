using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Paterna.DAL;
using Paterna.Models;
using System.Data;

namespace Paterna.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "SuperAdmin")]

    public class ServiceController : Controller
    {
        private readonly AppDbContext _appDbContext;

        public ServiceController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            
        }
        public IActionResult Index()
        {
            List<Service> services = _appDbContext.Services.ToList();
            return View(services);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Service service)
        {
            if (!ModelState.IsValid) return View();
            _appDbContext.Services.Add(service);
            _appDbContext.SaveChanges();
            return RedirectToAction("index");
        }
        public IActionResult Update(int id)
        {
            
            Service service = _appDbContext.Services.Find(id);
            if (service == null) return NotFound();
            return View(service);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update(Service service)
        {
            if (!ModelState.IsValid) return View();
            Service existService = _appDbContext.Services.Find(service.Id);
            if (existService == null) return NotFound();
            existService.Title = service.Title;
            existService.Icon = service.Icon;
            existService.Description1 = service.Description1;
            existService.Description2 = service.Description2;
            _appDbContext.SaveChanges();
            return RedirectToAction("index");

        }
        public IActionResult Delete(int id)
        {
            Service service = _appDbContext.Services.Find(id);
            _appDbContext.Services.Remove(service);
            _appDbContext.SaveChanges();
            return RedirectToAction("index");
        }
    }
}
