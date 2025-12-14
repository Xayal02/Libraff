namespace Libraff.Domain.Errors
{
    public interface IError
    {
        int Code { get; }
        ErrorType ErrorType { get; }
        string Message { get; }
    }
}