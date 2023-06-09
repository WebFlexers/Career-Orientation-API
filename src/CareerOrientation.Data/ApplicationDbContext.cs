using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Entities.Tests;
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
    public DbSet<Track> Tracks { get;set; }
    public DbSet<MastersDegree> MastersDegrees { get; set; }
    public DbSet<Profession> Professions { get; set; }

    // Tests
    public DbSet<Question> Questions { get; set; }
    public DbSet<GeneralTest> GeneralTests { get; set; }
    public DbSet<UniversityTest> UniversityTests { get; set; }

    // Users
    public DbSet<UniversityStudent> UniversityStudents { get; set; }
}
