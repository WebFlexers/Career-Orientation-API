using ErrorOr;

namespace CareerOrientation.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Tests
    {
        public static Error NoQuestionsFound => Error.NotFound(
            code: nameof(NoQuestionsFound),
            description: "Δεν βρέθηκαν ερωτήσεις");
    }
}