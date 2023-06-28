using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Domain.Common.DomainErrors;

public class GreekIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError DefaultError() { return new IdentityError { Code = nameof(DefaultError), Description = $"Προέκυψε άγνωστο σφάλμα." }; }
    public override IdentityError ConcurrencyFailure() { return new IdentityError { Code = nameof(ConcurrencyFailure), Description = "Παρουσιάστηκε σφάλμα συγχρονισμού, το αντικείμενο έχει ήδη τροποποιηθεί (Optimistic concurrency failure)." }; }
    public override IdentityError PasswordMismatch() { return new IdentityError { Code = nameof(PasswordMismatch), Description = "Λάθος κωδικός πρόσβασης." }; }
    public override IdentityError InvalidToken() { return new IdentityError { Code = nameof(InvalidToken), Description = "Λάθος token." }; }
    public override IdentityError LoginAlreadyAssociated() { return new IdentityError { Code = nameof(LoginAlreadyAssociated), Description = "Υπάρχει ήδη χρήστης με αυτό το όνομα" }; }
    public override IdentityError InvalidUserName(string? userName) { return new IdentityError { Code = nameof(InvalidUserName), Description = $"Το όνομα χρήστη '{userName}' είναι λάθος. Θα πρέπει να περιέχει μόνο γράμματα ή αριθμούς." }; }
    public override IdentityError InvalidEmail(string? email) { return new IdentityError { Code = nameof(InvalidEmail), Description = $"Το email '{email}' είναι λάθος." }; }
    public override IdentityError DuplicateUserName(string userName) { return new IdentityError { Code = nameof(DuplicateUserName), Description = $"Το όνομα χρήστη '{userName}' χρησιμοποιείται ήδη." }; }
    public override IdentityError DuplicateEmail(string email) { return new IdentityError { Code = nameof(DuplicateEmail), Description = $"Το email '{email}' χρησιμοποιείται ήδη." }; }
    public override IdentityError InvalidRoleName(string? role) { return new IdentityError { Code = nameof(InvalidRoleName), Description = $"Ο ρόλος '{role}' είναι λάθος." }; }
    public override IdentityError DuplicateRoleName(string role) { return new IdentityError { Code = nameof(DuplicateRoleName), Description = $"Ο ρόλος '{role}' υπάρχει ήδη." }; }
    public override IdentityError UserAlreadyHasPassword() { return new IdentityError { Code = nameof(UserAlreadyHasPassword), Description = "Ο χρήστης έχει ορίσει ήδη κωδικό πρόσβασης." }; }
    public override IdentityError UserLockoutNotEnabled() { return new IdentityError { Code = nameof(UserLockoutNotEnabled), Description = "Ο χρήστης είναι κλειδωμένος." }; }
    public override IdentityError UserAlreadyInRole(string role) { return new IdentityError { Code = nameof(UserAlreadyInRole), Description = $"Ο χρήστης ανήκει ήδη στον ρόλο '{role}'." }; }
    public override IdentityError UserNotInRole(string role) { return new IdentityError { Code = nameof(UserNotInRole), Description = $"Ο χρήστης δεν ανήκει στον ρόλο '{role}'." }; }
    public override IdentityError PasswordTooShort(int length) { return new IdentityError { Code = nameof(PasswordTooShort), Description = $"Ο κωδικός πρόσβασης πρέπει να αποτελείται τουλάχιστον από {length} χαρακτήρες." }; }
    public override IdentityError PasswordRequiresNonAlphanumeric() { return new IdentityError { Code = nameof(PasswordRequiresNonAlphanumeric), Description = "Ο κωδικός πρόσβασης θα πρέπει να έχει τουλάχιστον έναν μη αλφαριθμητικό χαρακτήρα." }; }
    public override IdentityError PasswordRequiresDigit() { return new IdentityError { Code = nameof(PasswordRequiresDigit), Description = "Ο κωδικός πρόσβασης θα πρέπει να έχει τουλάχιστον έναν αριθμό ('0'-'9')." }; }
    public override IdentityError PasswordRequiresLower() { return new IdentityError { Code = nameof(PasswordRequiresLower), Description = "Ο κωδικός πρόσβασης θα πρέπει να έχει τουλάχιστον ένα μικρό γράμμα ('a'-'z')." }; }
    public override IdentityError PasswordRequiresUpper() { return new IdentityError { Code = nameof(PasswordRequiresUpper), Description = "Ο κωδικός πρόσβασης θα πρέπει να έχει τουλάχιστον ένα ΚΕΦΑΛΑΙΟ ΓΡΑΜΜΑ ('A'-'Z')." }; }
}