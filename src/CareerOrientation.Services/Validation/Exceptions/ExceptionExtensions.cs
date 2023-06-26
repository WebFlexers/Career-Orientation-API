using FluentValidation;

namespace CareerOrientation.Services.Validation.Exceptions;

public static class ExceptionExtensions
{
    public static object? MapToResponse(this Exception exception)
    {
        return exception switch
        {
            IdentityException identityException => identityException.Errors,
            ValidationException validationException => validationException.Errors,
            SimpleValidationException simpleValidationException => simpleValidationException.Errors,
            _ => exception.Message
        };
    }
}
