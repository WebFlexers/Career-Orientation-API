using CareerOrientation.API.Common.Contracts.Tests.Common;
using CareerOrientation.Application.Tests.StudentTests.Common;
using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.API.Common.Mapping.Tests.StudentTests;

public static class QuestionAnswerRequestMapping
{
    public static QuestionAnswer MapToQuestionAnswer(this QuestionAnswerRequest request)
    {
        QuestionType questionType;
        if (request.LikertScaleAnswer is not null)
        {
            questionType = QuestionType.LikertScale;
        }
        else if (request.MultipleChoiceAnswerId is not null)
        {
            questionType = QuestionType.MultipleChoice;
        }
        else
        {
            questionType = QuestionType.TrueFalse;
        }

        return new QuestionAnswer(
            QuestionId: request.QuestionId,
            MultipleChoiceAnswerId: request.MultipleChoiceAnswerId,
            TrueOrFalseAnswer: request.TrueOrFalseAnswer,
            LikertScaleAnswer: request.LikertScaleAnswer,
            QuestionType: questionType);
    }
}