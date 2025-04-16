using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Users
{
    public class UserCreationException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "User '{0}' creation failed.";

        public UserCreationException(string email) : base(string.Format(ERROR_MESSAGE_TEMPLATE, email)) { }
    }
}
