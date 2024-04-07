using FluentValidation;

namespace UpGaming.Application.Commands.UploadUserData
{
    public class UploadUserDataCommandValidator : AbstractValidator<UploadUserDataCommand>
    {
        public UploadUserDataCommandValidator()
        {

            RuleFor(o=> o.Users).NotEmpty();    

            RuleForEach(o => o.Users)
            .Must(user => !string.IsNullOrWhiteSpace(user.FirstName))
            .WithMessage("First name cannot be empty")
            .Must(user => !string.IsNullOrWhiteSpace(user.LastName))
            .WithMessage("Last name cannot be empty")
            .Must(user => !string.IsNullOrWhiteSpace(user.UserName))
            .WithMessage("Username cannot be empty");
        }
    }
}
