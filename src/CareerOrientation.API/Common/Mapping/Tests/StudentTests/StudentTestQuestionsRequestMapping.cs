using CareerOrientation.API.Common.Contracts.Tests.StudentTests;
using CareerOrientation.Application.Tests.StudentTests.Queries.GetStudentTestsQuestions;

namespace CareerOrientation.API.Common.Mapping.Tests.StudentTests;

public static class StudentTestQuestionsRequestMapping
{
    public static GetStudentTestsQuestionsQuery MapToQuery(this StudentTestQuestionsRequest request)
    {
        return new GetStudentTestsQuestionsQuery(
            Track: request.Track,
            Semester: request.Semester,
            RevisionYear: request.RevisionYear);
    }
}