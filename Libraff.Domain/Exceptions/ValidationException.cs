namespace Libraff.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public IReadOnlyList<string> Errors { get; }

        public ValidationException()
            : base("One or more validation errors occurred")
        {
            Errors = new List<string>();
        }

        public ValidationException(string message)
            : base(message)
        {
            Errors = new List<string> { message };
        }

        public ValidationException(IEnumerable<string> errors)
            : base("One or more validation errors occurred")
        {
            Errors = errors.ToList();
        }
    }
}

