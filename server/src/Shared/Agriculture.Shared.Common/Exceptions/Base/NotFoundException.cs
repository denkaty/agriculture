using Agriculture.Shared.Common.Models.Enums;

namespace Agriculture.Shared.Common.Exceptions.Base;

public class NotFoundException : BaseException
{
    protected NotFoundException(string message) : base(message, AgricultureStatusCode.NotFound)
    {
    }

    protected NotFoundException(string message, Exception exception) : base(message, exception, AgricultureStatusCode.NotFound)
    {
    }
}
