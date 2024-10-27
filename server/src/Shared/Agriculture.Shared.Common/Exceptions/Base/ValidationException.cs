using Agriculture.Shared.Common.Models.Enums;

namespace Agriculture.Shared.Common.Exceptions.Base
{
    public class ValidationException : BaseException
    {
        public IDictionary<string, string[]> Errors { get; }

        public ValidationException(IDictionary<string, string[]> errors)
           : base("Validation errors occurred.", AgricultureStatusCode.BadRequest)
        {
            Errors = errors;
        }

    }
}
