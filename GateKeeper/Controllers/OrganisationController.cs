using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace GateKeeper.Controllers
{
    [Produces("application/json")]
    [Route("api/Organisation")]

    public class OrganisationController : Controller
    {
        [HttpGet("Name")]
        [Authorize(Policy = "ApiUser")]
        public string CompanyName()
        {
            return "Success";
        }
        [HttpGet("Name2")]
        public string CompanyName2()
        {
            return "Success2";
        }
        [HttpGet("Name3")]
        [Authorize()]
        public string CompanyName3()
        {
            return "Success3";
        }
    }
}