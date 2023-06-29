﻿using CareerOrientation.Application.Common.Models;

namespace CareerOrientation.API.Common.Contracts.ProspectiveStudentTests;

public record ProspectiveStudentTestsQuestionsResponse(
    int GeneralTestId,
    List<ITestQuestionResult?> Questions);