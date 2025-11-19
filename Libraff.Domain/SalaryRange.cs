using Libraff.Domain.Constants;

namespace Libraff.Domain
{
    public record SalaryRange
    {
        public decimal MiniumValue { get; private set; }
        public decimal MaximumValue { get; private set; }

        private SalaryRange(decimal miniumValue, decimal maximumValue)
        {
            if (miniumValue <= 0)
                throw new ArgumentException(DomainErrorMessages.InvalidValue()); 

            if (maximumValue <= 0)
                throw new ArgumentException(DomainErrorMessages.InvalidValue());

            if (miniumValue >= maximumValue)
                throw new ArgumentException(DomainErrorMessages.SalaryRangeInvalid);

            MiniumValue = miniumValue;
            MaximumValue = maximumValue;
        }

        public static SalaryRange Create(decimal miniumValue, decimal maximumValue)
        {
            return new SalaryRange(miniumValue, maximumValue);
        }


    }
}
