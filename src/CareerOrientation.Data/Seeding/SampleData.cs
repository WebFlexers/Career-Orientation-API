using CareerOrientation.Data.Entities.Tests;
using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Data.Seeding;

public class SampleData
{
    public void Seed(ModelBuilder builder)
    {
        var data = new Question[]
        {
            new Question
            {
                QuestionId = 1,
                Text = "Hello",
                Type = Entities.Tests.Enums.QuestionType.TrueFalse
            }
        };
        builder.Entity<Question>().HasData(data);
    }
}
