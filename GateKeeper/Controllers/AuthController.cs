using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GateKeeper.Core.Entities;
using GateKeeper.Core.Contracts;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;
using GateKeeper.Core.Authentication.Interactors;
using Microsoft.AspNetCore.Authorization;
using GateKeeper.Core.Authentication.Dto;
using GateKeeper.Presentation.Login;

namespace GateKeeper.Controllers
{
    [Produces("application/json")]
    [Route("api/Auth")]
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly JsonSerializerSettings _serializerSettings;
        private readonly IAccountRepository _accountRepository;
        private readonly IAuthenticationService _authenticationService;
        private readonly IJwtFactory _jwtFactory;
        private readonly JwtIssuerOptions _jwtOptions;


        public AuthController(IAuthenticationService authenticationService, IAccountRepository accountRepository,
            UserManager<AppUser> userManager, IJwtFactory jwtFactory, IOptions<JwtIssuerOptions> jwtOptions)
        {
            _userManager = userManager;
            _accountRepository = accountRepository;
            _authenticationService = authenticationService;
            _jwtFactory = jwtFactory;
            _jwtOptions = jwtOptions.Value;
            _serializerSettings = new JsonSerializerSettings
            {
                Formatting = Formatting.Indented
            };
        }
        // POST api/auth/login
        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody]LoginRequestViewModel model)
        {
            LoginInteractor loginRequestInteractor = new LoginInteractor(_authenticationService, _accountRepository, _jwtFactory, _jwtOptions);
            var requestMessage = new LoginRequestMessage(model.Email, model.Password);
            var responseMessage = await loginRequestInteractor.Handle(requestMessage);

            var presenter = new LoginResponsePresenter();

            var viewModel = presenter.Handle(responseMessage);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new OkObjectResult(viewModel);
        }
    }
}