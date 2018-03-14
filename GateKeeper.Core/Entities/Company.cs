using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    public class Company : BaseEntity
    {
        public string Name { get; set; }
        public Guid ParentCompanyID { get; set; }
        [ForeignKey("ParentCompanyID")]
        public virtual Company ParentCompany { get; set; }
    }
}
