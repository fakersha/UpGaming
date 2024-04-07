using FluentValidation;

namespace UpGaming.Application.Queries.GetScoresByDay
{
    public class GetScoresByDayQueryValidator : AbstractValidator<GetScoresByDayQuery>
    {
        public GetScoresByDayQueryValidator()
        {
            RuleFor(o => o.Day).NotEmpty();
        }
    }
}
