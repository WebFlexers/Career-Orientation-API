using CareerOrientation.API.Common.Contracts.StudentTests;
using CareerOrientation.Application.StudentTests.Queries;

namespace CareerOrientation.API.Common.Mapping.StudentTests;

public static class StudentTestsQuestionsRequestMapping
{
    public static GetStudentTestsQuestionsQuery MapToQuery(this StudentTestsQuestionsRequest request)
    {
        return new GetStudentTestsQuestionsQuery(
            Semester: request.Semester,
            RevisionYear: request.RevisionYear);
    }
}