using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Services.Validation.Exceptions;

public class IdentityException : Exception
{
    public IEnumerable<IdentityError> Errors { get; set; }

    public IdentityException(IEnumerable<IdentityError> errors)
    {
        Errors = errors;
    }
}