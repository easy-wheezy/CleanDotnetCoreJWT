using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    [Table("AccessItemType")]
    public class AccessItemType
    {
        [Key]
        public Guid ID { get; set; }
        public string Name { get; set; }
    }
}
