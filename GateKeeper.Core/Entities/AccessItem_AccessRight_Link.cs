using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    [Table("AccessItem_AccessRight_Link")]
    public class AccessItem_AccessRight_Link
    {
        public Guid AccessItemID { get; set; }
        [ForeignKey("AccessItemID")]
        public virtual AccessItem AccessItem { get; set; }
        public Guid AccessRightID { get; set; }
        [ForeignKey("AccessRightID")]
        public virtual AccessRight AccessRight { get; set; }
    }
}
