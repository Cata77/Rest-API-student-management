using System.ComponentModel.DataAnnotations;

namespace UniversityManagerAPI.DTO
{
    public class UserCreateRequest
    {
        [Required]
        public string Username {  get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
}
