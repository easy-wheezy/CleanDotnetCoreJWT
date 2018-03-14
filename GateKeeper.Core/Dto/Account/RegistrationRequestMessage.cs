using GateKeeper.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GateKeeper.Core.Account.Dto
{
    public class RegistrationRequestMessage: IRequest<RegistrationResponseMessage>
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }

        public RegistrationRequestMessage(string email, string password, string firstName, string lastName)
        {
            Email = email;
            Password = password;
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
