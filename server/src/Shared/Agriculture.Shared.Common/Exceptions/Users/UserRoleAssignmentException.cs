using Agriculture.Shared.Common.Exceptions.Base;

namespace Agriculture.Shared.Common.Exceptions.Users
{
    public class UserRoleAssignmentException : BadRequestException
    {
        private const string ERROR_MESSAGE_TEMPLATE = "Failed to assign role '{0}' to user with email '{1}'.";

        public UserRoleAssignmentException(string role, string email)
            : base(string.Format(ERROR_MESSAGE_TEMPLATE, role, email)) { }
    }
}
