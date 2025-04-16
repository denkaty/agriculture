using Agriculture.Shared.Common.Models.Enums;

namespace Agriculture.Shared.Common.Exceptions.Base;


public class UnauthorizedException : BaseException
{
    protected UnauthorizedException(string message) : base(message, AgricultureStatusCode.Unauthorized)
    {
    }

    protected UnauthorizedException(string message, Exception exception) : base(message, exception, AgricultureStatusCode.Unauthorized)
    {
    }
}
