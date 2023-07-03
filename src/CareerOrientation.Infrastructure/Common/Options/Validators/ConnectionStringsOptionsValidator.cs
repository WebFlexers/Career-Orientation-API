namespace CareerOrientation.Infrastructure.Common.Options.Validators;

public static class ConnectionStringsOptionsValidation
{
    public static bool ValidateConnectionStringOptions(this ConnectionStringsOptions options)
    {
        var validationHelper = new OptionsValidatorHelper();
        
        if (String.IsNullOrWhiteSpace(options.Default))
        {
            validationHelper.Errors.Add($"The {nameof(options.Default)} connection string cannot be empty");
        }
        
        if (String.IsNullOrWhiteSpace(options.LoggingDb))
        {
            validationHelper.Errors.Add($"The {nameof(options.LoggingDb)} connection string cannot be empty");
        }

        return validationHelper.CheckForErrors();
    } 
}