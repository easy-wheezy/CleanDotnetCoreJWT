using System;
using GateKeeper.Core.Contracts;

namespace GateKeeper.Core.AccessRights.Dto
{
    public class CreateAccessRightRequestMessage: IRequest<CreateAccessRightResponseMessage>
    {
        public string Name { get; private set; }
        public Guid ProductID { get; private set; }

        public CreateAccessRightRequestMessage(string name, Guid productID)
        {
            Name = name;
            ProductID = productID;
        }
        
    }
}