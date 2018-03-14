
using GateKeeper.Core.Account.Dto;
using System.Text;

namespace GateKeeper.Presentation.Authentication
{
    public class RegistrationResponsePresenter
    {
        public RegistrationResponseViewModel Handle(RegistrationResponseMessage responseMessage)
        {
            if (responseMessage.Success)
            {
                return new RegistrationResponseViewModel(true, "Registration successful!");
            }

            var sb = new StringBuilder();
            sb.AppendLine("Failed to Register");
            foreach (var e in responseMessage.Errors)
            {
                sb.AppendLine(e);
            }

            return new RegistrationResponseViewModel(false, sb.ToString());
        }
    }
}
