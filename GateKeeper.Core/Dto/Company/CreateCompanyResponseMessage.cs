using GateKeeper.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GateKeeper.Core.Companies.Dto
{
    public class CreateCompanyResponseMessage : ResponseMessage
    {
        public List<string> Errors { get; private set; }

        public CreateCompanyResponseMessage(bool success, List<string> errors, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}
