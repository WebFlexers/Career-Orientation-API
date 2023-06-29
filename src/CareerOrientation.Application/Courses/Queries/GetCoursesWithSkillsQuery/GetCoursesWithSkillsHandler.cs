using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Courses.Common;
using CareerOrientation.Domain.Common.DomainErrors;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Courses.Queries.GetCoursesWithSkillsQuery;

public class GetCoursesWithSkillsHandler : 
    IRequestHandler<GetCoursesWithSkillsQuery, ErrorOr<List<CoursesWithSkillsResult>>>
{
    private readonly ICourseRepository _courseRepository;

    public GetCoursesWithSkillsHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }
    
    public async Task<ErrorOr<List<CoursesWithSkillsResult>>> Handle(GetCoursesWithSkillsQuery request, 
        CancellationToken cancellationToken)
    {
        List<CoursesWithSkillsResult>? coursesWithSkills = null;
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