using GateKeeper.Core.Companies.Dto;
using System.Text;

namespace GateKeeper.Presentation.Company
{
    public class CreateCompanyPresenter
    {
        public CreateCompanyResponseVM Handle(CreateCompanyResponseMessage responseMessage)
        {
            if (responseMessage.Success)
            {
                return new CreateCompanyResponseVM(true, "Creation Successful!");
            }

            var sb = new StringBuilder();
            sb.AppendLine("Failed to create company");
            foreach (var e in responseMessage.Errors)
            {
                sb.AppendLine(e);
            }

            return new CreateCompanyResponseVM(false, sb.ToString());
        }
    }
}
