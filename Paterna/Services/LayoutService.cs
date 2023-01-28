using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Paterna.DAL;
using Paterna.Models;

namespace Paterna.Services
{
    public class LayoutService
    {
        private readonly AppDbContext _appDb;
        private readonly IHttpContextAccessor _httpContext;
        private readonly UserManager<AppUser> _userManager;

        public LayoutService(AppDbContext appDb,IHttpContextAccessor httpContext,UserManager<AppUser> userManager)
        {
            _appDb = appDb;
            _httpContext = httpContext;
            _userManager = userManager;
        }
        public async Task<AppUser> GetUser()
        {
            AppUser user = null;
           
            if (_httpContext.HttpContext.User.Identity.IsAuthenticated)
            {
                user = await _userManager.FindByNameAsync(_httpContext.HttpContext.User.Identity.Name);
                return user;
            }
            return null;
        }
        public async Task<List<Setting>> GetSettingAsync()
        {
            return await _appDb.Settings.ToListAsync();
        }

    }
}
