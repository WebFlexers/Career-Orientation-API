namespace CareerOrientation.Application.Tests.Common;

public record TrueFalseAnswer(
    int QuestionId,
    bool Value) : IQuestionAnswer;