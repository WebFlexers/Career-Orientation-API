using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;

namespace CareerOrientation.API.Common.Contracts.Tests.ProspectiveStudentTests;

public record ProspectiveStudentCompletedTestsResponse(
    bool HasCompletedAllEssentialTests,
    List<GeneralTestCompletionResult> TestsCompletionState);