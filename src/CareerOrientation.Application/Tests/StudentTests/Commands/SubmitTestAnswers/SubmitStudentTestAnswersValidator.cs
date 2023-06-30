using CareerOrientation.Application.Tests.Common.Validation;

using FluentValidation;

namespace CareerOrientation.Application.Tests.StudentTests.Commands.SubmitTestAnswers;

public class SubmitStudentTestAnswersValidator : AbstractValidator<SubmitStudentTestAnswersCommand>
{
    public SubmitStudentTestAnswersValidator()
    {
        Include(new SubmitTestAnswersCommonValidator());
        
        RuleFor(x => x.UniversityTestId)
            .NotNull()
            .WithMessage("Το UniversityTestId είναι απαραίτητο");
    }
}