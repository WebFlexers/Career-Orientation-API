using CareerOrientation.Application.Common.Models;
using CareerOrientation.Domain.Entities;
using CareerOrientation.Domain.Entities.Enums;

namespace CareerOrientation.Application.Tests.StudentTests.Common.Mapping;

public static class QuestionMapping
{
    public static ITestQuestionResult? MapToTestQuestionResult(this Question question)
    {
        switch (question.Type)
        {
            case QuestionType.TrueFalse:
                return new TrueFalseQuestionResult
                (
                    QuestionId: question.QuestionId,
                    Text: question.Text, 
                    Type: question.Type.ToString()
                );
            case QuestionType.MultipleChoice:
                return new MultipleChoiceQuestionResult
                (
                    QuestionId: question.QuestionId,
                    Text: question.Text,
                    Type: question.Type.ToString(),
                    Answers: question?.MultipleChoiceAnswers?.ConvertAll(a => 
                        new MultipleChoiceAnswerResult(a.MultipleChoiceAnswerId, a.Text)
                    )
                );
            case QuestionType.LikertScale:
                var likertScaleAnswers = question?.LikertScaleAnswers?.FirstOrDefault();

                if (likertScaleAnswers is null) return null;
                
                return new LikertScaleQuestionResult
                (
                    question!.QuestionId,
                    question.Text,
                    question.Type.ToString(),
                    likertScaleAnswers!.Option1,
                    likertScaleAnswers.Option2,
                    likertScaleAnswers.Option3,
                    likertScaleAnswers.Option4,
                    likertScaleAnswers.Option5
                );
            default:
                return null;
        }
    }
}