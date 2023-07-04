using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.HasProspectiveStudentTakenTest;

/// <summary>
/// Returns whether or not the given user has completed the given general test
/// </summary>
public record HasProspectiveStudentTakenTestQuery(
    string UserId,
    int GeneralTestId) : IRequest<ErrorOr<bool>>;