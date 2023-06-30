namespace CareerOrientation.API.Common.Contracts.StudentTests;

public record QuestionAnswerRequest(
    int QuestionId,
    int? MultipleChoiceAnswerId,
    bool? TrueOrFalseAnswer,
    int? LikertScaleAnswer);