using CareerOrientation.Application.Common.Models;
using CareerOrientation.Domain.Entities;

namespace CareerOrientation.Application.StudentTests.Common.Mapping;

public static class QuestionMapping
{
    public static TestQuestionResult MapToTestQuestionResult(this Question question)
    {
        return new TestQuestionResult(
            Text: question.Text,
            Type: question.Type.ToString());
    }
}