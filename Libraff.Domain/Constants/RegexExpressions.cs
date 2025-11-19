namespace Libraff.Domain.Constants
{
    public class RegexExpressions
    {
        public const string AzerbaijanPhoneNumberFormat = @"^(?:\+994|0)(?:50|51|55|60|65|70|77|88|99)\d{7}$";

        public const string AzerbaijanIndentityCardNumberFormat= @"^[A-HJ-NPR-Z0-9]{7}$";
    }
}
