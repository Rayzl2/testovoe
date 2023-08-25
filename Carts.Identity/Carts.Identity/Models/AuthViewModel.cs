using System.ComponentModel.DataAnnotations;

namespace Carts.Identity.Models
{
    public class AuthViewModel
    {
        [Required]
        public string machineId { get; set; }
        [Required]
        public string key { get; set; }
        public string ReturnUrl { get; set; }
    }
}
