namespace CareerOrientation.API.Common.Contracts.StudentTests;

public record StudentTestQuestionsRequest(
    string? Track,
    int? Semester, 
    int? RevisionYear);