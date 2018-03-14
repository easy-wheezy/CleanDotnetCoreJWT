using GateKeeper.Core.Account.Dto;
using GateKeeper.Core.Contracts;
using GateKeeper.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GateKeeper.Core.Account.Interactors
{
    public class RegistrationInteractor : IAsyncRequestHandler<RegistrationRequestMessage, RegistrationResponseMessage>
    {
        private readonly IAccountRepository _accountRepository;
        public RegistrationInteractor(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }
        public async Task<RegistrationResponseMessage> Handle(RegistrationRequestMessage message)
        {
            List<string> errors = new List<string>();

            var userIdentity = new AppUser()
            {
                UserName = message.Email,
                Email = message.Email,
                FirstName = message.FirstName,
                LastName = message.LastName,
                PasswordHash = message.Password
            };

            IdentityResult result =  await _accountRepository.CreateAcount(userIdentity, message.Password);

            if (!result.Succeeded) errors.Add($"Failed to create acount {result.ToString()}");

            return new RegistrationResponseMessage(!errors.Any(), errors);
        }
    }
}
