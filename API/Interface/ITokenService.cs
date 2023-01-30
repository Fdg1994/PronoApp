using Infrastructure.Data.Entities;

namespace API.Interface
{
    public interface ITokenService
    {
        string CreateToken(UserEntity user);
    }
}