namespace CareerOrientation.Application.Common.Models;

public record MultipleChoiceQuestionResult
(
    int QuestionId,
    string Text,
    string Type,
    List<MultipleChoiceAnswerResult>? Answers
) : ITestQuestionResult;