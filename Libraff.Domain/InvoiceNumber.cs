using Libraff.Domain.Constants;

namespace Libraff.Domain
{
    public record InvoiceNumber
    {
        public string Value { get; }

        private InvoiceNumber(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ArgumentException(DomainErrorMessages.InvalidValue(nameof(InvoiceNumber)));

            Value = value.ToUpper();
        }

        public static InvoiceNumber Create(string value)
        {
            return new InvoiceNumber(value);
        }


    }
}
