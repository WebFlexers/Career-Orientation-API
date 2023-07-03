using CareerOrientation.Application.Common.Validation;

using FluentValidation;

using static CareerOrientation.Application.Common.Validation.ValidationHelper;

namespace CareerOrientation.Application.Statistics.Commands;

public class IncrementTeachingAccessStatValidator : AbstractValidator<IncrementTeachingAccessStatCommand>
{
    public IncrementTeachingAccessStatValidator()
    {
        RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage(ValidationMessages.UserIdCantBeEmpty);
        
        RuleFor(x => x.Semester)
            .Must(semester => BeValidSemester(semester))
            .WithMessage(ValidationMessages.InvalidSemester);
    }
}