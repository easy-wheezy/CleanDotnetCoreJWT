using System.Text;
using GateKeeper.Core.AccessRights.Dto;

namespace GateKeeper.Presentation.AccessRights
{
    public class CreateAccessRightPresenter
    {
        public CreateAccessRightResponseVM Handle(CreateAccessRightResponseMessage responseMessage)
        {
            if (responseMessage.Success)
            {
                return new CreateAccessRightResponseVM(true, "Creation Successful!");
            }

            var sb = new StringBuilder();
            sb.AppendLine("Failed to create company");
            foreach (var e in responseMessage.Errors)
            {
                sb.AppendLine(e);
            }

            return new CreateAccessRightResponseVM(false, sb.ToString());
        }
    }
}