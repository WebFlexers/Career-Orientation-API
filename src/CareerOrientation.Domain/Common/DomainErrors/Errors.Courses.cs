using ErrorOr;

namespace CareerOrientation.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Courses
    {
        public static Error NoCoursesFound => Error.NotFound(
            code: nameof(NoCoursesFound),
            description: "Δεν βρέθηκαν μαθήματα στο συγκεκριμένο εξάμηνο");
    }
}