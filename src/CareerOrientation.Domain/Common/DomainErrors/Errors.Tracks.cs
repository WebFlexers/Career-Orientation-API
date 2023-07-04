using ErrorOr;

namespace CareerOrientation.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Tracks
    {
        public static Error NonExistentTrack => Error.Validation(
            code: nameof(NonExistentTrack),
            description: "Η κατεύθυνση που δόθηκε δεν υπάρχει");
    }
}