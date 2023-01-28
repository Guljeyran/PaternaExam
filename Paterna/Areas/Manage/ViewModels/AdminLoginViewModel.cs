using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using System.ComponentModel.DataAnnotations;
using RequiredAttribute = Microsoft.Build.Framework.RequiredAttribute;

namespace Paterna.Areas.Manage.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 50)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
