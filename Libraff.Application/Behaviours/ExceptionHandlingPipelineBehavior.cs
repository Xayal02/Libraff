namespace Libraff.Application.Behaviours
{
    public class ExceptionHandlingPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
      where TRequest : notnull, IRequest<TResponse>
      where TResponse : notnull
    {
        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                var failureResult = Result.Failure<Guid, Error>(Error.UnExpected($"An unexpected error occurred: {ex.Message}"));

                if (failureResult is TResponse response)
                {
                    return response;
                }

                throw new InvalidCastException("Failed to cast unexpected error result to the expected TResponse type.");
            }
        }
    }
}
