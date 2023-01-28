using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Paterna.Models
{
    public class AppUser :IdentityUser
    {
        [StringLength(maximumLength:50)]
        public string Fullname { get; set; }
    }
}
