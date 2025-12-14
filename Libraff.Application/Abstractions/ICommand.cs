namespace Libraff.Application.Abstractions
{

    public interface ICommand<TResponse> : IRequest<Result<TResponse, IError>>
        where TResponse : notnull
    { }
}
