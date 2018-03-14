using GateKeeper.Core.Companies.Dto;
using GateKeeper.Core.Contracts;
using System.Collections.Generic;
using System.Linq;
using GateKeeper.Core.Entities;

namespace GateKeeper.Core.Companies.Interactor
{
    public class CreateCompanyInteractor :IRequestHandler<CreateCompanyRequestMessage, CreateCompanyResponseMessage>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyInteractor(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public CreateCompanyResponseMessage Handle(CreateCompanyRequestMessage message)
        {
            List<string> errors = new List<string>();

            Company company = new Company()
            {
                Name = message.Name,
                ParentCompanyID = message.ParentCompanyID
            };
            errors.AddRange(_companyRepository.ValidateCompany(company));

            if(!errors.Any())
            {
                _companyRepository.Add(company);
            }

            return new CreateCompanyResponseMessage(!errors.Any(), errors);
                       
        }
    }
}
