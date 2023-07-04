namespace CareerOrientation.Application.Tests.Common;

public record MultipleChoiceAnswer(
    int QuestionId,
    int MultipleChoiceAnswerId) : IQuestionAnswer;