using GateKeeper.Core.Authentication.Dto;
using GateKeeper.Core.Contracts;
using GateKeeper.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GateKeeper.Core.Authentication.Interactors
{
    public class LoginInteractor: IAsyncRequestHandler<LoginRequestMessage, LoginResponseMessage>
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;

        public LoginInteractor(IAuthenticationService authenticationService, IAccountRepository accountRepository, IJwtFactory jwtFactory, JwtIssuerOptions jwtOptions)
        {
            _authenticationService = authenticationService;
            _accountRepository = accountRepository;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions;
        }
        public async Task<LoginResponseMessage> Handle(LoginRequestMessage message)
        {
            List<string> errors = new List<string>();

            ClaimsIdentity identity = await _authenticationService.GetClaimsIdentity(message.Email, message.Password);

            if (identity == null)
            {
                return new LoginResponseMessage(false, null, new JwtToken(), "Not Authorised");
            }

            JwtToken token = new JwtToken()
            {
                Id = identity.Claims.Single(c => c.Type == "id").Value,
                Auth_Token = await _jwtFactory.GenerateEncodedToken(message.Email, identity),
                ExpiresIn = (int)_jwtOptions.ValidFor.TotalSeconds
            };

            if (!identity.IsAuthenticated) errors.Add($"Failed to login {identity.ToString()}");

            return new LoginResponseMessage(!errors.Any(), errors, token);

        }
    }
}
