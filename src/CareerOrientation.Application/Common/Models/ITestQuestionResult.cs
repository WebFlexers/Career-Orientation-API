namespace CareerOrientation.Application.Common.Models;

public interface ITestQuestionResult
{
    public int QuestionId { get; init; }
    string Text { get; init; }
    string Type { get; init; }
}