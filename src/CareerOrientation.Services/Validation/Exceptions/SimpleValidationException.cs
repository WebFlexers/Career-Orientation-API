namespace CareerOrientation.Services.Validation.Exceptions;

public class SimpleValidationException : Exception
{
    public IEnumerable<SimpleValidationError> Errors { get; set; }

    public SimpleValidationException(IEnumerable<SimpleValidationError> errors)
    {
        Errors = errors;
    }
}