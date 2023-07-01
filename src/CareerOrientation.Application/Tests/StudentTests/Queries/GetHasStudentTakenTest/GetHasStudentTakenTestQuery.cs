using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.StudentTests.Queries.GetHasStudentTakenTest;

public record GetHasStudentTakenTestQuery(
    string UserId,
    int UniversityTestId) : IRequest<ErrorOr<bool>>;