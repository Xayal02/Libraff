using Libraff.Domain.Constants;
using System.Text.RegularExpressions;
using Libraff.Domain.Exceptions;


namespace Libraff.Domain
{
    public record ContactNumber
    {
        public string Value { get; private set; }

        private ContactNumber(string value)
        {
            if (string.IsNullOrEmpty(value)) 
                throw new ValidationException("Value cannot be null");

            string formattedValue = value.Replace(" ", "")
                                         .Replace("-", "")
                                         .Replace("(", "")
                                         .Replace(")", "");

            if (!Regex.IsMatch(formattedValue, RegexExpressions.AzerbaijanPhoneNumberFormat))
                throw new ValidationException("Invalid Azerbaijani mobile phone number format.");

            Value = formattedValue;


        }

        public static ContactNumber Create(string value) => new ContactNumber(value);
    }




}
