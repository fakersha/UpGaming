using FluentValidation;

namespace UpGaming.Application.Commands.UploadUserScores
{
    public class UploadUserScoresCommandValidator : AbstractValidator<UploadUserScoresCommand>
    {
        public UploadUserScoresCommandValidator()
        {
            RuleFor(o=>o.UserScores).NotEmpty();
        }
    }
}
