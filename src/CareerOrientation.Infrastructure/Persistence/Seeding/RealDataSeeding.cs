using CareerOrientation.Domain.Common;
using CareerOrientation.Domain.Entities;
using CareerOrientation.Domain.JunctionEntities;
using CareerOrientation.Infrastructure.Persistence.Seeding.JsonDTOs;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using static CareerOrientation.Infrastructure.Persistence.Seeding.JsonParser;

namespace CareerOrientation.Infrastructure.Persistence.Seeding;

public class RealDataSeeding : IDataSeeding
{
    private readonly ILookupNormalizer _lookupNormalizer;

    public RealDataSeeding(ILookupNormalizer lookupNormalizer)
    {
        _lookupNormalizer = lookupNormalizer;
    }
    
    public async Task Seed(ModelBuilder builder)
    {
        /*if (Debugger.IsAttached == false)
        {
            Debugger.Launch();
        }*/

        var coursesDTO = await GetJsonContentFromAssemblyAsync<CourseDTO>("courses.json");
        var skillsDTO = await GetJsonContentFromAssemblyAsync<SkillDTO>("skills.json");
        var courseSkillsDTO = await GetJsonContentFromAssemblyAsync<CourseSkillDTO>("courseSkills.json");

        builder.Entity<Course>().HasData(coursesDTO!.Courses);
        builder.Entity<Skill>().HasData(skillsDTO!.Skills);
        builder.Entity<CourseSkill>().HasData(courseSkillsDTO!.CourseSkills);
        
        builder.Entity<Track>().HasData(new List<Track>
        {
            new Track { TrackId = 1, Name = "ΤΛΕΣ" },
            new Track { TrackId = 2, Name = "ΔΥΣ" },
            new Track { TrackId = 3, Name = "ΠΣΥ" }
        });
        
        builder.Entity<IdentityRole>().HasData(AppRoles.GetAllRoles()
            .Select(role => new IdentityRole()
            {
                Id = Guid.NewGuid().ToString(),
                Name = role,
                NormalizedName = _lookupNormalizer.NormalizeName(role),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            }));
    }
}
