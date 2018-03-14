using System;

namespace GateKeeper.Presentation.AccessRights
{
    public class CreateAccessRightRequestVM
    {
        public string Name { get; set; }
        public Guid ProductID { get; set; }
    }
}