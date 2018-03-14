using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GateKeeper.Core.Entities
{
    [Table("AspNetUser_Product_Link")]
    public class AspNetUser_Product_Link
    {
        public Guid AspNetUserID { get; set; }
        [ForeignKey("AspNetUserID")]
        public virtual AppUser AspNetUser { get; set; }
        public Guid ProductID { get; set; }
        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
