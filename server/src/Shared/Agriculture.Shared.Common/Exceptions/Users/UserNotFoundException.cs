using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Users
{
    public class UserNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "User '{0}' is not found.";

        public UserNotFoundException(string userIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, userIdentifier))
        {
        }
    }
}
