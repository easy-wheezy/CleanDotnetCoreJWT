using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace GateKeeper.Core.Contracts
{
    public interface IAuthenticationService
    {
        bool IsAuthorized();
        Task<ClaimsIdentity> GetClaimsIdentity(string userName, string password);

    }
}
