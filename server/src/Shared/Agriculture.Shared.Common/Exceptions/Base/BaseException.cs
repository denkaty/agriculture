using Agriculture.Shared.Common.Models.Enums;

namespace Agriculture.Shared.Common.Exceptions.Base
{
    public abstract class BaseException : Exception
    {
        protected BaseException(string message, AgricultureStatusCode statusCode) : base(message)
        {
            Message = message;
            StatusCode = statusCode;
        }

        protected BaseException(string message, Exception exception, AgricultureStatusCode statusCode) : base(message, exception)
        {
            Message = message;
            StatusCode = statusCode;
        }

        public override string Message { get; }
        public AgricultureStatusCode StatusCode { get; }
    }
}
