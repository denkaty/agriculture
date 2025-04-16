using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Users
{
    public class UserInvalidPasswordException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Invalid password for user '{0}'.";

        public UserInvalidPasswordException(string userIdentifier) : base(string.Format(ERROR_MESSAGE_TEMPLATE, userIdentifier))
        {
        }
    }
}
