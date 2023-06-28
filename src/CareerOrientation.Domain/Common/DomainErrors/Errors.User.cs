using ErrorOr;

namespace CareerOrientation.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class User
    {
        public static Error AuthFailure => Error.Validation(
                
            );
    }
}