namespace Libraff.Domain.Constants
{
    public class DomainErrorMessages
    {

        public const string SalaryOutOfRange = "Salary is not within the acceptable range for the specified branch and position.";

        public const string EmployeeLimitReached = "The employee limit has been reached for the specified branch and position.";

        public const string SalaryRangeInvalid = "Minimum value must be less than maximum value.";


        public static string Required(string propertyName)
        {
            return $"{propertyName} is cannot be null or empty.";
        }

        public static string MustBeGreaterThanZero(string propertyName)
        {
            return $"{propertyName} must be greater than 0.";
        }
        public static string InvalidValue(string? propertyName = null)
        {
            return string.IsNullOrEmpty(propertyName)
                ? "Provided value is invalid."
                : $"Provided value for {propertyName} is invalid.";

        }

        public static string InvalidValues(params string[] propertyNames)
        {
            string properties = string.Join(",", propertyNames);

            return $"Provided values for {properties} is invalid.";

        }
    }
}
