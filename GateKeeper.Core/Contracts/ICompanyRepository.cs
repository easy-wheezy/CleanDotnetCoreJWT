using GateKeeper.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using GateKeeper.Core.Contracts.System;

namespace GateKeeper.Core.Contracts
{
    public interface ICompanyRepository : IBaseRepository<GateKeeper.Core.Entities.Company>
    {
        List<string> ValidateCompany(Company company);
    }
}
