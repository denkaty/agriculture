using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Users
{
    public class UserNotFoundException : NotFoundException
    {
        private const string ERROR_MESSAGE = "User not found";
        private const string ERROR_MESSAGE_TEMPLATE = "User not found: '{0}'";

        public UserNotFoundException() : base(ERROR_MESSAGE)
        {
        }

        public UserNotFoundException(string userIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, userIdentifier))
        {
        }
    }
}
