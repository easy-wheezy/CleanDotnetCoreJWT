using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Guid? AccessItemID { get; set; }
        [ForeignKey("AccessItemID")]
        public virtual AccessItem AccesItem { get; set; }
    }
}
