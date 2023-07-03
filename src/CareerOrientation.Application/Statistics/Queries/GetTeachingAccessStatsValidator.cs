using CareerOrientation.Application.Common.Validation;

using FluentValidation;

using static CareerOrientation.Application.Common.Validation.ValidationHelper;

namespace CareerOrientation.Application.Statistics.Queries;

public class GetTeachingAccessStatsValidator : AbstractValidator<GetTeachingAccessStatsQuery>
{
    public GetTeachingAccessStatsValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(ValidationMessages.UserIdCantBeEmpty);
    }
}