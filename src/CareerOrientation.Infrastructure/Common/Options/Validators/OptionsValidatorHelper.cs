namespace CareerOrientation.Infrastructure.Common.Options.Validators;

public class OptionsValidatorHelper
{
    public List<string> Errors { get; set; }

    public OptionsValidatorHelper()
    {
        Errors = new();
    }

    /// <summary>
    /// Checks for potential errors and logs them
    /// </summary>
    /// <returns>True if no errors are found and false otherwise</returns>
    public bool CheckForErrors()
    {
        if (Errors.Any() == false)
        {
            return true;
        }

        foreach (string error in Errors)
        {
            Console.Error.WriteLine(error);
        }

        return false;
    }
}