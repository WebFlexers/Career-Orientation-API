using CareerOrientation.Services.Tests.Fixtures;
using Xunit.Abstractions;

namespace CareerOrientation.Services.Tests.DataAccess;

[Collection("Database collection")]
public class Test1
{
    private readonly ITestOutputHelper _outputHelper;
    private readonly LocalDbInitializerFixture _fixture;

    public Test1(ITestOutputHelper outputHelper, LocalDbInitializerFixture fixture)
    {
        _outputHelper = outputHelper;
        _fixture = fixture;
    }

    [Fact]
    public void Test()
    {
        var dbContext = _fixture.GetDbContextLocalDb(false);
        var question = dbContext.Questions.FirstOrDefault();

        _outputHelper.WriteLine($"The question is: {question?.Text}, type: {question.Type.ToString()}");
    }
}
