using Agriculture.Shared.Common.Models.Enums;

namespace Agriculture.Shared.Common.Exceptions.Base;

public class ForbiddenException : BaseException
{
    protected ForbiddenException(string message) : base(message, AgricultureStatusCode.Forbidden)
    {
    }

    protected ForbiddenException(string message, Exception exception) : base(message, exception, AgricultureStatusCode.Forbidden)
    {
    }
}
