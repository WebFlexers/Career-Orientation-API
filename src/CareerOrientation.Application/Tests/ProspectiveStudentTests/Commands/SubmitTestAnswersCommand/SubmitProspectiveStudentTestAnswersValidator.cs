using CareerOrientation.Application.Tests.Common.Validation;

using FluentValidation;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Commands.SubmitTestAnswersCommand;

public class SubmitProspectiveStudentTestAnswersValidator : AbstractValidator<SubmitProspectiveStudentTestAnswersCommand>
{
    public SubmitProspectiveStudentTestAnswersValidator()
    {
        Include(new SubmitTestAnswersCommonValidator());

        RuleFor(x => x.GeneralTestId)
            .NotNull()
            .WithMessage("Το GeneralTestId είναι απαραίτητο");
    }
}