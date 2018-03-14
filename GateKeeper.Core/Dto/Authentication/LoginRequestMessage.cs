using GateKeeper.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GateKeeper.Core.Authentication.Dto
{
    public class LoginRequestMessage : IRequest<LoginResponseMessage>
    {
        public string Email { get; private set; }
        public string Password { get; private set; }

        public LoginRequestMessage(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
