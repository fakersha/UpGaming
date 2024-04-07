using FluentValidation;

namespace UpGaming.Application.Queries.GetUserInfo
{
    public class GetUserInfoQueryValidator : AbstractValidator<GetUserInfoQuery>
    {
        public GetUserInfoQueryValidator()
        {
            RuleFor(o => o.UserId).NotEmpty();
        }
    }
}
