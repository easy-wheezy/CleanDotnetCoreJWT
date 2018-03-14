using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    public class Product : BaseAccessEntity
    {
        public string Name { get; set; }
        public Guid CompanyID { get; set; }
        [ForeignKey("CompanyID")]
        public virtual Company Company { get; set; }
    }
}
