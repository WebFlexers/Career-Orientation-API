using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Services.Validation.Exceptions;

public static class ExceptionExtensions
{
    public static IEnumerable<IdentityError>? MapToResponse(this Exception exception) 
    { 
        if (exception is IdentityException)
        {
            return ((IdentityException)exception).Errors;
        }
        
        return null;
    }
}
