using FluentValidation;

using static CareerOrientation.Application.Common.Validation.ValidationHelper;

namespace CareerOrientation.Application.Auth.Commands.Register;

public class RegisterUserCommandValidator : AbstractValidator<RegisterUserCommand>
{
    public RegisterUserCommandValidator()
    {
        RuleFor(user => user.IsProspectiveStudent).NotNull()
            .WithMessage("Πρέπει να προσδιοριστεί εάν ο χρήστης ανήκει στην κατηγορία των ενδιαφερόμενων");

        RuleFor(user => user.Password).NotEmpty()
            .WithMessage("Ο κωδικός πρόσβασης δεν μπορεί να είναι κενός");
        
        RuleFor(user => user.ConfirmPassword).NotEmpty()
            .WithMessage("Η επαλήθευση του κωδικού πρόσβασης δεν μπορεί να είναι κενή");

        RuleFor(user => user.Password).Equal(user => user.ConfirmPassword)
            .WithMessage("Ο κωδικός και η επαλήθευση κωδικού πρέπει να ταυτίζονται");

        When(user => user.IsProspectiveStudent, () =>
        {
            RuleFor(user => user.IsGraduate).Must(isGraduate => isGraduate == false)
                .WithMessage("Ο ενδιαφερόμενος χρήστης δεν μπορεί να είναι και απόφοιτος");
            RuleFor(user => user.Semester).Must(semester => semester == null)
                .WithMessage("Ο ενδιαφερόμενος χρήστης δεν βρίσκεται σε κάποιο εξάμηνο");
            RuleFor(user => user.Track).Null()
                .WithMessage("Ο ενδιαφερόμενος χρήστης δεν μπορεί να ανήκει σε κάποια κατεύθυνση");
        });

        When(user => user.IsProspectiveStudent == false, () =>
        {
            RuleFor(user => user.IsGraduate).NotNull()
                .WithMessage("Πρέπει να προσδιοριστεί εάν ο φοιτητής έχει αποφοιτήσει");

            When(user => user.IsGraduate == false, () =>
            {
                RuleFor(user => user.Semester).Must(BeValidSemester)
                    .WithMessage("Οι φοιτητές πρέπει να προσδιορίζουν το εξάμηνο, "+
                                 "στο οποίο βρίσκονται (από 1 έως 8)");
            });

            When(user => user.Semester is >= 5 and <= 8 ||
                user.IsGraduate, () =>
                {
                    RuleFor(user => user.Track).Must(BeValidTrack)
                        .WithMessage("Οι φοιτητές και οι απόφοιτοι πρέπει να προσδιορίζουν " +
                                     "μία από τις κατευθύνσεις: ΤΛΕΣ, ΔΥΣ, ΠΣΥ");
                });

            When(user => user.Semester >= 1 && user.Semester <= 4, () =>
            {
                RuleFor(user => user.Track).Null()
                    .WithMessage("Οι φοιτητές μέχρι το 4ο εξάμηνο δεν έχουν επιλέξει ακόμη κατεύθυνση");
            });
        });
    }
}