using System.Collections.Generic;
using System.Linq;
using GateKeeper.Core.AccessRights.Dto;
using GateKeeper.Core.Contracts;
using GateKeeper.Core.Entities;

namespace GateKeeper.Core.AccessRights.Interactors
{
    public class AccessRightInteractor :IRequestHandler<CreateAccessRightRequestMessage, CreateAccessRightResponseMessage>
    {
        private readonly IAccessRightRepository _accessRightRepository;

        public AccessRightInteractor(IAccessRightRepository accessRightRepository)
        {
            _accessRightRepository = accessRightRepository;
        }
        public CreateAccessRightResponseMessage Handle(CreateAccessRightRequestMessage message)
        {
            List<string> errors = new List<string>();
            AccessRight accessRight = new AccessRight()
            {
                Name = message.Name,
                ProductID = message.ProductID
            };
            errors.AddRange(_accessRightRepository.ValidateAccessRight(accessRight));
            
            if(!errors.Any())
                _accessRightRepository.Add(accessRight);
            
            return new CreateAccessRightResponseMessage(!errors.Any(), errors);
        }
    }

}