using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.GetHasProspectiveStudentTakenTest;

public record GetHasProspectiveStudentTakenTestQuery(
    string UserId,
    int GeneralTestId) : IRequest<ErrorOr<bool>>;