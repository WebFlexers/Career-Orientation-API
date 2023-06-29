namespace CareerOrientation.Application.Common.Models;

public record LikertScaleQuestionResult(
    int QuestionId,
    string Text,
    string Type,
    string Answer1,
    string Answer2,
    string Answer3,
    string Answer4,
    string Answer5) : ITestQuestionResult;