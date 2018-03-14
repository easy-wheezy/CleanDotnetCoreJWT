using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    [Table("AccesItem")]
    public class AccessItem:BaseEntity
    {
        public Guid AccessItemTypeID { get; set; }
        [ForeignKey("AccessItemTypeID")]
        public virtual AccessItemType AccessItemType { get; set; }
    }
}
