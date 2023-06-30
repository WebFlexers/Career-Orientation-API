using CareerOrientation.Application.Common.Validation;

using FluentValidation;

using static CareerOrientation.Application.Common.Validation.ValidationHelper;

namespace CareerOrientation.Application.StudentTests.Commands.SubmitTestAnswers;

public class SubmitTestAnswersValidator : AbstractValidator<SubmitTestAnswersCommand>
{
    public SubmitTestAnswersValidator()
    {
        RuleFor(x => x.UniversityTestId)
            .NotNull()
            .WithMessage("Το UniversityTestId είναι απαραίτητο");

        RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("Το UserId είναι απαραίτητο");

        RuleForEach(x => x.Answers).ChildRules(answer =>
        {
            answer.RuleFor(a => a)
                .Must(a =>
                    (a.LikertScaleAnswer is not null &&
                     a.MultipleChoiceAnswerId is null &&
                     a.TrueOrFalseAnswer is null)
                    ||
                    (a.LikertScaleAnswer is null &&
                     a.MultipleChoiceAnswerId is not null &&
                     a.TrueOrFalseAnswer is null)
                    ||
                    (a.LikertScaleAnswer is null &&
                     a.MultipleChoiceAnswerId is null &&
                     a.TrueOrFalseAnswer is not null))
                .WithMessage("Σε κάθε ερώτηση πρέπει να δίνεται μόνο ένας τύπος απάντησης: Είτε LikertScaleAnswer, είτε " +
                             "MultipleChoiceAnswerId, είτε TrueFalseAnswer");

            answer.When(a => a.LikertScaleAnswer is not null, () =>
            {
                answer.RuleFor(a => a.LikertScaleAnswer)
                    .Must(BeValidLikertScaleAnswer)
                    .WithMessage(ValidationMessages.InvalidLikertScaleAnswer);
            });
        });
    }
}