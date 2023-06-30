using CareerOrientation.Application.Common.Validation;

using static CareerOrientation.Application.Common.Validation.ValidationHelper;

using FluentValidation;

namespace CareerOrientation.Application.Tests.Common.Validation;

public class SubmitTestAnswersCommonValidator : AbstractValidator<ISubmitTestCommand>
{
    public SubmitTestAnswersCommonValidator()
    {
        RuleFor(x => x.Answers)
            .NotNull()
            .WithMessage("Πρέπει να δοθούν απαντήσεις")
            .Must(x => x.Any())
            .WithMessage("Πρέπει να δοθούν απαντήσεις");

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