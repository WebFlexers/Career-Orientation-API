using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Services.Validation.Exceptions;

public static class ExceptionExtensions
{
    public static object? MapToResponse(this Exception exception) 
    { 
        if (exception is IdentityException)
        {
            return ((IdentityException)exception).Errors;
        }
        
        return exception.Message;
    }
}
