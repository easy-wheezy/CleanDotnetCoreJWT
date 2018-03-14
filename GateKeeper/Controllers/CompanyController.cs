
using Microsoft.AspNetCore.Mvc;
using GateKeeper.Core.Contracts;
using Microsoft.AspNetCore.Authorization;
using GateKeeper.Presentation.Company;
using GateKeeper.Core.Companies.Dto;
using GateKeeper.Core.Companies.Interactor;

namespace GateKeeper.Controllers
{
    [Produces("application/json")]
    [Route("Company")]
    public class CompanyController : Controller
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyController(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }
        [HttpPost]
        [Authorize(Policy = "Company Admin")]
        public ActionResult CreateCompany([FromBody]CreateCompanyRequestVM model)
        {
            CreateCompanyInteractor createCompanyInteractor = new CreateCompanyInteractor(_companyRepository);
            var requestMessage = new CreateCompanyRequestMessage(model.Name, model.ParentID);
            var responseMessage = createCompanyInteractor.Handle(requestMessage);

            var presenter = new CreateCompanyPresenter();

            var viewModel = presenter.Handle(responseMessage);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            return new OkObjectResult(viewModel);
        }
    }
}