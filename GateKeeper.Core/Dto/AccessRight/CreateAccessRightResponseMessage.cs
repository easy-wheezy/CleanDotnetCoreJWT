using System.Collections.Generic;
using GateKeeper.Core.Contracts;

namespace GateKeeper.Core.AccessRights.Dto
{
    public class CreateAccessRightResponseMessage: ResponseMessage
    {
        public List<string> Errors { get; private set; }

        public CreateAccessRightResponseMessage(bool success, List<string> errors, string message = null) : base(success, message)
        {
            Errors = errors;
        }
    }
}