using Agriculture.Shared.Common.Models.Enums;

namespace Agriculture.Shared.Common.Exceptions.Base
{
    public class BadRequestException : BaseException
    {
        public BadRequestException(string message) : base(message, AgricultureStatusCode.BadRequest)
        {
        }

        public BadRequestException(string message, Exception exception) : base(message, exception, AgricultureStatusCode.BadRequest)
        {
        }
    }

}
