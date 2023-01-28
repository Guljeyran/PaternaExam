using System.ComponentModel.DataAnnotations;

namespace Paterna.Models
{
    public class Setting
    {
        public int Id { get; set; }
        [StringLength(maximumLength:50)]
        public string? Key { get; set; }
        [StringLength(maximumLength: 100)]
        public string? Value { get; set; }
    }
}
