using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.Application.Tests.StudentTests.Common;

public record QuestionAnswer(
    int QuestionId,
    int? MultipleChoiceAnswerId,
    bool? TrueOrFalseAnswer,
    int? LikertScaleAnswer,
    QuestionType QuestionType);