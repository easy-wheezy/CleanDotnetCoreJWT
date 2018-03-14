using GateKeeper.Core.Contracts;
using GateKeeper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GateKeeper.Core.Authentication.Dto
{
    public class LoginResponseMessage : ResponseMessage
    {
        public List<string> Errors { get; private set; }
        public JwtToken Token { get; private set; }

        public LoginResponseMessage(bool success, List<string> errors, JwtToken token, string message = null) : base(success, message)
        {
            Errors = errors;
            Token = token;
        }
        
    }
}
