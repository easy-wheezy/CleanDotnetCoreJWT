using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;

namespace GateKeeper.Core.Entities
{
    public class JwtToken
    {
        public string Id { get; set; }
        public string Auth_Token { get; set; }
        public int ExpiresIn { get; set; }  
    }
}
