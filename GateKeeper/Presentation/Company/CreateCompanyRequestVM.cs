using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GateKeeper.Presentation.Company
{
    public class CreateCompanyRequestVM
    {
        public string Name { get; set; }
        public Guid ParentID { get; set; }
    }
}
