using CareerOrientation.Data;
using CareerOrientation.Data.DTOs.Courses;
using CareerOrientation.Data.DTOs.Courses.Mappers;
using CareerOrientation.Services.Mediator.Queries.Courses;
using CareerOrientation.Services.Validation.Exceptions;
using FluentValidation;
using LanguageExt.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CareerOrientation.Services.Mediator.Handlers.Courses;

public class GetCoursesWithSkillsHandler : IRequestHandler<GetCoursesWithSkillsQuery, Result<CoursesSkillsResponse?>>
{
    private readonly ApplicationDbContext _dbContext;
    private readonly IValidator<CoursesSkillsRequest> _validator;

    public GetCoursesWithSkillsHandler(ApplicationDbContext dbContext, IValidator<CoursesSkillsRequest> validator)
    {
        _dbContext = dbContext;
        _validator = validator;
    }
    
    public async Task<Result<CoursesSkillsResponse?>> Handle(GetCoursesWithSkillsQuery request, 
        CancellationToken cancellationToken)
    {
        var coursesWithSkillsRequest = request.CoursesWithSkillsRequest;

        try
        {
            var validationResult = await _validator.ValidateAsync(coursesWithSkillsRequest, cancellationToken);

            if (validationResult.IsValid == false)
            {
                var validationException = new ValidationException(validationResult.Errors);
                return new Result<CoursesSkillsResponse?>(
                   validationException.MapToSimpleValidationException());
            }

            List<CourseDTO>? coursesWithSkills = null;
            if (coursesWithSkillsRequest.Track is null)
            {
                coursesWithSkills = await _dbContext.Courses
                    .AsNoTracking()
                    .Where(c => c.Semester == coursesWithSkillsRequest.Semester)
                    .Select(c =>
                        c.MapToCourseWithSkills(c.Skills.OrderBy(s => s.Type).ToList())
                    ).ToListAsync(cancellationToken);
            }
            else
            {
                var track = _dbContext.Tracks.First(t => t.Name == coursesWithSkillsRequest.Track);
                
                coursesWithSkills = await _dbContext.Courses
                    .AsNoTracking()
                    .Where(c => c.Semester == coursesWithSkillsRequest.Semester &&
                                (c.TrackId == null || c.TrackId == track.TrackId))
                    .Select(c =>
                        c.MapToCourseWithSkills(c.Skills.OrderBy(s => s.Type).ToList())
                    ).ToListAsync(cancellationToken);
            }

            return new CoursesSkillsResponse()
            {
                Courses = coursesWithSkills
            };
        }
        catch (Exception ex)
        {
            return new Result<CoursesSkillsResponse?>(ex);
        }
    }
}