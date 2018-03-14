namespace GateKeeper.Presentation.AccessRights
{
    public class CreateAccessRightResponseVM
    {
        public bool Success { get; private set; }
        public string ResultMessage { get; private set; }

        public CreateAccessRightResponseVM(bool success, string resultMessage)
        {
            Success = success;
            ResultMessage = resultMessage;
        }
    }
}