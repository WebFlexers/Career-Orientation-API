using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.Tests;
using CareerOrientation.Data.Entities.TestsSpecialtiesRelations;
using CareerOrientation.Data.Entities.Users;
using CareerOrientation.Data.Seeding;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace CareerOrientation.Data;

public class ApplicationDbContext : IdentityDbContext<User, IdentityRole, string>
{
    public ApplicationDbContext(DbContextOptions options): base(options) { }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

        var sampleData = new SampleData();
        sampleData.Seed();
    }

    // Specialties
    public DbSet<MastersDegree> MastersDegrees { get; set; }
    public DbSet<Profession> Professions { get; set; }
    public DbSet<Track> Tracks { get;set; }

    // Tests
    public DbSet<GeneralTest> GeneralTests { get; set; }
    public DbSet<Question> Questions { get; set; }
    public DbSet<UniversityTest> UniversityTests { get; set; }

    // Tests - Specialty relations
    public DbSet<QuestionMastersDegree> QuestionsMastersDegrees { get; set; }
    public DbSet<QuestionProfession> QuestionsProfessions { get; set; }
    public DbSet<QuestionTrack> QuestionsTracks { get; set; }

    // Users
    public DbSet<UniversityStudent> UniversityStudents { get; set; }
}
