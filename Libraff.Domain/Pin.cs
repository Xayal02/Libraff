using Libraff.Domain.Constants;
using Libraff.Domain.Exceptions;
using System.Text.RegularExpressions;

namespace Libraff.Domain
{
    public record Pin
    {
        public string Value { get; private set; }
        private Pin(string value)
        {
            if (string.IsNullOrEmpty(value))
                throw new ValidationException("Value cannot be null");

            string formattedValue = value.Trim().ToUpper();

            if (!Regex.IsMatch(formattedValue, RegexExpressions.AzerbaijanIndentityCardNumberFormat))
                throw new ValidationException("Invalid Azerbaijani FIN code format.");

            Value = formattedValue;


        }

        public static Pin Create(string value) => new Pin(value);
    }




}
