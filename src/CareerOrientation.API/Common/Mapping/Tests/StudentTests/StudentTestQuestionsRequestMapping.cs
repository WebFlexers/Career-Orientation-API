using CareerOrientation.API.Common.Contracts.Tests.StudentTests;
using CareerOrientation.Application.Tests.StudentTests.Queries.StudentTestsQuestions;

namespace CareerOrientation.API.Common.Mapping.Tests.StudentTests;

public static class StudentTestQuestionsRequestMapping
{
    public static StudentTestsQuestionsQuery MapToQuery(this StudentTestQuestionsRequest request)
    {
        return new StudentTestsQuestionsQuery(
            Track: request.Track,
            Semester: request.Semester,
            RevisionYear: request.RevisionYear);
    }
}