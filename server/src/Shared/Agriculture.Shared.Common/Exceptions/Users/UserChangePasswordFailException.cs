using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Users
{
    public class UserChangePasswordFailException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Unexpected error";

        public UserChangePasswordFailException() : base(ERROR_MESSAGE_TEMPLATE)
        {
        }
    }
}
