using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Users
{
    public class UserInvalidResetPasswordTokenException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Invalid reset password token.";

        public UserInvalidResetPasswordTokenException() : base(ERROR_MESSAGE_TEMPLATE)
        {
        }
    }
}
