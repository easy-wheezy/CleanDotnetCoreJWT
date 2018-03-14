using GateKeeper.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GateKeeper.Core.Account.Dto
{
    public class RegistrationResponseMessage : ResponseMessage
    {
        public List<string> Errors { get; private set; }
        public RegistrationResponseMessage(bool success, List<string> errors, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
