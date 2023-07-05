using ErrorOr;

namespace CareerOrientation.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Recommendations
    {
        public static Error ZeroTestsAreCompleted => Error.Validation(
            code: nameof(ZeroTestsAreCompleted),
            description: "Κανένα τεστ δεν έχει συμπληρωθεί. Ολοκλήρωσε τα τεστ και δοκίμασε ξανά");

        public static Error RequiredTestsAreNotCompleted => Error.Validation(
            code: nameof(RequiredTestsAreNotCompleted),
            description: "Δεν έχουν συμπληρωθεί όλα τα απαραίτητα τεστ");
    }
}