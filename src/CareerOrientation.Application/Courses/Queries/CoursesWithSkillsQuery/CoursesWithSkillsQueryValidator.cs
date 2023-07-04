using CareerOrientation.Application.Common.Validation;

using FluentValidation;

using static CareerOrientation.Application.Common.Validation.ValidationHelper;

namespace CareerOrientation.Application.Courses.Queries.CoursesWithSkillsQuery;

public class CoursesWithSkillsQueryValidator : AbstractValidator<CoursesWithSkillsQuery>
{
    public CoursesWithSkillsQueryValidator()
    {
        RuleFor(x => x.Semester)
            .Must(semester => BeValidSemester(semester))
            .WithMessage(ValidationMessages.InvalidSemester);

        When(x => x.Semester >= 5 && x.IsProspectiveStudent == false, () =>
        {
            RuleFor(x => x.Track)
                .NotEmpty()
                .WithMessage(ValidationMessages.MustSupplyTrackAboveSemester4);
        });
        
        When(x => x.Track is not null, () =>
        {
            RuleFor(x => x.Semester)
                .Must(semester => BeValidSemesterForTrack(semester))
                .WithMessage("Μόνο από το 5ο εξάμηνο και πάνω μπορεί να επιλεχθεί κατεύθυνση");
            
            RuleFor(x => x.Track)
                .Must(BeValidTrack)
                .WithMessage(ValidationMessages.InvalidTrack);
        });
    }
}