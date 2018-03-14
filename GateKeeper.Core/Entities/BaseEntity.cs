using System;
using System.Collections.Generic;
using System.Text;

namespace GateKeeper.Core.Entities
{
    public class BaseEntity
    {
        public Guid ID { get; set; }
        public DateTimeOffset LatestUpdatedDate { get; set; }
        public DateTimeOffset CreatedDate { get; set; }
    }
}
