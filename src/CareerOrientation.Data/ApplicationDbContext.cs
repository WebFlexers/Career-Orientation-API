using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.TestsSpecialtiesRelations;
using CareerOrientation.Data.Entities.TestsUsersRelations;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Data.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection;

namespace CareerOrientation.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
{
    private readonly ILoggerFactory? _loggerFactory;

    public ApplicationDbContext(DbContextOptions options, ILoggerFactory? loggerFactory): base(options) 
    {
        _loggerFactory = loggerFactory;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        if (_loggerFactory != null)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
        }
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        var sampleData = new SampleData();
        sampleData.Seed(builder);
    }

    // Specialties
    public DbSet<MastersDegree> MastersDegrees { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<Track> Tracks { get;set; }

    // Tests
    public DbSet<GeneralTest> GeneralTests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<UniversityTest> UniversityTests { get; set; }

    public DbSet<MultipleChoiceAnswer> MultipleChoiceAnswers { get; set; }
    public DbSet<TrueFalseAnswer> TrueFalseAnswers { get; set; }

    // Tests - Specialty relations
    public DbSet<QuestionMastersDegree> QuestionsMastersDegrees { get; set; }
    public DbSet<QuestionProfession> QuestionsProfessions { get; set; }
    public DbSet<QuestionTrack> QuestionsTracks { get; set; }

    // Answers - Users relations
    public DbSet<UserLikertScaleAnswer> UserLikertScaleAnswers { get; set; }    
    public DbSet<UserMultipleChoiceAnswer> UserMultipleChoiceAnswers { get; set; }
    public DbSet<UserTrueFalseAnswer> UserTrueFalseAnswers { get; set; }

    // Tests - Users relations
    public DbSet<UserTookGeneralTest> UsersTookGeneralTests { get; set; }
    public DbSet<StudentTookUniversityTest> StudentsTookUniversityTests { get; set; }

    // Users
    public DbSet<UniversityStudent> UniversityStudents { get; set; }
}
