using tinker.Domain.Entities.Identity;

namespace tinker.Application.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
