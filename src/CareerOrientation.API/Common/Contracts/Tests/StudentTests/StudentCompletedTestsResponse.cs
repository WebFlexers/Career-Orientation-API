using CareerOrientation.Application.Tests.StudentTests.Common;

namespace CareerOrientation.API.Common.Contracts.Tests.StudentTests;

public record StudentCompletedTestsResponse(
    bool HasCompletedAllTests,
    List<IUniversityTestCompletionResult> TestsCompletionState);