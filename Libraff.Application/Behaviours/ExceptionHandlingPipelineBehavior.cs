using Libraff.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace Libraff.Application.Behaviours
{
    public class ExceptionHandlingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
      where TRequest : notnull, IRequest<TResponse>
      where TResponse : notnull
    {

        private readonly ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> _logger;

        public ExceptionHandlingPipelineBehavior(ILogger<ExceptionHandlingPipelineBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            
            catch(ValidationException ex)
            {
                var failureResult = Result.Failure<Unit, Error>(Error.BadRequest(ex.Message));

                if (failureResult is TResponse response)
                {
                    return response;
                }

                _logger.LogCritical(
                    @$"Failed to cast unexpected error result to the expected TResponse type.
                       RequestType: {typeof(TRequest).Name}, ResponseType: {typeof(TResponse).Name}");

                throw new InvalidCastException("Failed to cast unexpected error result to the expected TResponse type.");
            }

            catch (NotFoundException ex)
            {
                var failureResult = Result.Failure<Unit, Error>(Error.NotFound(ex.Message));

                if (failureResult is TResponse response)
                {
                    return response;
                }

                _logger.LogCritical(
                    @$"Failed to cast unexpected error result to the expected TResponse type.
                       RequestType: {typeof(TRequest).Name}, ResponseType: {typeof(TResponse).Name}");

                throw new InvalidCastException("Failed to cast unexpected error result to the expected TResponse type.");
            }

            catch (Exception ex)
            {

                _logger.LogError(ex,
                    $"An unhandled exception occurred while processing request {typeof(TRequest)}. Request: {request}");

                var failureResult = Result.Failure<Unit, Error>(Error.UnExpected($"An unexpected error occurred: {ex.Message}"));

                if (failureResult is TResponse response)
                {
                    return response;
                }

                _logger.LogCritical(
                    @$"Failed to cast unexpected error result to the expected TResponse type.
                       RequestType: {typeof(TRequest).Name}, ResponseType: {typeof(TResponse).Name}");

                throw new InvalidCastException("Failed to cast unexpected error result to the expected TResponse type.");
            }
        }
    }
}
