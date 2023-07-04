using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Courses.Common;
using CareerOrientation.Domain.Common.DomainErrors;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Courses.Queries.CoursesWithSkillsQuery;

public class CoursesWithSkillsHandler : 
    IRequestHandler<CoursesWithSkillsQuery, ErrorOr<List<CoursesWithSkillsResult>>>
{
    private readonly ICourseRepository _courseRepository;

    public CoursesWithSkillsHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    public async Task<ErrorOr<List<CoursesWithSkillsResult>>> Handle(CoursesWithSkillsQuery request, 
        CancellationToken cancellationToken)
    {
        List<CoursesWithSkillsResult>? coursesWithSkills = null;
        // If the track is not provided it means the given semester doesn't have track specific courses and
        // if the user is a prospective student then they can see all the courses not only the ones of a track and
        // the common ones
        if (request.Track is null || request.IsProspectiveStudent)
        {
            coursesWithSkills = 
                await _courseRepository.GetCoursesWithSkills(request.Semester, cancellationToken);
        }
        else
        {
            coursesWithSkills = 
                await _courseRepository.GetCoursesWithSkills(request.Semester, request.Track, cancellationToken);
        }

        if (coursesWithSkills is null || coursesWithSkills.Any() == false)
        {
            return Errors.Courses.NoCoursesFound;
        }

        return coursesWithSkills;
    }
}