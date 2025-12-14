using Libraff.Domain.Constants;
using Libraff.Domain.Exceptions;


namespace Libraff.Domain
{
    public record Percent
    {
        public short Value { get; private set; }

        private Percent(short value)
        {
            if (value < 0 || value > 100)
                throw new ValidationException(DomainErrorMessages.InvalidValue());

            Value = value;
        }

        public static Percent Create(short value)
        {
            return new Percent(value);
        }

        public static Percent Tenth() => new Percent(10);
        public static Percent Fifth() => new Percent(20);
        public static Percent Quarter() => new Percent(25);
        public static Percent Half() => new Percent(50);


    }

}
