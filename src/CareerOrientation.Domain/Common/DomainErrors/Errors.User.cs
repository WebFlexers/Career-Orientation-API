using ErrorOr;

namespace CareerOrientation.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class User
    {
        public static Error UserNotFoundById => Error.NotFound(
                code: nameof(UserNotFoundById),
                description: "Δεν βρέθηκε χρήστης με το δεδομένο ID"
            );
    }
}