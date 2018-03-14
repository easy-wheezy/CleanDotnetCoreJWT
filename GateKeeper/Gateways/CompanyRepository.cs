using GateKeeper.Core.Contracts;
using GateKeeper.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GateKeeper.Gateways
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext context) : base(context) { }

        public List<string> ValidateCompany(Company company)
        {
            List<string> errors = new List<string>();
            if(!dbset.Any(com => com.Name == company.Name))
                errors.Add("Company name already taken");

            return errors;
        }
    }
}
