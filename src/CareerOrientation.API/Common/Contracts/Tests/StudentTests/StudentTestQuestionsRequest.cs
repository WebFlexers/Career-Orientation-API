namespace CareerOrientation.API.Common.Contracts.Tests.StudentTests;

public record StudentTestQuestionsRequest(
    string? Track,
    int? Semester, 
    int? RevisionYear);