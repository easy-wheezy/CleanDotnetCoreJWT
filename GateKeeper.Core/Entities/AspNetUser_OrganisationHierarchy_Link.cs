using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    [Table("AspNetUser_OrganisationHierarchy_Link")]
    public class AspNetUser_OrganisationHierarchy_Link
    {
        public Guid AspNetUserID { get; set; }
        [ForeignKey("AspNetUserID")]
        public virtual AppUser AspNetUser { get; set; }
        public Guid OrganisationHierarchyID { get; set; }
        [ForeignKey("OrganisationHierarchyID")]
        public virtual OrganisationHierarchy OrganisationHierarchy { get; set; }
    }
}
