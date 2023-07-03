namespace CareerOrientation.Infrastructure.Common.Options.Validators;

public static class JwtOptionsValidator
{
    public static bool ValidateJwtOptions(this JwtOptions options)
    {
        var validationHelper = new OptionsValidatorHelper();
        
        // Validate key
        var isKeyValid = Guid.TryParse(options.Key, out Guid keyGuid);
        if (isKeyValid == false)
        {
            validationHelper.Errors.Add($"The specified Jwt key '{options.Key}' is not a GUID");
        }
        
        // Validate Issuer, Audience, Subject
        if (String.IsNullOrWhiteSpace(options.Issuer))
        {
            validationHelper.Errors.Add($"The Jwt issuer cannot be empty");
        }

        if (String.IsNullOrWhiteSpace(options.Audience))
        {
            validationHelper.Errors.Add($"The Jwt audience cannot be empty");
        }

        if (String.IsNullOrWhiteSpace(options.Subject))
        {
            validationHelper.Errors.Add($"The Jwt subject cannot be empty");
        }

        return validationHelper.CheckForErrors();
    }
}