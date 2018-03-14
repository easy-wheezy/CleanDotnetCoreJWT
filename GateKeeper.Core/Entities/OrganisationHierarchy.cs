using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    [Table("OrganisationHierarchy")]
    public class OrganisationHierarchy : BaseAccessEntity
    {
        public string Name { get; set; }
        public Guid ParentID { get; set; }
        [ForeignKey("ParentID")]
        public virtual OrganisationHierarchy Parent { get; set; }
        public Guid CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }
    }
}
