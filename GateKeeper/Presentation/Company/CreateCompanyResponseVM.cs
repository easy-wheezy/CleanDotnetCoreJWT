using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GateKeeper.Presentation.Company
{
    public class CreateCompanyResponseVM
    {
        public bool Success { get; private set; }
        public string ResultMessage { get; private set; }

        public CreateCompanyResponseVM(bool success, string resultMessage)
        {
            Success = success;
            ResultMessage = resultMessage;
        }
    }
}
