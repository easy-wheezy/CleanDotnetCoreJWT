using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    [Table("AspNetUser_UserGroup_Link")]
    public class AspNetUser_UserGroup_Link 
    {
        public Guid AspNetUserID { get; set; }
        [ForeignKey("AspNetUserID")]
        public virtual AppUser AspNetUser { get; set; }
        public Guid UserGroupID { get; set; }
        [ForeignKey("UserGroupID")]
        public virtual UserGroup UserGroup { get; set; }
    }
}
