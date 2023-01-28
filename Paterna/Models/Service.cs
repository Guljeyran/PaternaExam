using System.ComponentModel.DataAnnotations;

namespace Paterna.Models
{
    public class Service
    {
        public int Id { get; set; }
        [StringLength(maximumLength:200)]
        public string Icon { get; set; }
        [StringLength(maximumLength: 50)]
        public string Title { get; set; }
        [StringLength(maximumLength: 150)]
        public string Description1 { get; set; }
        [StringLength(maximumLength: 150)]
        public string Description2 { get; set; }
    }
}
