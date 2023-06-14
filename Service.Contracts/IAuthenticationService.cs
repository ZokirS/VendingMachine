using Shared.DataTransferObjects;

namespace Service.Contracts
{
    public interface IAuthenticationService
    {
        bool ValidateUser(UserForAuthenticationDto userForAuth);
        TokenDto CreateToken(bool populateExp);
        TokenDto RefreshToken(TokenDto tokenDto);
    }
}
