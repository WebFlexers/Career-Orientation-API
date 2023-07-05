using CareerOrientation.Application.Common.Abstractions.Persistence;
using CareerOrientation.Application.Tests.ProspectiveStudentTests.Queries.ProspectiveStudentTestsCompletionState;
using CareerOrientation.Domain.Common.DomainErrors;
using CareerOrientation.Domain.Common.Enums;

using ErrorOr;

using MediatR;

namespace CareerOrientation.Application.Recommendations.Queries.ProspectiveStudentRecommendation;

public class ProspectiveStudentRecommendationHandler 
    : IRequestHandler<ProspectiveStudentRecommendationQuery, ErrorOr<List<GeneralTestRecommendationResult>>>
{
    private readonly ISender _mediatorSender;
    private readonly IUserRepository _userRepository;

    public ProspectiveStudentRecommendationHandler(ISender mediatorSender, IUserRepository userRepository)
    {
        _mediatorSender = mediatorSender;
        _userRepository = userRepository;
    }
    
    public async Task<ErrorOr<List<GeneralTestRecommendationResult>>> Handle(
        ProspectiveStudentRecommendationQuery request, CancellationToken cancellationToken)
    {
        var user = await _userRepository.GetUserById(request.UserId, cancellationToken);
        if (user is null || user.IsProspectiveStudent == false)
        {
            return Errors.User.WrongUserType;
        }
        
        // There are 2 types of recommendations for prospective students:
        // 1) Whether computer science is a good fit for them
        // 2) Whether the University of Piraeus is a good fit for them
        //
        // If computer science is NOT a good fit then the user can't do the test about the university of Piraeus
        // suitability, since there is no point. So in that case we only return a recommendation about the suitability
        // of computer science.
        
        // To start we have to check if the prospective student has completed at least the first test
        var query = new ProspectiveStudentTestsCompletionStateQuery(request.UserId);
        var errorOrTestsCompletionState = await _mediatorSender.Send(query, cancellationToken);
        if (errorOrTestsCompletionState.IsError)
        {
            return errorOrTestsCompletionState.Errors;
        }

        var testsCompletionState = errorOrTestsCompletionState.Value;
        
        var zeroTestsAreCompleted = testsCompletionState.All(test => test.IsCompleted == false);
        if (zeroTestsAreCompleted)
        {
            return Errors.Recommendations.ZeroTestsAreCompleted;
        }

        List<GeneralTestRecommendationResult> recommendationResults = new();
        
        // Now we order the tests by type to make sure we start with the first one
        // The recommendation of the first test is made and if the recommendation level
        // is at least moderate we continue to the second test and calculate a recommendation
        // for that as well
        foreach (var testCompletionResult in testsCompletionState.OrderBy(test => test.TestType))
        {
            if (testCompletionResult.IsCompleted == false)
            {
                continue;
            }
            
            var generalTestRecommendationQuery = new GeneralTestRecommendationQuery(request.UserId,
                testCompletionResult.GeneralTestId, testCompletionResult.TestType);
            
            var suitabilityResult = await _mediatorSender.Send(
                generalTestRecommendationQuery, cancellationToken);
            
            if (suitabilityResult.IsError)
            {
                return suitabilityResult.Errors;
            }
            
            recommendationResults.Add(suitabilityResult.Value);

            if (suitabilityResult.Value.RecommendationLevel < RecommendationLevel.ModerateFit)
            {
                return recommendationResults;
            }
        }

        return recommendationResults;
    }
}