using CareerOrientation.Application.Common.Logging;

using ErrorOr;

using MediatR;

using Microsoft.Extensions.Logging;

namespace CareerOrientation.Application.Common.Behaviors;

public class ErrorLoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> 
    where TRequest : notnull 
    where TResponse : IErrorOr
{
    private readonly ILogger<TRequest> _logger;

    // ReSharper disable once ContextualLoggerProblem
    public ErrorLoggingBehavior(ILogger<TRequest> logger)
    {
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var response = await next();

        if (response.IsError)
        {
            var requestName = request.GetType().Name;
            foreach (var error in response.Errors!)
            {
                _logger.LogGeneralExpectedError(requestName, error.Code, error.Description);
            }
        }

        return response;
    }
}