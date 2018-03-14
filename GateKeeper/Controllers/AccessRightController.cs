using GateKeeper.Core.AccessRights.Dto;
using GateKeeper.Core.AccessRights.Interactors;
using GateKeeper.Core.Account.Dto;
using GateKeeper.Core.Account.Interactors;
using GateKeeper.Core.Contracts;
using GateKeeper.Presentation.AccessRights;
using GateKeeper.Presentation.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace GateKeeper.Controllers
{
    [Route("AccessRights")]
    public class AccessRightController : Controller
    {
        private readonly IAccessRightRepository _accessRightRepository;

        public AccessRightController(IAccessRightRepository accessRightRepository)
        {
            _accessRightRepository = accessRightRepository;
        }
        // GET
        [HttpPost("AddNew")]
        public IActionResult AddAccessRight([FromBody]CreateAccessRightRequestVM model)
        {
            AccessRightInteractor accessRightInteractor = new AccessRightInteractor(_accessRightRepository);
            var requestMessage = new CreateAccessRightRequestMessage(model.Name, model.ProductID);
            var responseMessage = accessRightInteractor.Handle(requestMessage);

            var presenter = new CreateAccessRightPresenter();

            var viewModel = presenter.Handle(responseMessage);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new OkObjectResult(viewModel);
        }
    }
}