using Libraff.Domain.Constants;
using System.Text.RegularExpressions;

namespace Libraff.Domain
{
    public record ContactNumber
    {
        public string Value { get; private set; }

        private ContactNumber(string value)
        {
            if (string.IsNullOrEmpty(value)) 
                throw new ArgumentNullException("Value cannot be null");

            string formattedValue = value.Replace(" ", "")
                                         .Replace("-", "")
                                         .Replace("(", "")
                                         .Replace(")", "");

            if (!Regex.IsMatch(formattedValue, RegexExpressions.AzerbaijanPhoneNumberFormat))
                throw new ArgumentException("Invalid Azerbaijani mobile phone number format.");

            Value = formattedValue;


        }

        public static ContactNumber Create(string value) => new ContactNumber(value);
    }




}
