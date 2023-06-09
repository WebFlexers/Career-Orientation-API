using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.TestsUsersRelations;
using Microsoft.AspNetCore.Identity;

namespace CareerOrientation.Data.Entities.Users;

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
}
