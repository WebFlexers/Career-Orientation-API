using CareerOrientation.Domain.JunctionEntities;
using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Domain.Entities;

public class User : IdentityUser
{
    public bool IsProspectiveStudent { get; set; }

    public UniversityStudent? UniversityStudent { get; set; }

    // User commited answers
    public List<UserLikertScaleAnswer>? UserLikertScaleAnswers { get; set; }
    public List<MultipleChoiceAnswer>? MultipleChoiceAnswers { get; set; }
    public List<TrueFalseAnswer>? TrueFalseAnswers { get; set; }

    // User tests taken
    public List<GeneralTest> CompletedGeneralTests { get; set; }
    public List<UniversityTest> CompletedUniversityTests { get; set; }

    // Course relations
    public List<UserCourseGrade> UserCourseGrades { get; set; }
    public List<UserCourseStatistics> UserCourseStatistics { get; set; }
    
    // Statistics
    public List<Statistics> Statistics { get; set; }
}
