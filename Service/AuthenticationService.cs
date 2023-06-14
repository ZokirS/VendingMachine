using AutoMapper;
using Entities.ConfigurationModels;
using Entities.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Service.Contracts;
using Shared.DataTransferObjects;

namespace Service
{
    public class AuthenticationService : IAuthenticationService
    {
        private UserManager<User> _userManager;
        private IMapper _mapper;
        private readonly IOptions<JwtConfiguration> _configuration;
        private readonly JwtConfiguration _jwtConfiguration;
        private User? _user;

        public AuthenticationService(IMapper mapper
            ,UserManager<User> userManager, IOptions<JwtConfiguration> configuration)
        {
            _userManager = userManager;
            _mapper = mapper;
            _configuration = configuration;
            _jwtConfiguration = configuration.Value;
        }
        public TokenDto CreateToken(bool populateExp)
        {
            throw new NotImplementedException();
        }

        public TokenDto RefreshToken(TokenDto tokenDto)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(UserForAuthenticationDto userForAuth)
        {
            _user = _userManager.FindByNameAsync(userForAuth.UserName).Result;

            var result = (_user != null &&  _userManager.CheckPasswordAsync(_user, userForAuth.Password).Result);

            return result;
        }
    }
}
