using JWTAuth.Dtos;
using JWTAuth.models;

namespace JWTAuth.services
{
    public interface IAuthService
    {
        public UserReadDto VerifyUser(string email, string password);
        public UserReadDto SignUpUser(UserCore user);
    }
}