﻿using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Services.Validation.Exceptions;

public static class ValidationExceptionExtensions
{
    public static IdentityException? MapToIdentityException(this ValidationResult validationResult)
    {
        if (validationResult?.Errors is not null && validationResult.Errors.Any() == false)
        {
            return null;
        }

        return new IdentityException(validationResult!.Errors!.Select(x => new IdentityError()
        {
            Code = x.ErrorCode,
            Description = x.ErrorMessage
        }));
    }

    public static SimpleValidationException MapToSimpleValidationException(this ValidationException validationException)
    {
        return new SimpleValidationException(validationException.Errors.Select(err =>
            new SimpleValidationError
            {
                PropertyName = err.PropertyName,
                ErrorMessage = err.ErrorMessage
            })
        );
    }
}
