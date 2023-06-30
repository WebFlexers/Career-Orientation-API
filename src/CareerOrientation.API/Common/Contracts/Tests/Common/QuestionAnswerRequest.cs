namespace CareerOrientation.API.Common.Contracts.Tests.Common;

public record QuestionAnswerRequest(
    int QuestionId,
    int? MultipleChoiceAnswerId,
    bool? TrueOrFalseAnswer,
    int? LikertScaleAnswer);