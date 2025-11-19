using Libraff.Domain.Constants;

namespace Libraff.Domain
{
    public class Discount
    {
        public int Id { get; private set; }
        public int TypeId { get; private set; }
        public int ReferenceId { get; private set; }
        public DateOnly ValidFrom { get; private set; }
        public DateOnly ValidTo { get; private set; }
        public Percent Percent { get; private set; }
        private Discount(int typeId, int referenceId, DateOnly validFrom, DateOnly validTo, Percent percent)
        {
            if (typeId <= 0)
                throw new ArgumentException(DomainErrorMessages.MustBeGreaterThanZero(nameof(TypeId)));

            if (referenceId <= 0)
                throw new ArgumentException(DomainErrorMessages.MustBeGreaterThanZero(nameof(ReferenceId)));

            if (validTo > validFrom)
                throw new ArgumentOutOfRangeException(DomainErrorMessages.InvalidValues(nameof(ValidFrom), nameof(ValidTo)));

            TypeId = typeId;
            ReferenceId = referenceId;
            ValidFrom = validFrom;
            ValidTo = validTo;
            Percent = percent;
        }

        public Discount Create(int typeId, int referenceId, DateOnly validFrom, DateOnly validTo, Percent percent)
        {
            return new Discount(typeId, referenceId, validFrom, validTo, percent);
        }
    }
}
