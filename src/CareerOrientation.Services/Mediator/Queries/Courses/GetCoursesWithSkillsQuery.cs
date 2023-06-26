using CareerOrientation.Data.DTOs.Courses;
using LanguageExt.Common;
using MediatR;

namespace CareerOrientation.Services.Mediator.Queries.Courses;

public record GetCoursesWithSkillsQuery(CoursesSkillsRequest CoursesWithSkillsRequest) 
    : IRequest<Result<CoursesSkillsResponse?>>;