using CareerOrientation.API.Common.Contracts.StudentTests;
using CareerOrientation.Application.StudentTests.Queries;
using CareerOrientation.Application.StudentTests.Queries.GetStudentTestsQuestions;

namespace CareerOrientation.API.Common.Mapping.StudentTests;

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