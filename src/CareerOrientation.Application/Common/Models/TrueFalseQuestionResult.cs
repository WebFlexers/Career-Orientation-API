namespace CareerOrientation.Application.Common.Models;

public record TrueFalseQuestionResult(
    int QuestionId, 
    string Text, 
    string Type) : ITestQuestionResult;