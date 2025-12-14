using Libraff.Domain.Constants;
using Libraff.Domain.Exceptions;


namespace Libraff.Domain
{
    public record AddedBookSupplyDetail
    {
        public int BookId { get; }
        public int Count { get; private set; }

        private AddedBookSupplyDetail(int bookId, int count)
        {
            if (bookId <= 0)
                throw new ValidationException(DomainErrorMessages.Required(nameof(BookId)));

            BookId = bookId;
            Count = count;
        }

        public static AddedBookSupplyDetail Create(int bookId, int count = 1)
        {
            return new AddedBookSupplyDetail(bookId, count);

        }
    }
}
