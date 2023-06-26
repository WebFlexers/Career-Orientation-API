﻿using CareerOrientation.Data.DTOs.Courses;
using FluentValidation;
using static CareerOrientation.Services.Validation.Common.ValidationHelper;

namespace CareerOrientation.Services.Validation.Courses;

public class CoursesSkillsRequestValidator : AbstractValidator<CoursesSkillsRequest>
{
    public CoursesSkillsRequestValidator()
    {
        RuleFor(x => x.Semester)
            .Must(semester => BeValidSemester(semester))
            .WithMessage("Τα διαθέσιμα εξάμηνα είναι από 1 έως 8");

        When(x => x.Semester >= 5, () =>
        {
            RuleFor(x => x.Track)
                .NotNull()
                .WithMessage("Όταν το εξάμηνο είναι από 5 και πάνω πρέπει να οριστεί και η κατεύθυνση");
        });
        
        When(x => x.Track is not null, () =>
        {
            RuleFor(x => x.Semester)
                .Must(semester => BeValidSemesterForTrack(semester))
                .WithMessage("Μόνο από το 5ο εξάμηνο και πάνω μπορεί να επιλεχθεί κατεύθυνση");
            
            RuleFor(x => x.Track)
                .Must(BeValidTrack)
                .WithMessage("Οι διαθέσιμες κατευθύνσεις είναι: ΤΛΕΣ, ΔΥΣ, ΠΣΥ");
        });
    }
}