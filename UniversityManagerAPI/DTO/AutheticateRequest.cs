using System.ComponentModel.DataAnnotations;

namespace UniversityManagerAPI.DTO
{
    public class AutheticateRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
