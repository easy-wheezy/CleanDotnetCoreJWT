using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    public class BaseAccessEntity : BaseEntity
    {
        public Guid? AccessItemID{ get; set; }
        [ForeignKey("AccessItemID")]
        public virtual AccessItem AccesItem { get; set; }
    }
}
