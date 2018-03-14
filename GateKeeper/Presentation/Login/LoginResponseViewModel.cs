using GateKeeper.Core.Entities;

namespace GateKeeper.Presentation.Login
{
    public class LoginResponseViewModel
    {
        public bool Success { get; private set; }
        public string ResultMessage { get; private set; }
        public string Id { get; private set; }
        public string Auth_Token { get; private set; }
        public int ExpiresIn { get; private set; }

        public LoginResponseViewModel(bool success, string resultMessage, JwtToken token)
        {
            Success = success;
            ResultMessage = resultMessage;
            Id = token.Id;
            Auth_Token = token.Auth_Token;
            ExpiresIn = token.ExpiresIn;
        }
    }
}
