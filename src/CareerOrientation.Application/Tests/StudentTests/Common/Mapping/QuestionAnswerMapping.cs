using CareerOrientation.Domain.JunctionEntities;

namespace CareerOrientation.Application.Tests.StudentTests.Common.Mapping;

public static class QuestionAnswerMapping
{
    public static UserTrueFalseAnswer MapToUserTrueFalseAnswer(this QuestionAnswer answer, string userId)
    {
        return new UserTrueFalseAnswer
        {
            UserId = userId,
            QuestionId = answer.QuestionId,
            Value = answer.TrueOrFalseAnswer!.Value
        };
    }
    
    public static UserMultipleChoiceAnswer MapToUserMultipleChoiceAnswer(this QuestionAnswer answer, string userId)
    {
        return new UserMultipleChoiceAnswer
        {
            UserId = userId,
            QuestionId = answer.QuestionId,
            MultipleChoiceAnswerId = answer.MultipleChoiceAnswerId!.Value
        };
    }
    
    public static UserLikertScaleAnswer MapToUserLikertScaleAnswer(this QuestionAnswer answer, string userId)
    {
        return new UserLikertScaleAnswer
        {
            UserId = userId,
            QuestionId = answer.QuestionId,
            Value = answer.LikertScaleAnswer!.Value
        };
    }
}