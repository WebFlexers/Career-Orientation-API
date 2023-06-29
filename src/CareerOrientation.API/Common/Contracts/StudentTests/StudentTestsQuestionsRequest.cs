namespace CareerOrientation.API.Common.Contracts.StudentTests;

public record StudentTestsQuestionsRequest(
    string? Track,
    int? Semester, 
    int? RevisionYear);