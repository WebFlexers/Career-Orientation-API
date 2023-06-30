using CareerOrientation.Application.Common.Models;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;

public record ProspectiveStudentTestResult(
    int GeneralTestId,
    List<ITestQuestionResult?> Questions);