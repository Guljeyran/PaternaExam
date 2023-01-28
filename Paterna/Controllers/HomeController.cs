using Microsoft.AspNetCore.Mvc;
using Paterna.DAL;
using Paterna.Models;
using System.Diagnostics;

namespace Paterna.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _appDb;

        public HomeController(AppDbContext appDb)
        {
            _appDb = appDb;
        }
        public IActionResult Index()
        {
            List<Service> services = _appDb.Services.ToList();
            return View(services);
        }

        
    }
}