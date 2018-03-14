using GateKeeper.Core.Contracts;
using GateKeeper.Core.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GateKeeper.Gateways
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<AppUser> _userManager;

        public AccountRepository(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IdentityResult> CreateAcount(AppUser user, string password)
        {
            IdentityResult result = await _userManager.CreateAsync(user, password);
            return result;
        }
    }
}
