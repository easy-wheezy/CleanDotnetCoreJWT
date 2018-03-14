using GateKeeper.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace GateKeeper.Core.Companies.Dto
{
    public class CreateCompanyRequestMessage : IRequest<CreateCompanyResponseMessage>
    {
        public string Name { get; set; }
        public Guid ParentCompanyID { get; set; }

        public CreateCompanyRequestMessage(string name, Guid parentID)
        {
            Name = name;
            ParentCompanyID = parentID;
        }
    }
}
