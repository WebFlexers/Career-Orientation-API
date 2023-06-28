using ErrorOr;

namespace CareerOrientation.Domain.Common.DomainErrors;

public static partial class Errors
{
    public static class Auth
    {
        public static Error NullCredentials => Error.Validation(
            code: "Null Credentials",
            description: "Δεν γίνεται να είναι κενό και το όνομα και το email"
        );

        public static Error AuthFailure => Error.Validation(
            code: "Wrong Credentials",
            description: "Ο συνδυασμός ονόματος χρήστη / email και κωδικού πρόσβασης είναι λάθος");
    }
}