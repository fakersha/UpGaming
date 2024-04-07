using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;


namespace UpGaming.Application.Exceptions
{
    public class AppValidationException : Exception
    {
        public AppValidationException()
            : base("One or more validation failures have occurred.")
        {
            Errors = new Dictionary<string, string[]>();
        }

        public AppValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            Errors = failures
                .GroupBy(e => e.PropertyName, e => e.ErrorMessage)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public AppValidationException(IEnumerable<IdentityError> errors)
            : this()
        {
            Errors = errors.GroupBy(e => e.Code, e => e.Description)
                .ToDictionary(failureGroup => failureGroup.Key, failureGroup => failureGroup.ToArray());
        }

        public IDictionary<string, string[]> Errors { get; }
    }
}
