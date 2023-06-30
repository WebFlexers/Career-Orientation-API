using CareerOrientation.Application.Common.Models;

namespace CareerOrientation.API.Common.Contracts.StudentTests;

public class StudentTestQuestionsResponse
{
    public StudentTestQuestionsResponse(bool isRevision, int universityTestId, List<ITestQuestionResult?> questions)
    {
        IsRevision = isRevision;
        UniversityTestId = universityTestId;
        Questions = questions;
    }

    public bool IsRevision { get; set; }
    public int UniversityTestId { get; set; }
    public List<ITestQuestionResult?> Questions { get; set; }
}