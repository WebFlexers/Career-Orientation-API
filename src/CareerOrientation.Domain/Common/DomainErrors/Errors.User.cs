using ErrorOr;

namespace CareerOrientation.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class User
    {
        public static Error UserNotFoundById => Error.NotFound(
            code: nameof(UserNotFoundById),
            description: "Δεν βρέθηκε χρήστης με το δεδομένο ID");
        public static Error StudentNotFoundById => Error.NotFound(
            code: nameof(StudentNotFoundById),
            description: "Δεν βρέθηκε φοιτητής με το δεδομένο ID");
        public static Error WrongUserType => Error.Validation(
            code: nameof(WrongUserType),
            description: "Ο τύπος του χρήστη είναι λάθος");
    }
}