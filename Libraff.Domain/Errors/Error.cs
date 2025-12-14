using Microsoft.AspNetCore.Http;

namespace Libraff.Domain.Errors
{
    public class Error : IError
    {
        public int Code { get; private set; }
        public string Message { get; private set; }
        public ErrorType ErrorType { get; private set; }

        private Error(int code, string message, ErrorType errorType)
        {
            Code = code;
            Message = message;
            ErrorType = errorType;
        }

        public static Error BadRequest(string? message = "Invalid request or parameters.") =>
            new Error(StatusCodes.Status400BadRequest, message, ErrorType.BadRequest);

        public static Error NotFound(string? message = "The requested item could not be found.") =>
            new Error(StatusCodes.Status404NotFound, message, ErrorType.NotFound);

        public static Error Conflict(string? message = "The data provided conflicts with existing data.") =>
    new Error(StatusCodes.Status409Conflict, message, ErrorType.Conflict);

        public static Error UnExpected(string? message = "Unexpected error happened.") =>
            new Error(StatusCodes.Status500InternalServerError, message, ErrorType.UnExpected);


    }
}
