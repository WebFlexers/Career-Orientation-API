using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;

public record GeneralTestCompletionResult(
    int GeneralTestId,
    GeneralTestType TestType,
    bool IsCompleted);