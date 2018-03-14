namespace GateKeeper.Presentation.Authentication
{
    public class RegistrationResponseViewModel
    {
        public bool Success { get; private set; }
        public string ResultMessage { get; private set; }

        public RegistrationResponseViewModel(bool success, string resultMessage)
        {
            Success = success;
            ResultMessage = resultMessage;
        }
    }
}
