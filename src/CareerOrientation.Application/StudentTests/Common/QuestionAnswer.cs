using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.Application.StudentTests.Common;

public record QuestionAnswer(
    int QuestionId,
    int? MultipleChoiceAnswerId,
    bool? TrueOrFalseAnswer,
    int? LikertScaleAnswer,
    QuestionType QuestionType);