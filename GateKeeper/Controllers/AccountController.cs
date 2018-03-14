using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GateKeeper.Core.Entities;
using Microsoft.AspNetCore.Identity;
using GateKeeper.Core.Account.Interactors;
using Newtonsoft.Json;
using GateKeeper.Core.Contracts;
using GateKeeper.Presentation.Authentication;
using GateKeeper.Core.Account.Dto;

namespace GateKeeper.Controllers
{
    [Produces("application/json")]
    [Route("api/Account")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAccountRepository _accountRepository;
        private readonly JsonSerializerSettings _serializerSettings;


        public AccountController(UserManager<AppUser> userManager, IAccountRepository accountRepository)
        {
            _userManager = userManager;
            _accountRepository = accountRepository;
            _serializerSettings = new JsonSerializerSettings()
            {
                Formatting = Formatting.Indented
            };
        }

        // POST api/accounts
        [HttpPost("Create")]
        public async Task<IActionResult> CreateAcount([FromBody]RegistrationRequestViewModel model)
        {
            RegistrationInteractor registrationRequestInteractor = new RegistrationInteractor(_accountRepository);
            var requestMessage = new RegistrationRequestMessage(model.Email, model.Password, model.FirstName, model.LastName);
            var responseMessage = await registrationRequestInteractor.Handle(requestMessage);

            var presenter = new RegistrationResponsePresenter();

            var viewModel = presenter.Handle(responseMessage);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new OkObjectResult(viewModel);
        }

    }
}