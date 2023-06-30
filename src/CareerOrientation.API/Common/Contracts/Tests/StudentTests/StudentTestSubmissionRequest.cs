using CareerOrientation.API.Common.Contracts.Tests.Common;

namespace CareerOrientation.API.Common.Contracts.Tests.StudentTests;

public record StudentTestSubmissionRequest(
    string UserId,
    int UniversityTestId,
    List<QuestionAnswerRequest> Answers);