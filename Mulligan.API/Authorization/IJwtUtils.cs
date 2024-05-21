using Mulligan.API.Models.Domain;

namespace Mulligan.API.Authorization
{
    public interface IJwtUtils
    {
        public string GenerateToken(User user);
        public int? ValidateToken(string token);
    }
}
