using UniversityManagerAPI.Entities;

namespace UniversityManagerAPI.Auth
{
    public interface IJwtUtils
    {
        public string GenerateJwtToken(User user);
        public int? ValidateJwtToken(string token);
    }
}
