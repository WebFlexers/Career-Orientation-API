using System.Collections.Immutable;

using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Recommendations.Queries.StudentRecommendation.Common;
using CareerOrientation.Application.Tests.Common;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Common.Mapping;
using CareerOrientation.Application.Tests.StudentTests.Common;
using CareerOrientation.Application.Tests.StudentTests.Common.Mapping;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Common.Enums;
using CareerOrientation.Domain.Entities;
using CareerOrientation.Domain.Entities.Enums;
using CareerOrientation.Domain.JunctionEntities;

using ErrorOr;

using MediatR;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

using MultipleChoiceAnswer = CareerOrientation.Application.Tests.Common.MultipleChoiceAnswer;
using TrueFalseAnswer = CareerOrientation.Application.Tests.Common.TrueFalseAnswer;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class TestsRepository : RepositoryBase, ITestsRepository
{
    public TestsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<StudentTestResult?> GetSemesterTestQuestionsWithAnswers(int? semester, 
        string? track, CancellationToken cancellationToken)
    {
        StudentTestResult? studentTestResults;
        
        if (track is null)
        {
            studentTestResults = await _dbContext.UniversityTests
                .AsNoTracking()
                .Where(t => t.Semester == semester)
                .Include(t => t.Questions)
                .ThenInclude(q => q.MultipleChoiceAnswers)
                .Include(t => t.Questions)
                .ThenInclude(q => q.LikertScaleAnswers)
                .Select(test => test.MapToStudentTestResult())
                .FirstOrDefaultAsync(cancellationToken);
        }
        else
        {
            studentTestResults = await _dbContext.UniversityTests
                .AsNoTracking()
                .Where(t => t.Semester == semester && t.Track!.Name == track)
                .Include(t => t.Questions)
                .ThenInclude(q => q.MultipleChoiceAnswers)
                .Include(t => t.Questions)
                .ThenInclude(q => q.LikertScaleAnswers)
                .Select(test => test.MapToStudentTestResult())
                .FirstOrDefaultAsync(cancellationToken);
        }
        
        return studentTestResults;
    }

    public async Task<StudentTestResult?> GetRevisionTestQuestionsWithAnswers(int? year, 
        string? track, CancellationToken cancellationToken)
    {
        StudentTestResult? studentTestResults;

        if (string.IsNullOrWhiteSpace(track))
        {
            studentTestResults = await _dbContext.UniversityTests
                .AsNoTracking()
                .Where(t => t.Year == year && t.IsRevision)
                .Include(t => t.Questions)
                .ThenInclude(q => q.MultipleChoiceAnswers)
                .Include(t => t.Questions)
                .ThenInclude(q => q.LikertScaleAnswers)
                .Select(test => test.MapToStudentTestResult())
                .FirstOrDefaultAsync(cancellationToken);
        }
        else
        {
            studentTestResults = await _dbContext.UniversityTests
                .AsNoTracking()
                .Where(t => t.Year == year && t.IsRevision && t.Track!.Name == track)
                .Include(t => t.Questions)
                .ThenInclude(q => q.MultipleChoiceAnswers)
                .Include(t => t.Questions)
                .ThenInclude(q => q.LikertScaleAnswers)
                .Select(test => test.MapToStudentTestResult())
                .FirstOrDefaultAsync(cancellationToken);
        }
   
        return studentTestResults;
    }

    public async Task<ProspectiveStudentTestResult?> GetGeneralTestQuestionsWithAnswers(
        int generalTestId, CancellationToken cancellationToken)
    {
        var generalTest = await _dbContext.GeneralTests
            .AsNoTracking()
            .Where(t => t.GeneralTestId == generalTestId)
            .Include(t => t.Questions)
                .ThenInclude(q => q.MultipleChoiceAnswers)
            .Include(t => t.Questions)
                .ThenInclude(q => q.LikertScaleAnswers)
            .Select(test => test.MapToProspectiveStudentTestResult())
            .FirstOrDefaultAsync(cancellationToken);

        return generalTest;
    }

    public async Task<ErrorOr<List<IUniversityTestCompletionResult>>> GetStudentTestsCompletionState(string userId, 
        CancellationToken cancellationToken)
    {
        var student = await _dbContext.UniversityStudents.FindAsync(new object?[] {userId}, cancellationToken);
        if (student is null)
        {
            return Errors.User.WrongUserType;
        }

        // First we filter by the students track
        var universityTestsQueryable = _dbContext.UniversityTests
            .AsNoTracking()
            .Where(ut => ut.TrackId == null || ut.TrackId == student.TrackId);

        // Then if the student is not a graduate we want to limit the number of tests available to them
        // according to their semester and year
        if (student.IsGraduate == false)
        {
            var studentYear = student.Semester % 2 == 0
                ? student.Semester / 2
                : (student.Semester + 1) / 2;
            
            // Here if the semester is odd we will load one extra revision test that we will remove later
            universityTestsQueryable = universityTestsQueryable.Where(ut => 
                ut.Semester <= student.Semester ||
                (ut.Semester == null && ut.Year <= studentYear));
        }
        
        var universityTests = await universityTestsQueryable
            .OrderBy(ut => ut.UniversityTestId)
            .ToListAsync(cancellationToken);

        // If the semester is odd we need to remove the extra loaded revision test, 
        // since the student mustn't have access to it yet
        if (student.Semester % 2 != 0 && student.IsGraduate == false)
        {
            universityTests.RemoveAt(universityTests.Count - 1);
        }
        
        var universityTestsTaken = await _dbContext.StudentsTookUniversityTests
            .AsNoTracking()
            .Where(stut => stut.UserId == userId)
            .ToListAsync(cancellationToken);

        List<IUniversityTestCompletionResult> universityTestCompletionResults = new();
        foreach (var universityTest in universityTests)
        {
            var isTestCompleted = universityTestsTaken.Any(completedTest => 
                completedTest.UniversityTestId == universityTest.UniversityTestId);
            
            if (universityTest.IsRevision)
            {
                universityTestCompletionResults.Add(new RevisionYearTestCompletionResult(
                    UniversityTestId: universityTest.UniversityTestId,
                    RevisionYear: universityTest.Year,
                    IsCompleted: isTestCompleted));
            }
            else
            {
                universityTestCompletionResults.Add(new SemesterUniversityTestCompletionResult(
                    UniversityTestId: universityTest.UniversityTestId,
                    Semester: universityTest.Semester!.Value,
                    IsCompleted: isTestCompleted));
            }
        }

        return universityTestCompletionResults;
    }

    public async Task<ErrorOr<List<GeneralTestCompletionResult>>> GetProspectiveStudentTestsCompletionState(string userId,
        CancellationToken cancellationToken)
    {
        var user = await _dbContext.Users.FindAsync(new object?[] {userId}, cancellationToken);
        if (user is null)
        {
            return Errors.User.WrongUserType;
        }
        
        var generalTests = await _dbContext.GeneralTests.ToListAsync(cancellationToken);
        
        var completedGeneralTests = await _dbContext.UsersTookGeneralTests
            .AsNoTracking()
            .Where(x => x.UserId == userId)
            .ToListAsync(cancellationToken);

        var testCompletionResult = new List<GeneralTestCompletionResult>();
        
        foreach (var test in generalTests)
        {
            var userHasCompletedTest = completedGeneralTests.Any(completedTest => 
                completedTest.GeneralTestId == test.GeneralTestId);
            
            testCompletionResult.Add(new GeneralTestCompletionResult(
                GeneralTestId: test.GeneralTestId,
                TestType: test.Type,
                IsCompleted: userHasCompletedTest));
        }

        return testCompletionResult;
    }

    public async Task<List<IQuestionAnswer>> GetUserAnswersToGeneralTest(string userId, int generalTestId,
        CancellationToken cancellationToken)
    {
        var testQuestionsWithUserAnswers = _dbContext.Questions
            .AsNoTracking()
            .Where(question => question.GeneralTestId == generalTestId);

        return await GetUserAnswersToTests(testQuestionsWithUserAnswers, cancellationToken);
    }

    public async Task<List<IQuestionAnswer>> GetCorrectAnswersOfGeneralTest(int generalTestId, 
        CancellationToken cancellationToken)
    {
        var testQuestionsWithCorrectAnswers = _dbContext.Questions
            .AsNoTracking()
            .Where(question => question.GeneralTestId == generalTestId);

        return await GetCorrectAnswersToTests(testQuestionsWithCorrectAnswers, cancellationToken);
    }
    
    public async Task<List<IQuestionAnswer>> GetStudentAnswersToUniversityTests(string userId, 
        List<int> universityTestIds, CancellationToken cancellationToken)
    {
        if (universityTestIds.Any() == false)
        {
            return new();
        }

        var questionsQueryable = _dbContext.Questions
            .AsNoTracking()
            .Where(question => question.UniversityTestId.HasValue &&
                               universityTestIds.Contains(question.UniversityTestId.Value));

        return await GetUserAnswersToTests(questionsQueryable, cancellationToken);
    }
    
    public async Task<List<IQuestionAnswer>> GetCorrectAnswersOfUniversityTest(List<int> universityTestIds, 
        CancellationToken cancellationToken)
    {
        var testQuestionsWithCorrectAnswers = _dbContext.Questions
            .AsNoTracking()
            .Where(question => question.UniversityTestId.HasValue &&
                               universityTestIds.Contains(question.UniversityTestId.Value));

        return await GetCorrectAnswersToTests(testQuestionsWithCorrectAnswers, cancellationToken);
    }

    public async Task<List<QuestionRecommendationsLinks>> GetQuestionsRecommendationLinks(List<int> universityTestIds,
        CancellationToken cancellationToken)
    {
        var questionRecommendationLinks = await _dbContext.Questions
            .AsNoTracking()
            .Where(question => question.UniversityTestId.HasValue &&
                               universityTestIds.Contains(question.UniversityTestId.Value))
            .Select(question => new QuestionRecommendationsLinks(
                question.QuestionId,
                question.Tracks,
                question.Professions,
                question.MastersDegrees))
            .ToListAsync(cancellationToken);

        return questionRecommendationLinks;
    }

    /// <summary>
    /// Gets the user answers to the questions provided through the queryable
    /// </summary>
    private async Task<List<IQuestionAnswer>> GetUserAnswersToTests(IQueryable<Question>? questionsQueryable, 
        CancellationToken cancellationToken)
    {
        if (questionsQueryable is null)
        {
            return new();
        }

        var testsQuestionsWithUserAnswers = await questionsQueryable
            .Include(question => question.LikertScaleAnswers)
            .Include(question => question.UsersLikertScaleAnswers)
            .Include(question => question.UsersMultipleChoiceAnswers)
            .Include(question => question.UsersTrueFalseAnswers)
            .ToListAsync(cancellationToken);
        
        List<IQuestionAnswer> userAnswers = new();

        foreach (var question in testsQuestionsWithUserAnswers)
        {
            switch (question.Type)
            {
                case QuestionType.TrueFalse:
                    userAnswers.Add(new TrueFalseAnswer(
                        question.QuestionId, 
                        question.UsersTrueFalseAnswers.First(answer => answer.QuestionId == question.QuestionId).Value));
                    break;
                case QuestionType.MultipleChoice:
                    userAnswers.Add(new MultipleChoiceAnswer(
                        question.QuestionId,
                        question.UsersMultipleChoiceAnswers.First(answer => 
                            answer.QuestionId == question.QuestionId).MultipleChoiceAnswerId));
                    break;
                case QuestionType.LikertScale:
                    userAnswers.Add(new LikertScaleAnswer(
                        question.QuestionId,
                        question.UsersLikertScaleAnswers.First(answer =>
                            answer.QuestionId == question.QuestionId).Value,
                        question.LikertScaleAnswers.Any(answer => 
                            String.IsNullOrWhiteSpace(answer.Option3))));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(question.Type), "QuestionTypeWasWrong");
            }
        }

        return userAnswers;
    }

    /// <summary>
    /// Gets the correct answers to the questions provided through the queryable
    /// </summary>
    private async Task<List<IQuestionAnswer>> GetCorrectAnswersToTests(IQueryable<Question>? questionsQueryable,
        CancellationToken cancellationToken)
    {
        if (questionsQueryable is null)
        {
            return new();
        }
        
        var testQuestionsWithCorrectAnswers = await questionsQueryable
            .Include(question => question.MultipleChoiceAnswers)
            .Include(question => question.TrueFalseAnswer)
            .ToListAsync(cancellationToken);
        
        List<IQuestionAnswer> questionAnswers = new();
        
        foreach (var question in testQuestionsWithCorrectAnswers)
        {
            switch (question.Type)
            {
                case QuestionType.TrueFalse:
                    questionAnswers.Add(new TrueFalseAnswer(
                        question.QuestionId,
                        question.TrueFalseAnswer.Value));
                    break;
                case QuestionType.MultipleChoice:
                    questionAnswers.Add(new MultipleChoiceAnswer(
                        question.QuestionId,
                        question.MultipleChoiceAnswers.First(answer => answer.IsCorrect).MultipleChoiceAnswerId));
                    break;
                case QuestionType.LikertScale:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(question.Type), "WrongQuestionType");
            }
        }

        return questionAnswers;
    }

    public async Task<ErrorOr<Unit>> InsertUserTestAnswers(
        string userId,
        int testId, 
        TestType testType,
        List<UserQuestionAnswer> answers, 
        CancellationToken cancellationToken)
    {
        var correctTestTypeResult = await EnsureCorrectTestType(testId, testType, cancellationToken);
        if (correctTestTypeResult.IsError)
        {
            return correctTestTypeResult;
        }
        
        var userHasTakenTestResult = await EnsureUserHasntTakenTest(userId, testId, testType, cancellationToken);
        if (userHasTakenTestResult.IsError)
        {
            return userHasTakenTestResult;
        }
        
        var answersValidityResult = await CheckAnswersValidity(testId, testType, answers, cancellationToken);
        if (answersValidityResult.IsError)
        {
            return answersValidityResult;
        }

        await InsertAnswersToDb(userId, answers);

        if (testType == TestType.UniversityTest)
        {
            await InsertToStudentTookUniversityTest(userId, testId);
        }
        else
        {
            await InsertToUserTookGeneralTest(userId, testId);
        }

        await _dbContext.SaveChangesAsync(CancellationToken.None);

        return Unit.Value;
    }

    private async Task<ErrorOr<Unit>> EnsureCorrectTestType(int testId, TestType testType, 
        CancellationToken cancellationToken)
    {
        if (testType == TestType.UniversityTest)
        {
            var universityTest = await _dbContext.UniversityTests.FindAsync(
                new object?[] { testId }, cancellationToken);
            if (universityTest is null)
            {
                return Errors.Tests.UniversityTestIdNotFound;
            }
        }
        else
        {
            var generalTest = await _dbContext.GeneralTests.FindAsync(
                new object?[] { testId }, cancellationToken);
            if (generalTest is null)
            {
                return Errors.Tests.GeneralTestNotFound;
            }
        }

        return Unit.Value;
    }
    public async Task<ErrorOr<Unit>> EnsureUserHasntTakenTest(string userId, int testId, TestType testType,
        CancellationToken cancellationToken)
    {
        if (testType == TestType.UniversityTest)
        {
            var studentResult = await _dbContext.StudentsTookUniversityTests.FindAsync(
                new object?[] { testId, userId }, cancellationToken);
            if (studentResult is not null)
            {
                return Errors.Tests.StudentAlreadyTookTest;
            }
        }
        else
        {
            var generalUserResult = await _dbContext.UsersTookGeneralTests.FindAsync(
                new object?[] { testId, userId }, cancellationToken);
            if (generalUserResult is not null)
            {
                return Errors.Tests.ProspectiveStudentAlreadyTookTest;
            }
        }

        return Unit.Value;
    }
    private async Task<ErrorOr<Unit>> CheckAnswersValidity(int testId, TestType testType,
        List<UserQuestionAnswer> userAnswers, CancellationToken cancellationToken)
    {
        var testQuestionsQueryable = _dbContext.Questions.AsNoTracking();

        testQuestionsQueryable = testType == TestType.UniversityTest 
            ? testQuestionsQueryable.Where(q => q.UniversityTestId == testId) 
            : testQuestionsQueryable.Where(q => q.GeneralTestId == testId);
        
        var testQuestions = await testQuestionsQueryable.ToListAsync(cancellationToken);

        if (testQuestions.Count != userAnswers.Count)
        {
            return Errors.Tests.NotAllQuestionsWereAnswered;
        }

        foreach (var userAnswer in userAnswers)
        {
            var question = testQuestions.FirstOrDefault(q => q.QuestionId == userAnswer.QuestionId);
            
            if (question is null)
            {
                return Errors.Tests.QuestionNotPartOfTest(userAnswer.QuestionId, testId);
            }

            if (question.Type != userAnswer.QuestionType)
            {
                return Errors.Tests.AnswerTypeNotCompatible(
                    userAnswer.QuestionId, userAnswer.QuestionType.ToString(), question.Type.ToString());
            }
        }

        var existingMultipleChoiceAnswersQueryable = _dbContext.Questions.AsNoTracking();

        existingMultipleChoiceAnswersQueryable = testType == TestType.UniversityTest 
            ? existingMultipleChoiceAnswersQueryable.Where(q => q.UniversityTestId == testId) 
            : existingMultipleChoiceAnswersQueryable.Where(q => q.GeneralTestId == testId);

        // Here we check if the multiple choice answer ids that the user gave exist in the database and correspond
        // to the correct question
        var existingMultipleChoiceAnswers = await existingMultipleChoiceAnswersQueryable
            .Select(q => q.MultipleChoiceAnswers)
            .ToListAsync(cancellationToken);

        // If there are no multiple choice answers we are fine
        if (existingMultipleChoiceAnswers.Any() == false)
        {
            return Unit.Value;
        }
        
        // If there is any user answer that is a multiple choice answer and it doesn't exist in the database
        // answers that correspond to the given test then the multiple choice given by the user is wrong
        foreach (var userAnswer in userAnswers)
        {
            if (userAnswer.QuestionType != QuestionType.MultipleChoice)
            {
                continue;
            }

            if (existingMultipleChoiceAnswers.Any(existingAnswer => existingAnswer.Any(
                    a => a.MultipleChoiceAnswerId == userAnswer.MultipleChoiceAnswerId)) == false)
            {
                return Errors.Tests.MultipleChoiceAnswerDoesntMatch(userAnswer.QuestionId);
            }
        }

        return Unit.Value;
    }
    private Task InsertAnswersToDb(string userId, List<UserQuestionAnswer> answers)
    {
        var userTrueFalseAnswers = 
            answers.Where(a => a.TrueOrFalseAnswer is not null).ToImmutableArray();
        var userMultipleChoiceAnswers = 
            answers.Where(a => a.MultipleChoiceAnswerId is not null).ToImmutableArray();
        var userLikertScaleAnswers =
            answers.Where(a => a.LikertScaleAnswer is not null).ToImmutableArray();

        List<Task> addAnswersTasks = new();

        if (userTrueFalseAnswers.Any())
        {
            addAnswersTasks.Add(_dbContext.UserTrueFalseAnswers.AddRangeAsync(
                userTrueFalseAnswers.Select(a => a.MapToUserTrueFalseAnswer(userId))));
        }

        if (userMultipleChoiceAnswers.Any())
        {
            addAnswersTasks.Add(_dbContext.UserMultipleChoiceAnswers.AddRangeAsync(
                userMultipleChoiceAnswers.Select(a => a.MapToUserMultipleChoiceAnswer(userId))));
        }

        if (userLikertScaleAnswers.Any())
        {
            addAnswersTasks.Add(_dbContext.UserLikertScaleAnswers.AddRangeAsync(
                userLikertScaleAnswers.Select(a => a.MapToUserLikertScaleAnswer(userId))));
        }
        
        return Task.WhenAll(addAnswersTasks);
    }
    private ValueTask<EntityEntry<StudentTookUniversityTest>> InsertToStudentTookUniversityTest(
        string userId, int universityTestId)
    {
        return _dbContext.StudentsTookUniversityTests.AddAsync(
            new StudentTookUniversityTest(userId, universityTestId));
    }
    private ValueTask<EntityEntry<UserTookGeneralTest>> InsertToUserTookGeneralTest(string userId, int generalTestId)
    {
        return _dbContext.UsersTookGeneralTests.AddAsync(
            new UserTookGeneralTest(userId, generalTestId));
    }
}