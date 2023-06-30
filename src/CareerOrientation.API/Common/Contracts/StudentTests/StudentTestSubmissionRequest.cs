namespace CareerOrientation.API.Common.Contracts.StudentTests;

public record StudentTestSubmissionRequest(
    string UserId,
    int UniversityTestId,
    List<QuestionAnswerRequest> Answers);