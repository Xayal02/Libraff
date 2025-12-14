using Libraff.Domain.Constants;
using Libraff.Domain.Exceptions;


namespace Libraff.Domain
{
    public record InvoiceNumber
    {
        public string Value { get; }

        private InvoiceNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationException(DomainErrorMessages.InvalidValue(nameof(InvoiceNumber)));

            Value = value.ToUpper();
        }

        public static InvoiceNumber Create(string value)
        {
            return new InvoiceNumber(value);
        }


    }
}
