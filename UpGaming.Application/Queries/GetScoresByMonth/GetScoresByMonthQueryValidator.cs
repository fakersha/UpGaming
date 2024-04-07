using FluentValidation;

namespace UpGaming.Application.Queries.GetScoresByMonth
{
    public class GetScoresByMonthQueryValidator : AbstractValidator<GetScoresByMonthQuery>
    {
        public GetScoresByMonthQueryValidator()
        {
            RuleFor(o => o.Month).NotEmpty();
        }
    }
}
