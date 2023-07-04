using CareerOrientation.Application.Common.Validation;

using FluentValidation;

namespace CareerOrientation.Application.Statistics.Queries.TeachingAccessStats;

public class TeachingAccessStatsValidator : AbstractValidator<TeachingAccessStatsQuery>
{
    public TeachingAccessStatsValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(ValidationMessages.UserIdCantBeEmpty);
    }
}