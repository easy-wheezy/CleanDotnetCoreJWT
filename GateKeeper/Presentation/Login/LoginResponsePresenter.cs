using GateKeeper.Core.Authentication.Dto;
using System.Text;

namespace GateKeeper.Presentation.Login
{
    public class LoginResponsePresenter
    {
        public LoginResponseViewModel Handle(LoginResponseMessage responseMessage)
        {
            if (responseMessage.Success)
            {
                return new LoginResponseViewModel(true, "Login successful!", responseMessage.Token);
            }

            var sb = new StringBuilder();
            sb.AppendLine("Failed to Login");
            foreach (var e in responseMessage.Errors)
            {
                sb.AppendLine(e);
            }

            return new LoginResponseViewModel(false, sb.ToString(), responseMessage.Token);
        }
    }
}
