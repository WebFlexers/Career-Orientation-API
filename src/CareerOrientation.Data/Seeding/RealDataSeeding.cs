using System.Diagnostics;
using CareerOrientation.Data.Entities.Courses;
using CareerOrientation.Data.Entities.Specialties;
using CareerOrientation.Data.Seeding.JsonDTOs;
using Microsoft.EntityFrameworkCore;
using static CareerOrientation.Data.Seeding.JsonParser;

namespace CareerOrientation.Data.Seeding;

public class RealDataSeeding : IDataSeeding
{
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
    }
}
