using CareerOrientation.Application.Common.Validation;

using FluentValidation;

using static CareerOrientation.Application.Common.Validation.ValidationHelper;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.StudentTestsQuestions;

public class StudentTestsQuestionsValidator : AbstractValidator<StudentTestsQuestionsQuery>
{
    public StudentTestsQuestionsValidator()
    {
        RuleFor(x => x)
            .Must(x => 
                (x.Semester is not null && x.RevisionYear is null) || 
                (x.RevisionYear is not null && x.Semester is null))
            .WithErrorCode("WrongArguments")
            .WithMessage("Πρέπει να δοθεί τιμή είτε στο εξάμηνο είτε στο επαναληπτικό, αλλά όχι και στα δύο");

        When(x => x.Semester is not null, () =>
        {
            RuleFor(x => x.Semester)
                .Must(BeValidSemester)
                .WithMessage(ValidationMessages.InvalidSemester);

            When(x => x.Semester >= 5, () =>
            {
                RuleFor(x => x.Track)
                    .NotEmpty()
                    .WithMessage(ValidationMessages.MustSupplyTrackAboveSemester4)
                    .Must(BeValidTrack)
                    .WithMessage(ValidationMessages.InvalidTrack);
            });
        });
        
        When(x => x.RevisionYear is not null, () =>
        {
            RuleFor(x => x.RevisionYear)
                .Must(BeValidRevisionYear)
                .WithMessage(ValidationMessages.InvalidRevisionYear);

            When(x => x.RevisionYear >= 3, () =>
            {
                RuleFor(x => x.Track)
                    .NotEmpty()
                    .WithMessage(ValidationMessages.MustSupplyTrackAboveYear2)
                    .Must(BeValidTrack)
                    .WithMessage(ValidationMessages.InvalidTrack);
            });
        });
    }
}