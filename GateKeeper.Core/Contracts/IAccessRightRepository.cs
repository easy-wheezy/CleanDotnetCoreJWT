using System;
using System.Collections.Generic;
using GateKeeper.Core.Contracts.System;
using GateKeeper.Core.Entities;

namespace GateKeeper.Core.Contracts
{
    public interface IAccessRightRepository : IBaseRepository<AccessRight>
    {
        List<string> ValidateAccessRight(AccessRight accessRight);
    }
}