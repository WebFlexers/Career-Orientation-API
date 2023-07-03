using CareerOrientation.Application.Tests.StudentTests.Common;

namespace CareerOrientation.API.Common.Contracts.Tests.ProspectiveStudentTests;

public record ProspectiveStudentCompletedTestsResponse(
    bool HasCompletedAllTests,
    List<GeneralTestCompletionResult> TestsCompletionState);