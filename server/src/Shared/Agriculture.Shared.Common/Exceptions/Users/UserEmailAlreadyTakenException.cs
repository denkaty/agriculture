using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Users
{
    public class UserEmailAlreadyTakenException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Email '{0}' is already taken.";

        public UserEmailAlreadyTakenException(string email) : base(string.Format(ERROR_MESSAGE_TEMPLATE, email))
        {
        }
       
    }
}
