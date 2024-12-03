using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Users
{
    public class UserPasswordMismatchException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "The new password and confirm password do not match.";

        public UserPasswordMismatchException() : base(ERROR_MESSAGE_TEMPLATE)
        {
        }
    }
}
