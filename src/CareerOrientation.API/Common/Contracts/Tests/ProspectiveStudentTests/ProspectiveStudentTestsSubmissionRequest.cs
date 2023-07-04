using CareerOrientation.API.Common.Contracts.Tests.Common;

namespace CareerOrientation.API.Common.Contracts.Tests.ProspectiveStudentTests;

public record ProspectiveStudentTestsSubmissionRequest(
    string UserId,
    int GeneralTestId,
    List<QuestionAnswerRequest> Answers);