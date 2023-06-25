using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.Tests.Enums;
using CareerOrientation.Data.Entities.TestsUsersRelations;

namespace CareerOrientation.Data.Entities.Tests;

public class Question
{
    public int QuestionId { get; set; }
    public string Text { get; set; }
    public QuestionType Type { get; set; }

    // Tests relations
    public int? GeneralTestId { get; set; }
    public GeneralTest? GeneralTest { get; set; }
    public int? UniversityTestId { get; set; }
    public UniversityTest? UniversityTest { get; set; }
    
    // Specialties relations
    public List<MastersDegree>? MastersDegrees { get; set; }
    public List<Profession>? Professions { get; set; }
    public List<Track>? Tracks { get; set; }

    // Answers relations
    public TrueFalseAnswer? TrueFalseAnswer { get; set; }
    public List<MultipleChoiceAnswer>? MultipleChoiceAnswers { get; set; }
    public List<LikertScaleAnswers>? LikertScaleAnswers { get; set; }

    // User answers relations
    public List<UserLikertScaleAnswer> UsersLikertScaleAnswers { get; set; }
}
