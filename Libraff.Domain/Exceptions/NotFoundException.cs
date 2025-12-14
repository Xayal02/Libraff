namespace Libraff.Domain.Exceptions
{
    public class NotFoundException : Exception
    {
        public NotFoundException()
                : base("The requested entity was not found") { }

        public NotFoundException(string message)
            : base(message) { }

        public NotFoundException(string entityName, object entityId)
            : base($"{entityName} with id '{entityId}' was not found") { }
    }
}
