namespace CareerOrientation.Application.Tests.Common;

public record LikertScaleAnswer(
    int QuestionId,
    int Value,
    bool IsYesOrNoAnswer) : IQuestionAnswer;