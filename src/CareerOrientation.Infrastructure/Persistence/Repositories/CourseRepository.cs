

using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Courses.Common;
using CareerOrientation.Application.Courses.Common.Mapping;

using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Infrastructure.Persistence.Repositories;

public class CourseRepository : RepositoryBase, ICourseRepository
{
    public CourseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    /// <summary>
    /// Gets the main courses of the given semester and the courses of the given track with their respective skills
    /// </summary>
    public async Task<List<CoursesWithSkillsResult>> GetCoursesWithSkills(int semester, string trackName, 
        CancellationToken token = default)
    {
        var track = _dbContext.Tracks.First(t => t.Name == trackName);
        
        return await _dbContext.Courses
            .AsNoTracking()
            .Where(c => c.Semester == semester &&
                        (c.TrackId == null || c.TrackId == track.TrackId))
            .Include(c => c.Track)
            .Select(c =>
                c.CreateCourseWithSkills(c.Skills.OrderBy(s => s.Type).ToList())
            ).ToListAsync(token);
    }
    
    /// <summary>
    /// Gets the courses of the given semester with their respective skills
    /// </summary>
    public async Task<List<CoursesWithSkillsResult>?> GetCoursesWithSkills(int semester, 
        CancellationToken token = default)
    {
        return await _dbContext.Courses
            .AsNoTracking()
            .Where(c => c.Semester == semester)
            .Include(c => c.Track)
            .Select(c =>
                c.CreateCourseWithSkills(c.Skills.OrderBy(s => s.Type).ToList())
            ).ToListAsync(token);
    }
}