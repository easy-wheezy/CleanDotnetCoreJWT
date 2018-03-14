using GateKeeper.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GateKeeper.Core.Contracts
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateAcount(AppUser user, string password);
    }
}
